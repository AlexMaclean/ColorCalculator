using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SteganographyEngine
{
    public partial class Form1 : Form
    {
        private Steganography steganography;
        private string imagePath;
        private string Preambel = "zzz";
        public Form1()
        {
            steganography = new Steganography(Preambel);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

 
        private void fileButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "All Picture Files (*.bmp, *.jpg, *.jpeg, *.png, *.ico, *.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.ico;*.gif";
            dlg.Title = "Select an image to encrypt or decrypt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileBox.Text = dlg.FileName;
                setThingsUp(dlg.FileName);
            }
        }

        private void setThingsUp(string path)
        {
            imagePath = path;
            var image = new Bitmap(path);
            pictureBox.Image = image;
            encryptButton.Enabled = decryptButton.Enabled = true;
            textBox.Enabled = charCount.Enabled  = true;
            int maxChars = (image.Width*image.Height)/3 - (1 + Preambel.Length);
            textBox.MaxLength = maxChars;
            charCount.Text = "0/" + maxChars;
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            var newImage =  steganography.EncryptImage(imagePath,textBox.Text);
            textBox.Text = "";
            var save = new SaveFileDialog
            {
                FileName = steganography.GetNewPath(imagePath),
                Filter = "PNG files (*.png)|*.png"
            };
            if (save.ShowDialog() == DialogResult.OK)
            {
                newImage.Save(save.FileName,ImageFormat.Png);
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            var info = steganography.DecryptImage(imagePath);
            textBox.Text = info;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            charCount.Text = String.Format("{0}/{1}",textBox.Text.Length,textBox.MaxLength);
        }
    }
}
