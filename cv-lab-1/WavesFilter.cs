using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class WavesFilter: Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int x = (int)(k + 15 * Math.Sin(2 * Math.PI * l / 60));
            if (x < 0)
                x = 0;
            if(x >= sourceImage.Width)
                x = sourceImage.Width - 1;
            int y = l;
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                sourceColor.R, 
                sourceColor.G,
                sourceColor.B);
            return resultColor;
        }
    }
}
