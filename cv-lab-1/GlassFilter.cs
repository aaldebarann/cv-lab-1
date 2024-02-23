using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class GlassFilter: Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            var random = new Random();
            int x = (int)(k + (random.Next(0, 100) * 0.01 - 0.5) * 10);
            int y = (int)(l + (random.Next(0, 100) * 0.01 - 0.5) * 10);
            if (x < 0)
                x = 0;
            if (x >= sourceImage.Width)
                x = sourceImage.Width - 1;
            if (y < 0)
                y = 0;
            if (y >= sourceImage.Height)
                y = sourceImage.Height - 1;
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                sourceColor.R,
                sourceColor.G,
                sourceColor.B);
            return resultColor;
        }
    }
}
