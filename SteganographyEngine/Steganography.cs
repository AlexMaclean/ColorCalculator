using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace SteganographyEngine
{
    public class PixelOutOfRangeException : Exception
    {
        public override string Message
        {
            get
            {
                return "x or y out of range of image size";
            }
        }
    }
    public class Steganography
    {
        string Preamble = String.Empty;
        public Steganography(string preamble)
        {
            Preamble = preamble;
        }
        public Bitmap EncryptImage(string imagePath, string text)
        {
            var image = new Bitmap(imagePath, true);
            text = Preamble + text;
            for (int i = 0; i <= text.Length; i++) {
                byte b = (byte)((i == text.Length) ? 0x00 : BitConverter.GetBytes(text[i])[0]);
                bool b1 = GetBit(b, 1);
                bool b2 = GetBit(b, 2);
                bool b3 = GetBit(b, 3);
                bool b4 = GetBit(b, 4);
                bool b5 = GetBit(b, 5);
                bool b6 = GetBit(b, 6);
                bool b7 = GetBit(b, 7);
                bool b8 = GetBit(b, 8);
                ModifyPixel(image, i * 3, b1, b2, b3);
                ModifyPixel(image, i * 3 + 1, b4, b5, b6);
                ModifyPixel(image, i * 3 + 2, b7, b8, false);
            }

            return image;
        }

        public string GetNewPath(string oldPath)
        {
            var dot = oldPath.LastIndexOf(".");
            var slash = oldPath.LastIndexOf("\\");
            return string.Format("{0}(stegonograph).png", oldPath.Substring(slash+1, dot - slash-1));
        }

        private void ModifyPixel(Bitmap image, int i, bool r, bool g, bool b)
        {
            int x = i % image.Width;
            int y = i / image.Width;
            Color color = image.GetPixel(x, y);
            byte red = ChangeBit(color.R, r, 0x01);
            byte green = ChangeBit(color.G, g, 0x01);
            byte blue = ChangeBit(color.B, b, 0x01);
            Color newColor = Color.FromArgb(color.A, red, green, blue);
            image.SetPixel(x, y, newColor);
        }

        public Color GetColor(Bitmap image, int i)
        {
            int x = i % image.Width;
            int y = i / image.Width;

            if (x >= image.Size.Width || y >= image.Size.Height) {
                throw new PixelOutOfRangeException();
            }

            return image.GetPixel(x, y);
        }

        public static bool GetBit(byte b, int bitNumber)
        {
            return (b & (1 << bitNumber - 1)) != 0;
        }

        private static byte ChangeBit(byte i, bool bit, byte index)
        {
            if (bit) return (byte)(i | index);
            return (byte)(i & ~index);
        }

        public string DecryptImage(string imagePath)
        {
            var image = new Bitmap(imagePath, true);
            string s = String.Empty;
            int i = 0;
            while (true) {
                Color c1, c2, c3;

                try {
                    c1 = GetColor(image, i++);
                    c2 = GetColor(image, i++);
                    c3 = GetColor(image, i++);
                }
                catch(PixelOutOfRangeException) {
                    return "No end character found";
                }

                byte c = GetChar(c1, c2, c3);
                if (c == 0x00) break;
                s += (char)c;
            }
            if (s.StartsWith(Preamble))
                return s.Substring(Preamble.Length);
            return String.Format("No message encoded:\r\n{0}", s);
        }

        private byte GetChar(Color c1, Color c2, Color c3)
        {
            byte b = 0x00;
            b = ChangeBit(b, GetBit(c1.R, 0x01), 0x01);
            b = ChangeBit(b, GetBit(c1.G, 0x01), 0x02);
            b = ChangeBit(b, GetBit(c1.B, 0x01), 0x04);

            b = ChangeBit(b, GetBit(c2.R, 0x01), 0x08);
            b = ChangeBit(b, GetBit(c2.G, 0x01), 0x10);
            b = ChangeBit(b, GetBit(c2.B, 0x01), 0x20);

            b = ChangeBit(b, GetBit(c3.R, 0x01), 0x40);
            b = ChangeBit(b, GetBit(c3.G, 0x01), 0x80);
            return b;
        }

    }
}
