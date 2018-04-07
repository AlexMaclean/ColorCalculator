﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using ColorCalculator.Properties;

namespace ColorCalculator
{
    public partial class MainWindow : Form
    {
        public Bitmap Image { get; set; }
        public string ImagePath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetLableValues(true);
        }
 
        private void fileButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = Resources.All_Picture_Files,
                Title = Resources.Select_an_image
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileBox.Text = dlg.FileName;
                LoadImage(dlg.FileName);
            }
        }

        private void LoadImage(string path)
        {
            ImagePath = path;
            Image = new Bitmap(path);
            pictureBox.Image = Image;
            recalculateButton.Enabled = true;
        }

        private void RecalculateButton_Click(object sender, EventArgs e)
        {
            recalculateButton.Enabled = false;
            var colorCalculator = new ColorCalculator(equation1.Text, equation2.Text, equation3.Text, equation4.Text, comboBoxColor.Text.Equals("RGB"));
            var threadCalc = new Thread(() => CalculateColor(colorCalculator));
            threadCalc.Start();
        }

        private void CalculateColor(ColorCalculator colorCalculator)
        {
            var newImage = colorCalculator.GetRecolor(Image, SetProgress);

            RunUI(() =>
            {
                Image = newImage;
                pictureBox.Image = Image;
                saveButton.Enabled = true;
                recalculateButton.Enabled = true;
                progressBar1.Value = 0;
            });
        }

        private void SetProgress(int progressValue)
        {
            RunUI(() => progressBar1.Value = progressValue);
        }

        private void RunUI(Action a)
        {
            Invoke(a);
        }

        private void ColorFormatChanged(object sender, EventArgs e)
        {
            var colorFormat = comboBoxColor.Text.Equals("RGB");
            SetLableValues(colorFormat);
        }

        private void SetLableValues(bool rgb)
        {
            value1.Text = rgb ? "Red" : "Hue";
            value2.Text = rgb ? "Green" : "Saturation";
            value3.Text = rgb ? "Blue" : "Lightness";
            value4.Text = @"Alpha";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog
            {
                FileName = GetNewPath(ImagePath),
                Filter = Resources.PNG_files
            };
            if (save.ShowDialog() == DialogResult.OK)
            {
                Image.Save(save.FileName, ImageFormat.Png);
            }
        }

        public string GetNewPath(string oldPath)
        {
            var dot = oldPath.LastIndexOf(".", StringComparison.Ordinal);
            var slash = oldPath.LastIndexOf("\\", StringComparison.Ordinal);
            return $"{oldPath.Substring(slash + 1, dot - slash - 1)}(recolor).png";
        }
    }
}
