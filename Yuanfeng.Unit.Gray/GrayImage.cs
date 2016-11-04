using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.Gray
{
    public class GrayImage
    {
        public static bool IsGray(byte[] buffer)
        {
            return IsGray(new Bitmap(new MemoryStream(buffer)));
        }

        public static bool IsGray(Bitmap image)
        {
            int colorPixelCount = 0;
            Color color = new Color();
            using (Bitmap bmp = image)
            {
                //历遍图片的像素点
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        color = bmp.GetPixel(x, y);
                        //判断像素点的色偏差值Diff
                        if (GetRGBDiff(color.R, color.G, color.B) > 50)
                        {
                            colorPixelCount += 1;
                        }
                    }
                }
            }

            return colorPixelCount == 0;
        }
        private static int GetRGBDiff(byte r, byte g, byte b)
        {
            int x = Math.Abs(r - g);
            int y = Math.Abs(r - b);
            int z = Math.Abs(g - b);

            int temp = x;
            if (y > temp) temp = y;
            if (z > temp) temp = z;

            return temp;
        }
    }
}
