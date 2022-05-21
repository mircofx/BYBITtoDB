namespace FTXtoDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbResolutions = new ReaLTaiizor.Controls.CrownComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTickers = new ReaLTaiizor.Controls.CrownComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnParseDate = new System.Windows.Forms.Button();
            this.crownNumeric1 = new ReaLTaiizor.Controls.CrownNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnParseAll = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.locateDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.crownNumeric1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbResolutions
            // 
            this.cbResolutions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbResolutions.FormattingEnabled = true;
            this.cbResolutions.Location = new System.Drawing.Point(571, 87);
            this.cbResolutions.Name = "cbResolutions";
            this.cbResolutions.Size = new System.Drawing.Size(63, 24);
            this.cbResolutions.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(571, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Resolution";
            // 
            // cbTickers
            // 
            this.cbTickers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbTickers.FormattingEnabled = true;
            this.cbTickers.Location = new System.Drawing.Point(21, 87);
            this.cbTickers.Name = "cbTickers";
            this.cbTickers.Size = new System.Drawing.Size(137, 24);
            this.cbTickers.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(282, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(205, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // btnParseDate
            // 
            this.btnParseDate.BackColor = System.Drawing.Color.LightSalmon;
            this.btnParseDate.Location = new System.Drawing.Point(630, 233);
            this.btnParseDate.Name = "btnParseDate";
            this.btnParseDate.Size = new System.Drawing.Size(131, 23);
            this.btnParseDate.TabIndex = 8;
            this.btnParseDate.Text = "Parse from date";
            this.btnParseDate.UseVisualStyleBackColor = false;
            this.btnParseDate.Click += new System.EventHandler(this.btnParseDate_Click);
            // 
            // crownNumeric1
            // 
            this.crownNumeric1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.crownNumeric1.Location = new System.Drawing.Point(683, 87);
            this.crownNumeric1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.crownNumeric1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.crownNumeric1.Name = "crownNumeric1";
            this.crownNumeric1.Size = new System.Drawing.Size(88, 25);
            this.crownNumeric1.TabIndex = 9;
            this.crownNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.crownNumeric1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.crownNumeric1.ValueChanged += new System.EventHandler(this.crownNumeric1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(683, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(21, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Instrument";
            // 
            // btnParseAll
            // 
            this.btnParseAll.BackColor = System.Drawing.Color.Lime;
            this.btnParseAll.Location = new System.Drawing.Point(356, 233);
            this.btnParseAll.Name = "btnParseAll";
            this.btnParseAll.Size = new System.Drawing.Size(131, 23);
            this.btnParseAll.TabIndex = 12;
            this.btnParseAll.Text = "Parse all";
            this.btnParseAll.UseVisualStyleBackColor = false;
            this.btnParseAll.Click += new System.EventHandler(this.btnParseAll_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 182);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(750, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.labelProgress.Location = new System.Drawing.Point(373, 148);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(68, 15);
            this.labelProgress.TabIndex = 14;
            this.labelProgress.Text = "Progress: %";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locateDatabaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // locateDatabaseToolStripMenuItem
            // 
            this.locateDatabaseToolStripMenuItem.Name = "locateDatabaseToolStripMenuItem";
            this.locateDatabaseToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.locateDatabaseToolStripMenuItem.Text = "Locate database";
            this.locateDatabaseToolStripMenuItem.Click += new System.EventHandler(this.locateDatabaseToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gold;
            this.button3.Location = new System.Drawing.Point(493, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Click me";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(282, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Date";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 278);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnParseAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.crownNumeric1);
            this.Controls.Add(this.btnParseDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbTickers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbResolutions);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "FTX to Database Tool";
            ((System.ComponentModel.ISupportInitialize)(this.crownNumeric1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.CrownComboBox crownComboBox1;
        private ReaLTaiizor.Controls.CrownComboBox cbResolutions;
        private Label label1;
        private Label label2;
        private ReaLTaiizor.Controls.CrownComboBox cbTickers;
        private DateTimePicker dateTimePicker1;
        private Button btnParseDate;
        private ReaLTaiizor.Controls.CrownNumeric crownNumeric1;
        private Label label3;
        private Label label4;
        private Button btnParseAll;
        private ProgressBar progressBar1;
        private Label labelProgress;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem locateDatabaseToolStripMenuItem;
        private Button button3;
    }
}