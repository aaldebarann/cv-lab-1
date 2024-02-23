using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class EmbrossingFilter: MatrixFilter
    {
        public EmbrossingFilter()
        {
            kernel = new float[3, 3];
            kernel[0, 0] = 0; kernel[0, 1] = 1; kernel[0, 2] = 0;
            kernel[1, 0] = 1; kernel[1, 1] = 0; kernel[1, 2] = -1;
            kernel[2, 0] = 0; kernel[2, 1] = -1; kernel[2, 2] = 0;
        }
        protected override Bitmap postprocessImage(Bitmap sourceImage)
        {
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color sourceColor = sourceImage.GetPixel(x, y);
                    Color resultColor = Color.FromArgb(
                        (sourceColor.R + 255) / 2,
                        (sourceColor.G + 255) / 2,
                        (sourceColor.B + 255) / 2);
                    sourceImage.SetPixel(x, y, resultColor);
                }
            return sourceImage;
        }
    }
}
