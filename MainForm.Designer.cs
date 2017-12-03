/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 30.11.2017
 * Time: 21:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DarkSorter
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserIn;
		private System.Windows.Forms.TextBox folderInText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button folderInButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonGo;
		private System.Windows.Forms.Button folderOutButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox folderOutText;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown exposeRange;
		private System.Windows.Forms.NumericUpDown expose;
		private System.Windows.Forms.NumericUpDown thempRange;
		private System.Windows.Forms.NumericUpDown themp;
		private System.Windows.Forms.NumericUpDown count;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserOut;
		private System.Windows.Forms.RadioButton iso1600;
		private System.Windows.Forms.RadioButton iso400;
		private System.Windows.Forms.RadioButton iso800;
		private System.Windows.Forms.RadioButton iso100;
		private System.Windows.Forms.RadioButton iso200;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.Timer timerRescan;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserIn = new System.Windows.Forms.FolderBrowserDialog();
			this.folderInText = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.folderInButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.iso1600 = new System.Windows.Forms.RadioButton();
			this.iso400 = new System.Windows.Forms.RadioButton();
			this.iso800 = new System.Windows.Forms.RadioButton();
			this.iso100 = new System.Windows.Forms.RadioButton();
			this.iso200 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.exposeRange = new System.Windows.Forms.NumericUpDown();
			this.expose = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.thempRange = new System.Windows.Forms.NumericUpDown();
			this.themp = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonGo = new System.Windows.Forms.Button();
			this.folderOutButton = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.folderOutText = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.count = new System.Windows.Forms.NumericUpDown();
			this.folderBrowserOut = new System.Windows.Forms.FolderBrowserDialog();
			this.label10 = new System.Windows.Forms.Label();
			this.labelCount = new System.Windows.Forms.Label();
			this.timerRescan = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.exposeRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.expose)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.thempRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.themp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(248, 273);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(219, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "(Copyleft) 2017, Oleg Milantiev";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// folderInText
			// 
			this.folderInText.Location = new System.Drawing.Point(207, 61);
			this.folderInText.Name = "folderInText";
			this.folderInText.Size = new System.Drawing.Size(180, 22);
			this.folderInText.TabIndex = 1;
			this.folderInText.TextChanged += new System.EventHandler(this.FolderInTextTextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(456, 45);
			this.label2.TabIndex = 2;
			this.label2.Text = "Из кучи равов программа выбирает нужные по ISO / времени экспозиции / температуре" +
	". Выбирает свежие файлы.";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(207, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Папка с исходными равами:";
			// 
			// folderInButton
			// 
			this.folderInButton.Location = new System.Drawing.Point(393, 61);
			this.folderInButton.Name = "folderInButton";
			this.folderInButton.Size = new System.Drawing.Size(75, 23);
			this.folderInButton.TabIndex = 4;
			this.folderInButton.Text = "Выбрать";
			this.folderInButton.UseVisualStyleBackColor = true;
			this.folderInButton.Click += new System.EventHandler(this.FolderInButtonClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.iso1600);
			this.groupBox1.Controls.Add(this.iso400);
			this.groupBox1.Controls.Add(this.iso800);
			this.groupBox1.Controls.Add(this.iso100);
			this.groupBox1.Controls.Add(this.iso200);
			this.groupBox1.Location = new System.Drawing.Point(12, 90);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(94, 135);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ISO";
			// 
			// iso1600
			// 
			this.iso1600.Location = new System.Drawing.Point(6, 106);
			this.iso1600.Name = "iso1600";
			this.iso1600.Size = new System.Drawing.Size(88, 24);
			this.iso1600.TabIndex = 11;
			this.iso1600.TabStop = true;
			this.iso1600.Text = "1600";
			this.iso1600.UseVisualStyleBackColor = true;
			this.iso1600.CheckedChanged += new System.EventHandler(this.Iso1600CheckedChanged);
			// 
			// iso400
			// 
			this.iso400.Location = new System.Drawing.Point(6, 62);
			this.iso400.Name = "iso400";
			this.iso400.Size = new System.Drawing.Size(88, 24);
			this.iso400.TabIndex = 10;
			this.iso400.TabStop = true;
			this.iso400.Text = "400";
			this.iso400.UseVisualStyleBackColor = true;
			this.iso400.CheckedChanged += new System.EventHandler(this.Iso400CheckedChanged);
			// 
			// iso800
			// 
			this.iso800.Location = new System.Drawing.Point(6, 84);
			this.iso800.Name = "iso800";
			this.iso800.Size = new System.Drawing.Size(88, 24);
			this.iso800.TabIndex = 9;
			this.iso800.TabStop = true;
			this.iso800.Text = "800";
			this.iso800.UseVisualStyleBackColor = true;
			this.iso800.CheckedChanged += new System.EventHandler(this.Iso800CheckedChanged);
			// 
			// iso100
			// 
			this.iso100.Location = new System.Drawing.Point(6, 18);
			this.iso100.Name = "iso100";
			this.iso100.Size = new System.Drawing.Size(88, 24);
			this.iso100.TabIndex = 8;
			this.iso100.TabStop = true;
			this.iso100.Text = "100";
			this.iso100.UseVisualStyleBackColor = true;
			this.iso100.CheckedChanged += new System.EventHandler(this.Iso100CheckedChanged);
			// 
			// iso200
			// 
			this.iso200.Location = new System.Drawing.Point(6, 40);
			this.iso200.Name = "iso200";
			this.iso200.Size = new System.Drawing.Size(88, 24);
			this.iso200.TabIndex = 7;
			this.iso200.TabStop = true;
			this.iso200.Text = "200";
			this.iso200.UseVisualStyleBackColor = true;
			this.iso200.CheckedChanged += new System.EventHandler(this.Iso200CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.exposeRange);
			this.groupBox2.Controls.Add(this.expose);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(112, 90);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(117, 135);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Экспозиция";
			// 
			// exposeRange
			// 
			this.exposeRange.Location = new System.Drawing.Point(7, 97);
			this.exposeRange.Name = "exposeRange";
			this.exposeRange.Size = new System.Drawing.Size(99, 22);
			this.exposeRange.TabIndex = 12;
			this.exposeRange.Value = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.exposeRange.ValueChanged += new System.EventHandler(this.ExposeRangeValueChanged);
			// 
			// expose
			// 
			this.expose.Location = new System.Drawing.Point(6, 46);
			this.expose.Maximum = new decimal(new int[] {
			10000,
			0,
			0,
			0});
			this.expose.Name = "expose";
			this.expose.Size = new System.Drawing.Size(101, 22);
			this.expose.TabIndex = 11;
			this.expose.Value = new decimal(new int[] {
			600,
			0,
			0,
			0});
			this.expose.ValueChanged += new System.EventHandler(this.ExposeValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "выдержка";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "разброс";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.thempRange);
			this.groupBox3.Controls.Add(this.themp);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Location = new System.Drawing.Point(235, 89);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(117, 135);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Температура";
			// 
			// thempRange
			// 
			this.thempRange.Location = new System.Drawing.Point(5, 98);
			this.thempRange.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.thempRange.Name = "thempRange";
			this.thempRange.Size = new System.Drawing.Size(101, 22);
			this.thempRange.TabIndex = 14;
			this.thempRange.Value = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.thempRange.ValueChanged += new System.EventHandler(this.ThempRangeValueChanged);
			// 
			// themp
			// 
			this.themp.Location = new System.Drawing.Point(5, 47);
			this.themp.Maximum = new decimal(new int[] {
			99,
			0,
			0,
			0});
			this.themp.Minimum = new decimal(new int[] {
			99,
			0,
			0,
			0});
			this.themp.Name = "themp";
			this.themp.Size = new System.Drawing.Size(101, 22);
			this.themp.TabIndex = 13;
			this.themp.Value = new decimal(new int[] {
			99,
			0,
			0,
			0});
			this.themp.ValueChanged += new System.EventHandler(this.ThempValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "°С";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 9;
			this.label7.Text = "разброс";
			// 
			// buttonGo
			// 
			this.buttonGo.Location = new System.Drawing.Point(357, 174);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new System.Drawing.Size(110, 36);
			this.buttonGo.TabIndex = 12;
			this.buttonGo.Text = "Скопируй";
			this.buttonGo.UseVisualStyleBackColor = true;
			this.buttonGo.Click += new System.EventHandler(this.ButtonGoClick);
			// 
			// folderOutButton
			// 
			this.folderOutButton.Location = new System.Drawing.Point(393, 227);
			this.folderOutButton.Name = "folderOutButton";
			this.folderOutButton.Size = new System.Drawing.Size(75, 23);
			this.folderOutButton.TabIndex = 16;
			this.folderOutButton.Text = "Выбрать";
			this.folderOutButton.UseVisualStyleBackColor = true;
			this.folderOutButton.Click += new System.EventHandler(this.FolderOutButtonClick);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 230);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(207, 23);
			this.label8.TabIndex = 15;
			this.label8.Text = "Папка-получатель";
			// 
			// folderOutText
			// 
			this.folderOutText.Location = new System.Drawing.Point(156, 227);
			this.folderOutText.Name = "folderOutText";
			this.folderOutText.Size = new System.Drawing.Size(231, 22);
			this.folderOutText.TabIndex = 14;
			this.folderOutText.TextChanged += new System.EventHandler(this.FolderOutTextTextChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(358, 90);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(121, 23);
			this.label9.TabIndex = 11;
			this.label9.Text = "Кол-во файлов:";
			// 
			// count
			// 
			this.count.Location = new System.Drawing.Point(410, 116);
			this.count.Maximum = new decimal(new int[] {
			999,
			0,
			0,
			0});
			this.count.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.count.Name = "count";
			this.count.Size = new System.Drawing.Size(57, 22);
			this.count.TabIndex = 15;
			this.count.Value = new decimal(new int[] {
			20,
			0,
			0,
			0});
			this.count.ValueChanged += new System.EventHandler(this.CountValueChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(358, 118);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 17;
			this.label10.Text = "хочу";
			// 
			// labelCount
			// 
			this.labelCount.Location = new System.Drawing.Point(358, 148);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(100, 23);
			this.labelCount.TabIndex = 18;
			this.labelCount.Text = "0 из 0 шт.";
			// 
			// timerRescan
			// 
			this.timerRescan.Interval = 1000;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(481, 303);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.count);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.folderInText);
			this.Controls.Add(this.folderOutText);
			this.Controls.Add(this.folderOutButton);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.buttonGo);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.folderInButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "DarkSorter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.exposeRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.expose)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.thempRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.themp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
