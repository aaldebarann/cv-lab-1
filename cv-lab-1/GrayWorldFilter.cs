using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class GrayWorldFilter: Filter
    {
        private double Avg, R, G, B;
        protected override Bitmap preprocessImage(Bitmap sourceImage)
        {
            R = 0;
            G = 0;
            B = 0;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    R += color.R;
                    G += color.G;
                    B += color.B;
                }
            int N = sourceImage.Height * sourceImage.Width;
            R /= N; G /= N; B /= N;
            Avg = (R + G + B) / 3;
            return sourceImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp((int)(color.R * Avg / R), 0, 255),
                Clamp((int)(color.G * Avg / G), 0, 255),
                Clamp((int)(color.B * Avg / B), 0, 255));
            return resultColor;
        }
    }
}
