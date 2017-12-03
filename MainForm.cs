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
using System.Drawing;
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
			switch (sorter.getIso()) {
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
			
			folderBrowserIn.SelectedPath = sorter.getFolderIn();
			folderInText.Text = folderBrowserIn.SelectedPath;
			
			folderBrowserOut.SelectedPath = sorter.getFolderOut();
			folderOutText.Text = folderBrowserOut.SelectedPath;
			
			expose.Value = sorter.getExpose();
			exposeRange.Value = sorter.getExposeRange();
			
			themp.Minimum = -99;
			themp.Value = sorter.getThemp();
			thempRange.Value = sorter.getThempRange();
			
			count.Value = sorter.getCount();
		}
		
		
		void ButtonGoClick(object sender, EventArgs e)
		{
			sorter.Copy();
		}
		
		
		void Iso100CheckedChanged(object sender, EventArgs e)
		{
			sorter.setIso(100);
		}
		void Iso200CheckedChanged(object sender, EventArgs e)
		{
			sorter.setIso(200);
		}
		void Iso400CheckedChanged(object sender, EventArgs e)
		{
			sorter.setIso(400);
		}
		void Iso800CheckedChanged(object sender, EventArgs e)
		{
			sorter.setIso(800);
		}
		void Iso1600CheckedChanged(object sender, EventArgs e)
		{
			sorter.setIso(1600);
		}
		
		

		void FolderInButtonClick(object sender, EventArgs e)
		{
			if (folderBrowserIn.ShowDialog() == DialogResult.OK) {
				folderInText.Text = folderBrowserIn.SelectedPath;
				sorter.setFolderIn(folderBrowserIn.SelectedPath);
			}
		}
		void FolderInTextTextChanged(object sender, EventArgs e)
		{
			sorter.setFolderIn(folderInText.Text);
		}

		void FolderOutButtonClick(object sender, EventArgs e)
		{
			if (folderBrowserOut.ShowDialog() == DialogResult.OK) {
				folderOutText.Text = folderBrowserOut.SelectedPath;
				sorter.setFolderOut(folderBrowserOut.SelectedPath);
			}
		}
		
		void FolderOutTextTextChanged(object sender, EventArgs e)
		{
			sorter.setFolderOut(folderOutText.Text);
		}
		
		
		void ExposeValueChanged(object sender, EventArgs e)
		{
			sorter.setExpose(Convert.ToInt32(expose.Value));
		}
		void ExposeRangeValueChanged(object sender, EventArgs e)
		{
			sorter.setExposeRange(Convert.ToInt32(exposeRange.Value));
		}
		
		
		void ThempValueChanged(object sender, EventArgs e)
		{
			sorter.setThemp(Convert.ToInt32(themp.Value));
		}
		void ThempRangeValueChanged(object sender, EventArgs e)
		{
			sorter.setThempRange(Convert.ToInt32(thempRange.Value));
		}
		
		
		void CountValueChanged(object sender, EventArgs e)
		{
			sorter.setCount(Convert.ToInt32(count.Value));
		}		


		/// <summary>
		/// Отображение счётчиков из других потоков.
		/// Например, из скана
		/// </summary>
		/// <param name="filtered"></param>
		/// <param name="total"></param>
		public void setCounts(int filtered, int total)
		{
			labelCount.BeginInvoke((MethodInvoker)(() => 
				labelCount.Text =
					filtered.ToString() +
					" из "+
					total.ToString() +
					" шт."
			));
		}
		
	}
}
