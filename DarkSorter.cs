/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 01.12.2017
 * Time: 18:40
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using DarkSorter.Helpers;
using Microsoft.Win32;

namespace DarkSorter
{
	/// <summary>
	/// Сортировщик дарков, движок собстно
	/// </summary>
	public class DarkSorter
	{

		/// <summary>
		/// Регнистри
		/// </summary>
		private RegistryKey reg;

		/// <summary>
		/// Список найденных валидных файлов дарков
		/// </summary>
		public List<Dark.Base> files = new List<Dark.Base>();

		/// <summary>
		/// Сейчас идёт сканирование дарков?
		/// </summary>
		private long scanInProgress = 0;

		/// <summary>
		/// Для асинхронного сканирования дарков
		/// </summary>
		private Thread scanThread;

		/// <summary>
		/// Сейчас идёт копирование выбранных дарков?
		/// </summary>
		private long copyInProgress = 0;

		/// <summary>
		/// Для асинхронного копирования дарков
		/// </summary>
		private Thread copyThread;

		/// <summary>
		/// Для обновления формы
		/// </summary>
		private MainForm form;


		public DarkSorter(MainForm form)
		{
			this.form = form;

			reg =
				Registry.CurrentUser.OpenSubKey("SOFTWARE\\mo\\DarkSorter", true) ??
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\mo\\DarkSorter", RegistryKeyPermissionCheck.ReadWriteSubTree);

			Scan();
		}


		#region get/set


		private int? iso;

		public int ISO
		{
			get
			{
				return iso ?? (iso = Convert.ToInt32(reg.GetValue("ISO", "200"))) ?? 200;
			}
			set
			{
				if (iso != value) {
					reg.SetValue("ISO", value.ToString());
					iso = value;

					this.form.setCounts(getFilteredCount(), files.Count);
				}
			}
		}

		private string folderIn;

		public string FolderIn
		{
			get
			{
				return folderIn ?? (folderIn = reg.GetValue("FolderIn", "").ToString());
			}
			set
			{
				if (folderIn != value) {
					folderIn = value;
					reg.SetValue("FolderIn", value);
					Scan();
				}
			}
		}

		private string folderOut;

		public string FolderOut
		{
			get
			{
				return folderOut ?? (folderOut = reg.GetValue("FolderOut", "").ToString());
			}
			set
			{
				if (folderOut != value) {
					folderOut = value;
					reg.SetValue("FolderOut", value);
				}
			}
		}

		private int? expose;

		public int Expose
		{
			get
			{
				return expose ?? (expose = Convert.ToInt32(reg.GetValue("expose", "600"))) ?? 600;
			}
			set
			{
				if (value != expose) {
					expose = value;
					reg.SetValue("expose", expose.ToString());

					this.form.setCounts(getFilteredCount(), files.Count);
				}
			}
		}

		private int? exposeRange;

		public int ExposeRange
		{
			get
			{
				return exposeRange ?? (exposeRange = Convert.ToInt32(reg.GetValue("exposeRange", 10))) ?? 10;
			}
			set
			{
				if (exposeRange != value) {
					exposeRange = value;
					reg.SetValue("exposeRange", value.ToString());

					this.form.setCounts(getFilteredCount(), files.Count);
				}
			}
		}

		private int? temperature;

		public int Temperature
		{
			get
			{
				return temperature ?? (temperature = Convert.ToInt32(reg.GetValue("themp", -10))) ?? -10; //TODO: fix typo t_h_emp
			}
			set
			{
				if (temperature != value) {
					temperature = value;
					reg.SetValue("themp", value.ToString());

					this.form.setCounts(getFilteredCount(), files.Count);
				}
			}
		}

		private int? tempRange;

		public int TemperatureRange
		{
			get
			{
				return tempRange ?? (tempRange = Convert.ToInt32(reg.GetValue("thempRange", 2))) ?? 2; //TODO: fix typo t_h_empRange
			}
			set
			{
				if (tempRange != value) {
					tempRange = value;
					reg.SetValue("thempRange", value.ToString());

					this.form.setCounts(getFilteredCount(), files.Count);
				}
			}
		}

		private int? count;

		public int Count
		{
			get
			{
				return count ?? (count = Convert.ToInt32(reg.GetValue("count", 10))) ?? 10;
			}
			set
			{
				if (count != value) {
					count = value;
					reg.SetValue("count", value.ToString());
				}
			}
		}

		#endregion



		#region engine

		/// <summary>
		/// Копировать найденные и отфильтрованные
		/// </summary>
		public void Copy()
		{
			if (Interlocked.Read(ref copyInProgress) != 0 && copyThread != null && copyThread.IsAlive) {
				copyThread.Abort();
			}

			Interlocked.Exchange(ref copyInProgress, 1);

			copyThread = new Thread(new ThreadStart(this.CopyThread))
			{
				IsBackground = true
			};
			copyThread.Start();
		}

		private void CopyThread()
		{
			try
			{
				// страшный замут для гарантированного предотвращения выпадания в осадок при изменении списка файлов
				List<string> filenames = new List<string>();
				bool isCloned = false;

				do {
					try {
						filenames.Clear();

						foreach (Dark.Base file in files) {
							if (
								(file.ISO == ISO) &&
								file.Exposure.InRange(new IntRange(Expose, ExposeRange)) &&
								file.Temperature.InRange(new IntRange(Temperature, TemperatureRange))
							) {
								filenames.Add(file.Filename);

								if (filenames.Count >= Count)
								{
									break;
								}
							}
						}

						isCloned = true;
					}
					catch (Exception ex) {
						// игнорируем ошибку "Коллекция была изменена; невозможно выполнить операцию перечисления.", ещё раз пройдём по списку
					}
				} while (!isCloned);


				int count = 0;

				foreach (string file in filenames) {

					string dst = Path.Combine(FolderOut, Path.GetFileName(file));

					if (!File.Exists(dst)) {
						File.Copy(file, dst);
						count++;
					}
				}

			}
			finally {
				Interlocked.Exchange(ref copyInProgress, 0);
			}

			// не будет отображено, если поток был убит
			System.Windows.Forms.MessageBox.Show("Скопировано файлов: "+ count);
		}


		public void Stop()
		{
			if (scanThread != null && scanThread.IsAlive) {
				scanThread.Abort();
			}

			if (copyThread != null && copyThread.IsAlive) {
				copyThread.Abort();
			}
		}


		/// <summary>
		/// Пройдусь по абрикосовой, посчитаю дарки и запишу в блокнотик :)
		/// (скан в folderIn всех известных типов файлов, сохранение в files)
		/// </summary>
		private void Scan()
		{
			if (Interlocked.Read(ref scanInProgress) != 0) {
				if (scanThread != null && scanThread.IsAlive) {
					scanThread.Abort();
				}
			}

			Interlocked.Exchange(ref scanInProgress, 1);

			scanThread = new Thread(new ThreadStart(this.ScanThread))
			{
				IsBackground = true
			};

			scanThread.Start();
		}

		private void ScanThread()
		{
			try
			{
				files.Clear();

				// TODO не только CR2, но и NEF, Сони-как-его и FIT
				string dir = FolderIn;

				if (Directory.Exists(dir)) {
					foreach (string filename in Directory.GetFiles(dir, "*.cr2", SearchOption.AllDirectories)) {
						Dark.Base file = new Dark.Raw.CR2(filename);

						if (file.IsDark()) {
							files.Add(file);

							this.form.setCounts(getFilteredCount(), files.Count); //TODO: make progress update asynchronous
						}
					}
				}
			}
			finally {
				Interlocked.Exchange(ref scanInProgress, 0);
			}
		}

		/// <summary>
		/// Сколько файлов отфильтровано по текущим критериям?
		/// </summary>
		/// <returns></returns>
		private int getFilteredCount()
		{
			// дублирование кода?
			return (from file in files
					where file.ISO == ISO
					where file.Exposure.InRange(new IntRange(Expose, ExposeRange))
					where file.Temperature.InRange(new IntRange(Temperature, TemperatureRange))
					select file
					).Count();
		}
		#endregion

	}
}
