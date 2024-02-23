using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class BrightnessFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 25;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = Clamp(sourceColor.R + k, 0, 255);
            int G = Clamp(sourceColor.G + k, 0, 255);
            int B = Clamp(sourceColor.B + k, 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
