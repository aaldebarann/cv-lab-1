using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class LinearFilter: Filter
    {
        private int yMin, yMax;
        protected override Bitmap preprocessImage(Bitmap sourceImage)
        {
            yMin = 255;
            yMax = 0;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    int intensity = Clamp((int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B), 0, 255);
                    yMin = Math.Min(intensity, yMin);
                    yMax = Math.Max(intensity, yMax);
                }
            return sourceImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp((int)((color.R - yMin) * 255 / (yMax - yMin)), 0, 255),
                Clamp((int)((color.G - yMin) * 255 / (yMax - yMin)), 0, 255),
                Clamp((int)((color.B - yMin) * 255 / (yMax - yMin)), 0, 255));
            return resultColor;
        }
    }
}
