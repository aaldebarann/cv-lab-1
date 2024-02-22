using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class SepiaFilter: Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 25;
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intensity = (0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            int R = Clamp((int)(intensity + 2 * k), 0, 255);
            int G = Clamp((int)(intensity + 0.5 * k), 0, 255);
            int B = Clamp((int)(intensity - k), 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
