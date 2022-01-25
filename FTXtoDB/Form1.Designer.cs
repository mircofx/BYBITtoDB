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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbTickers = new ReaLTaiizor.Controls.CrownComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.crownNumeric1 = new ReaLTaiizor.Controls.CrownNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.crownNumeric1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbResolutions
            // 
            this.cbResolutions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbResolutions.FormattingEnabled = true;
            this.cbResolutions.Location = new System.Drawing.Point(592, 87);
            this.cbResolutions.Name = "cbResolutions";
            this.cbResolutions.Size = new System.Drawing.Size(63, 24);
            this.cbResolutions.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(592, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Resolution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(21, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path to local db:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 154);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(512, 23);
            this.textBox1.TabIndex = 5;
            // 
            // cbTickers
            // 
            this.cbTickers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbTickers.FormattingEnabled = true;
            this.cbTickers.Location = new System.Drawing.Point(422, 87);
            this.cbTickers.Name = "cbTickers";
            this.cbTickers.Size = new System.Drawing.Size(137, 24);
            this.cbTickers.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(205, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(683, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "PARSE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.label4.Location = new System.Drawing.Point(422, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Instrument";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(592, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "PARSE ALL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 327);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(750, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.labelProgress.Location = new System.Drawing.Point(363, 294);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(68, 15);
            this.labelProgress.TabIndex = 14;
            this.labelProgress.Text = "Progress: %";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.crownNumeric1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbTickers);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbResolutions);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "FTX to Database Tool";
            ((System.ComponentModel.ISupportInitialize)(this.crownNumeric1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.CrownComboBox crownComboBox1;
        private ReaLTaiizor.Controls.CrownComboBox cbResolutions;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private ReaLTaiizor.Controls.CrownComboBox cbTickers;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private ReaLTaiizor.Controls.CrownNumeric crownNumeric1;
        private Label label3;
        private Label label4;
        private Button button2;
        private ProgressBar progressBar1;
        private Label labelProgress;
    }
}