using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorCalculator
{
    public class PixelOutOfRangeException : Exception
    {
        public override string Message => "x or y out of range of image size";
    }

    public class ColorCalculator
    {
        private readonly bool _rgb;
        private readonly Equation[] _equations;

        public ColorCalculator(string ex1, string ex2, string ex3, string ex4, bool rgb)
        {
            _rgb = rgb;
            _equations = new[] {new Equation(ex1), new Equation(ex2), new Equation(ex3), new Equation(ex4)};
        }

        public Bitmap GetRecolor(Bitmap image, Action<int> setProgress)
        {
            for (var x = 0; x < image.Width; x++) {
                for (var y = 0; y < image.Height; y++)
                {
                    ModifyPixel(image, x, y);
                }
                setProgress(x * 100 / image.Width);
            }
            return image;
        }

        private void ModifyPixel(Bitmap image, int x, int y)
        {
            var color = image.GetPixel(x, y);

            var colorVars = new Dictionary<char, double>
            {
                {'R', color.R},
                {'G', color.G},
                {'B', color.B},
                {'A', color.A},
                {'H', color.GetHue()},
                {'S', color.GetSaturation()},
                {'L', color.GetBrightness()}
            };
            var colorValues = new[]
            {
                _equations[0].Evaluate(colorVars),
                _equations[1].Evaluate(colorVars),
                _equations[2].Evaluate(colorVars),
                _equations[3].Evaluate(colorVars)
            };

            var newColor = _rgb ? SafeColor(colorValues[3], colorValues[0], colorValues[1], colorValues[2]) : GetColor(colorValues[3], colorValues[0], colorValues[1], colorValues[2]);
            image.SetPixel(x, y, newColor);
        }

        private static Color GetColor(double a, double h, double s, double l)
        {
            h = h / 360;
            double r, g, b;
            if (Math.Abs(s) < 0.0001)
            {
                r = g = b = l;
            }
            else
            {
                var q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                var p = 2 * l - q;
                r = Magic(p, q, h + 1 / 3.0);
                g = Magic(p, q, h);
                b = Magic(p, q, h - 1 / 3.0);
            }
            return SafeColor(a, r * 255, g * 255, b * 255);
        }

        private static double Magic(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1 / 6.0) return p + (q - p) * 6 * t;
            if (t < 1 / 2.0) return q;
            if (t < 2 / 3.0) return p + (q - p) * (2 / 3.0 - t) * 6;
            return p;
        }

        private static Color SafeColor(double a, double r, double g, double b)
        {
            return Color.FromArgb(SafeValue(a), SafeValue(r), SafeValue(g), SafeValue(b));
        }

        private static int SafeValue(double d)
        {
            return (int) Math.Round(Math.Max(Math.Min(d,255), 0));
        }
    }
}
