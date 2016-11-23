using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public class FaceQuality
    {
        public FaceQuality()
        {

        }
        public FaceQuality(int x,int y,int widht,int height,int quality)
        {
            this.X = x; this.Y = y; this.Width = widht;this.Height = height;this.Quality = quality;
        }
        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Quality { get; set; }
    }
}
