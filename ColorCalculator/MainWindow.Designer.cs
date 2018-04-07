namespace ColorCalculator
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.recalculateButton = new System.Windows.Forms.Button();
            this.equation4 = new System.Windows.Forms.TextBox();
            this.value4 = new System.Windows.Forms.Label();
            this.value3 = new System.Windows.Forms.Label();
            this.equation3 = new System.Windows.Forms.TextBox();
            this.value2 = new System.Windows.Forms.Label();
            this.equation2 = new System.Windows.Forms.TextBox();
            this.value1 = new System.Windows.Forms.Label();
            this.equation1 = new System.Windows.Forms.TextBox();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select an Image file:";
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(2, 21);
            this.fileBox.Margin = new System.Windows.Forms.Padding(2);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(244, 20);
            this.fileBox.TabIndex = 1;
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(250, 21);
            this.fileButton.Margin = new System.Windows.Forms.Padding(2);
            this.fileButton.MinimumSize = new System.Drawing.Size(40, 20);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(40, 20);
            this.fileButton.TabIndex = 2;
            this.fileButton.Text = "...";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(2, 47);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(288, 232);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // recalculateButton
            // 
            this.recalculateButton.Enabled = false;
            this.recalculateButton.Location = new System.Drawing.Point(2, 210);
            this.recalculateButton.Margin = new System.Windows.Forms.Padding(2);
            this.recalculateButton.Name = "recalculateButton";
            this.recalculateButton.Size = new System.Drawing.Size(144, 40);
            this.recalculateButton.TabIndex = 5;
            this.recalculateButton.Text = "Recalculate";
            this.recalculateButton.UseVisualStyleBackColor = true;
            this.recalculateButton.Click += new System.EventHandler(this.RecalculateButton_Click);
            // 
            // equation4
            // 
            this.equation4.Location = new System.Drawing.Point(66, 113);
            this.equation4.Name = "equation4";
            this.equation4.Size = new System.Drawing.Size(194, 20);
            this.equation4.TabIndex = 6;
            // 
            // value4
            // 
            this.value4.AutoSize = true;
            this.value4.Location = new System.Drawing.Point(10, 116);
            this.value4.Name = "value4";
            this.value4.Size = new System.Drawing.Size(43, 13);
            this.value4.TabIndex = 7;
            this.value4.Text = "Value 4";
            // 
            // value3
            // 
            this.value3.AutoSize = true;
            this.value3.Location = new System.Drawing.Point(10, 90);
            this.value3.Name = "value3";
            this.value3.Size = new System.Drawing.Size(43, 13);
            this.value3.TabIndex = 9;
            this.value3.Text = "Value 3";
            // 
            // equation3
            // 
            this.equation3.Location = new System.Drawing.Point(66, 87);
            this.equation3.Name = "equation3";
            this.equation3.Size = new System.Drawing.Size(194, 20);
            this.equation3.TabIndex = 8;
            // 
            // value2
            // 
            this.value2.AutoSize = true;
            this.value2.Location = new System.Drawing.Point(10, 64);
            this.value2.Name = "value2";
            this.value2.Size = new System.Drawing.Size(43, 13);
            this.value2.TabIndex = 11;
            this.value2.Text = "Value 2";
            // 
            // equation2
            // 
            this.equation2.Location = new System.Drawing.Point(66, 61);
            this.equation2.Name = "equation2";
            this.equation2.Size = new System.Drawing.Size(194, 20);
            this.equation2.TabIndex = 10;
            // 
            // value1
            // 
            this.value1.AutoSize = true;
            this.value1.Location = new System.Drawing.Point(10, 38);
            this.value1.Name = "value1";
            this.value1.Size = new System.Drawing.Size(43, 13);
            this.value1.TabIndex = 13;
            this.value1.Text = "Value 1";
            // 
            // equation1
            // 
            this.equation1.Location = new System.Drawing.Point(66, 35);
            this.equation1.Name = "equation1";
            this.equation1.Size = new System.Drawing.Size(194, 20);
            this.equation1.TabIndex = 12;
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "RGB",
            "HSL"});
            this.comboBoxColor.Location = new System.Drawing.Point(158, 18);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(53, 21);
            this.comboBoxColor.TabIndex = 14;
            this.comboBoxColor.Text = "RGB";
            this.comboBoxColor.SelectedIndexChanged += new System.EventHandler(this.ColorFormatChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Color Format";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.equation1);
            this.groupBox1.Controls.Add(this.equation4);
            this.groupBox1.Controls.Add(this.value4);
            this.groupBox1.Controls.Add(this.value1);
            this.groupBox1.Controls.Add(this.equation3);
            this.groupBox1.Controls.Add(this.value3);
            this.groupBox1.Controls.Add(this.value2);
            this.groupBox1.Controls.Add(this.equation2);
            this.groupBox1.Location = new System.Drawing.Point(3, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 158);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Equations";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(7, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.fileBox);
            this.splitContainer1.Panel1.Controls.Add(this.fileButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.saveButton);
            this.splitContainer1.Panel2.Controls.Add(this.recalculateButton);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxColor);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(580, 281);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 17;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(3, 255);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(142, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(150, 210);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(131, 69);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 291);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(608, 330);
            this.MinimumSize = new System.Drawing.Size(608, 330);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.Text = "Color Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileBox;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button recalculateButton;
        private System.Windows.Forms.TextBox equation4;
        private System.Windows.Forms.Label value4;
        private System.Windows.Forms.Label value3;
        private System.Windows.Forms.TextBox equation3;
        private System.Windows.Forms.Label value2;
        private System.Windows.Forms.TextBox equation2;
        private System.Windows.Forms.Label value1;
        private System.Windows.Forms.TextBox equation1;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

