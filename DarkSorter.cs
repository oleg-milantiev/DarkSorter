/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 01.12.2017
 * Time: 18:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Collections.Generic;
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
		private bool scanInProgress = false;
		
		/// <summary>
		/// Для асинхронного сканирования дарков
		/// </summary>
		private Thread scanThread;
		
		/// <summary>
		/// Сейчас идёт копирование выбранных дарков?
		/// </summary>
		private bool copyInProgress = false;
		
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
			
			reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\mo\\DarkSorter");
			Scan();
		}
		
		
		#region get/set
		
		public void setIso(int iso)
		{
			reg.SetValue("ISO", iso.ToString());
			this.form.setCounts(getFilteredCount(), files.Count);
		}
		public int getIso()
		{
			return Convert.ToInt32(reg.GetValue("ISO", "200"));
		}
			
		
		public void setFolderIn(string folder)
		{
			reg.SetValue("FolderIn", folder);
			Scan();
		}
		public string getFolderIn()
		{
			return reg.GetValue("FolderIn", "").ToString();
		}
		
		public void setFolderOut(string folder)
		{
			reg.SetValue("FolderOut", folder);
		}
		public string getFolderOut()
		{
			return reg.GetValue("FolderOut", "").ToString();
		}
		
		
		public int getExpose()
		{
			return Convert.ToInt32(reg.GetValue("expose", 600));
		}
		public void setExpose(int expose)
		{
			reg.SetValue("expose", expose.ToString());
			this.form.setCounts(getFilteredCount(), files.Count);
		}
		
		public int getExposeRange()
		{
			return Convert.ToInt32(reg.GetValue("exposeRange", 10));
		}
		public void setExposeRange(int range)
		{
			reg.SetValue("exposeRange", range.ToString());
			this.form.setCounts(getFilteredCount(), files.Count);
		}
			
		public int getThemp()
		{
			return Convert.ToInt32(reg.GetValue("themp", -10));
		}
		public void setThemp(int themp)
		{
			reg.SetValue("themp", themp.ToString());
			this.form.setCounts(getFilteredCount(), files.Count);
		}
		
		public int getThempRange()
		{
			return Convert.ToInt32(reg.GetValue("thempRange", 2));
		}
		public void setThempRange(int range)
		{
			reg.SetValue("thempRange", range.ToString());
			this.form.setCounts(getFilteredCount(), files.Count);
		}
			
		public int getCount()
		{
			return Convert.ToInt32(reg.GetValue("count", 10));
		}
		public void setCount(int count)
		{
			reg.SetValue("count", count.ToString());
		}

		#endregion
	

		
		#region engine
		
		/// <summary>
		/// Копировать найденные и отфильтрованные
		/// </summary>
		public void Copy()
		{
			if (copyInProgress) {
				copyThread.Abort();
			}
			
			copyInProgress = true;
			
			copyThread = new Thread(new ThreadStart(this.CopyThread));
			copyThread.Start();
		}
		
		private void CopyThread()
		{
			// страшный замут для гарантированного предотвращения выпадания в осадок при изменении списка файлов 
			List<string> filenames = new List<string>();
			bool isCloned = false;
			
			do {
				try {
					filenames.Clear();
					
					foreach (Dark.Base file in files) {
						if (
							(file.getISO() == getIso()) && 
							inRange(file.getExposure(), getExpose(), getExposeRange()) &&
							inRange(file.getTemperature(), getThemp(), getThempRange())
						) {

							filenames.Add( file.getFilename() );
							
							if (filenames.Count >= getCount()) {
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
					
				string dst = getFolderOut() +@"\"+ Path.GetFileName(file);
				
				if (!File.Exists(dst)) {
					File.Copy(file, dst);
					count++;
				}
			}
			
			copyInProgress = false;
			
			System.Windows.Forms.MessageBox.Show("Скопировано файлов: "+ count);
		}
		

		public void Stop()
		{
			if (scanThread != null) {
				scanThread.Abort();
			}
			if (copyThread != null) {
				copyThread.Abort();
			}
		}

		
		/// <summary>
		/// Пройдусь по абрикосовой, посчитаю дарки и запишу в блокнотик :)
		/// (скан в folderIn всех известных типов файлов, сохранение в files)
		/// </summary>
		private void Scan()
		{
			if (scanInProgress) {
				scanThread.Abort();
			}
			
			scanInProgress = true;
			
			scanThread = new Thread(new ThreadStart(this.ScanThread));
			scanThread.Start();
		}
		
		private void ScanThread()
		{
			files.Clear();
			
			// TODO не только CR2, но и NEF, Сони-как-его и FIT
			string dir = getFolderIn();
			
			if (Directory.Exists(dir)) {
				foreach (string filename in System.IO.Directory.GetFiles(dir, "*.cr2", SearchOption.AllDirectories)) {
					Dark.Base file = new Dark.Raw.CR2(filename);
					
					if (file.isDark()) {
						files.Add(file);
						
						this.form.setCounts(getFilteredCount(), files.Count);
					}
				}
			}
			
			scanInProgress = false;
		}
		
		
		/// <summary>
		/// Сколько файлов отфильтровано по текущим критериям?
		/// </summary>
		/// <returns></returns>
		private int getFilteredCount()
		{
			int ret = 0;
			
			foreach (Dark.Base file in files) {
				if (
					(file.getISO() == getIso()) && // TODO каждый раз из регистри? А не жёстко ли?
					inRange(file.getExposure(), getExpose(), getExposeRange()) &&
					inRange(file.getTemperature(), getThemp(), getThempRange())
				) {
					ret++;
				}				
			}
			
			return ret;
		}
		
		
		/// <summary>
		/// Находится ли val в seek +-range?
		/// </summary>
		/// <param name="val"></param>
		/// <param name="seek"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		private bool inRange(int val, int seek, int range)
		{
			return (
				(val >= seek - range / 2) &&
				(val <= seek + range / 2)
			);
		}
		
		
		
		#endregion	
		
	}
}
