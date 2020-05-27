using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NeuralNetwork
{
    class SupportAI
    {
        private SupportAI() { }

        /// <summary>
        /// returns amount of dark / light pixels
        /// </summary>
        /// <param name="fname">Full path to file</param>
        /// <param name="startX">starting x coordinate</param>
        /// <param name="startY">starting y coordinate</param>
        /// <param name="lengthX">amount of pixels to cut by x axis from starting x coordinate</param>
        /// <param name="lengthY">amount of pixels to cut by y axis from starting y coordinate</param>
        public static int[] calculateScan(string fname, int startX, int startY, int lengthX, int lengthY)
        {
            Bitmap brainScan = new Bitmap(fname);
            int width = brainScan.Width;
            int height = brainScan.Height;
            int[] sum = new int[2];
            sum[0] = 0;
            sum[1] = 0;

            Color pixel;
            for (int i = startX; i < lengthX; i++)
            {
                for (int j = startX; j < lengthY; j++)
                {
                    pixel = brainScan.GetPixel(i, j);
                    if (pixel.GetBrightness() < 0.4)
                    {
                        sum[0] += 1;
                    }
                    else
                    {
                        sum[1] += 1;
                    }
                }

            }
            return sum;
        }
    }
}
