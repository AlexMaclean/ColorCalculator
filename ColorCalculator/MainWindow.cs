using System;
using System.Collections.Generic;
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
        private Stack<Bitmap> PastImages { get; }

        public MainWindow()
        {
            PastImages = new Stack<Bitmap>();
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
            if (Image != null)
            {
                PastImages.Push(Image);
            }
            SetImage(new Bitmap(path));
            recalculateButton.Enabled = true;
        }

        private void SetImage(Bitmap image)
        {
            Image = image;
            pictureBox.Image = Image;
        }

        private void RecalculateButton_Click(object sender, EventArgs e)
        {
            recalculateButton.Enabled = false;
            var equ1 = DefaultString(equation1.Text, value1.Text.Substring(0, 1));
            var equ2 = DefaultString(equation2.Text, value2.Text.Substring(0, 1));
            var equ3 = DefaultString(equation3.Text, value3.Text.Substring(0, 1));
            var equ4 = DefaultString(equation4.Text, value4.Text.Substring(0, 1));
            ColorCalculator colorCalculator;
            try
            {
                colorCalculator = new ColorCalculator(equ1, equ2, equ3, equ4, comboBoxColor.Text.Equals("RGB"));
            }
            catch (Exception exception)
            {
                DisplayError(exception);
                recalculateButton.Enabled = true;
                return;
            }
            var threadCalc = new Thread(() => CalculateColor(colorCalculator));
            threadCalc.Start();
        }

        private static string DefaultString(string equation, string def)
        {
            return equation == "" ? def : equation;
        }

        private void CalculateColor(ColorCalculator colorCalculator)
        {
            Bitmap newImage;
            try
            {
                newImage = colorCalculator.GetRecolor(new Bitmap(Image), SetProgress);
            }
            catch (Exception exception)
            {
                RunUi(() =>
                {
                    DisplayError(exception);
                    recalculateButton.Enabled = true;
                });
                return;
            }
                
            RunUi(() =>
            {
                PastImages.Push(Image);
                SetImage(newImage);
                saveButton.Enabled = true;
                recalculateButton.Enabled = true;
                progressBar1.Value = 0;
            });
        }

        private void DisplayError(Exception e)
        {
            using (var err = new ErrorDlg(e.Message))
            {
                err.ShowDialog(this);
            }
        }

        private void SetProgress(int progressValue)
        {
            RunUi(() => progressBar1.Value = progressValue);
        }

        private void RunUi(Action a)
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

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    if (e.Control)
                    {
                        if(PastImages.Count > 0)
                        SetImage(PastImages.Pop());
                    }
                    break;
            }
        }
    }
}
