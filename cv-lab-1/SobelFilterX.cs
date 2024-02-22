﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_lab_1
{
    internal class SobelFilterX: MatrixFilter
    {
        public SobelFilterX()
        {
            kernel = new float[3, 3];
            kernel[0, 0] = -1; kernel[0, 1] = 0; kernel[0, 2] = 1;
            kernel[1, 0] = -2; kernel[1, 1] = 0; kernel[1, 2] = 2;
            kernel[2, 0] = -1; kernel[2, 1] = 0; kernel[2, 2] = 1;
        }
    }
}
