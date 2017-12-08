/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 30.11.2017
 * Time: 21:27
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DarkSorter
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{

		private DarkSorter sorter;


		public MainForm()
		{
			InitializeComponent();
		}

		void MainFormShown(object sender, EventArgs e)
		{
			sorter = new DarkSorter(this);
			setDefaults();
		}

		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			sorter.Stop();
		}


		/// <summary>
		/// Установка значений по-умолчанию или из регистри
		/// </summary>
		private void setDefaults()
		{
			switch (sorter.ISO) {
				case 100:
					iso100.Checked = true;
					break;

				case 200:
					iso200.Checked = true;
					break;

				case 400:
					iso400.Checked = true;
					break;

				case 800:
					iso800.Checked = true;
					break;

				case 1600:
					iso1600.Checked = true;
					break;
			}

			folderBrowserIn.SelectedPath = sorter.FolderIn;
			folderInText.Text = folderBrowserIn.SelectedPath;

			folderBrowserOut.SelectedPath = sorter.FolderOut;
			folderOutText.Text = folderBrowserOut.SelectedPath;

			expose.Value = sorter.Expose;
			exposeRange.Value = sorter.ExposeRange;

			themp.Minimum = -99;
			themp.Value = sorter.Temperature;
			thempRange.Value = sorter.TemperatureRange;

			count.Value = sorter.Count;
		}


		void ButtonGoClick(object sender, EventArgs e)
		{
			sorter.Copy();
		}


		#region ISO
		//TODO: Объединить обработчики.
		// событие вызывается дважды: при сбросе и при установке переключателя
		void Iso100CheckedChanged(object sender, EventArgs e)
		{
			if (iso100.Checked) {
				sorter.ISO = 100;
			}
		}

		void Iso200CheckedChanged(object sender, EventArgs e)
		{
			if (iso200.Checked) {
				sorter.ISO = 200;
			}
		}

		void Iso400CheckedChanged(object sender, EventArgs e)
		{
			if (iso400.Checked) {
				sorter.ISO = 400;
			}
		}

		void Iso800CheckedChanged(object sender, EventArgs e)
		{
			if (iso800.Checked) {
				sorter.ISO = 800;
			}
		}

		void Iso1600CheckedChanged(object sender, EventArgs e)
		{
			if (iso1600.Checked) {
				sorter.ISO = 1600;
			}
		}

		#endregion

		void FolderInButtonClick(object sender, EventArgs e)
		{
			if (folderBrowserIn.ShowDialog() == DialogResult.OK) {
				folderInText.Text = folderBrowserIn.SelectedPath;
				sorter.FolderIn = folderBrowserIn.SelectedPath;
			}
		}

		void FolderInTextTextValidating(object sender, CancelEventArgs e)
		{
			if (!Directory.Exists(folderInText.Text)) {
				e.Cancel = true;
			}
		}

		void FolderInTextTextChanged(object sender, EventArgs e)
		{
			sorter.FolderIn = folderInText.Text;
		}

		void FolderOutButtonClick(object sender, EventArgs e)
		{
			if (folderBrowserOut.ShowDialog() == DialogResult.OK) {
				folderOutText.Text = folderBrowserOut.SelectedPath;
				sorter.FolderOut = folderBrowserOut.SelectedPath;
			}
		}

		void FolderOutTextTextChanged(object sender, EventArgs e)
		{
			sorter.FolderOut = folderOutText.Text;
		}

		void FolderOutTextTextValidating(object sender, CancelEventArgs e)
		{
			if (!Directory.Exists(folderOutText.Text)) {
				e.Cancel = true;
			}
		}


		void ExposeValueChanged(object sender, EventArgs e)
		{
			sorter.Expose = Convert.ToInt32(expose.Value);
		}

		void ExposeRangeValueChanged(object sender, EventArgs e)
		{
			sorter.ExposeRange = Convert.ToInt32(exposeRange.Value);
		}

		void ThempValueChanged(object sender, EventArgs e)
		{
			sorter.Temperature = Convert.ToInt32(themp.Value);
		}

		void ThempRangeValueChanged(object sender, EventArgs e)
		{
			sorter.TemperatureRange = Convert.ToInt32(thempRange.Value);
		}

		void CountValueChanged(object sender, EventArgs e)
		{
			sorter.Count = Convert.ToInt32(count.Value);
		}

		/// <summary>
		/// Отображение счётчиков из других потоков.
		/// Например, из скана
		/// </summary>
		/// <param name="filtered"></param>
		/// <param name="total"></param>
		public void setCounts(int filtered, int total)
		{
			// Здесь утечка ресурсов. Обновление нужно сделать полностью асинхронным.
			var result = labelCount.BeginInvoke((MethodInvoker)(() =>
				labelCount.Text =
					filtered.ToString() +
					" из "+
					total.ToString() +
					" шт."
			));
		}

	}
}
