using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cv_lab_1
{
    abstract class Filter
    {
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap preprocessedImage = preprocessImage(sourceImage);
            Bitmap resultImage = new Bitmap(preprocessedImage.Width, preprocessedImage.Height);
            for (int i = 0; i < preprocessedImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < preprocessedImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(preprocessedImage, i, j));
                }
            }
            return postprocessImage(resultImage);
        }
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        protected virtual Bitmap preprocessImage(Bitmap sourceImage)
        {
            return sourceImage;
        }
        protected virtual Bitmap postprocessImage(Bitmap sourceImage)
        {
            return sourceImage;
        }
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }
}
