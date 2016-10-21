using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Yuanfeng.Smarty;

namespace Yuanfeng.ImageUnit.FaceFeatureCompare
{
    public class VidetekLController : IFaceFeatureContoller
    {
        private static IFaceFeatureContoller @this;
        private string img1 = string.Empty;
        private string img2 = string.Empty;

        public VidetekLController()
        {

        }

        public static IFaceFeatureContoller New()
        {
            if (@this == null) @this = new VidetekLController(); return @this;
        }

        private bool isInited = false;
        public bool IsInited
        {
            get
            {
                return isInited;
            }
        }

        public float Compare(string img1, string img2)
        {
            float score = 0f;
            try
            {
                DaqianSDK.compareface(img1, img2, ref score);
            }
            catch { }
            return score;
        }

        public float Compare(byte[] buffer1, byte[] buffer2)
        {
            if (isInited)
            {
                float score = 0f;
                try
                {
                    img1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videtek_img1.bmp");
                    img2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videtek_img2.bmp");

                    buffer1.ToBitmap().Save(img1, System.Drawing.Imaging.ImageFormat.Bmp);
                    buffer2.ToBitmap().Save(img2, System.Drawing.Imaging.ImageFormat.Bmp);

                    int result = DaqianSDK.compareface(img1, img2, ref score);
                    if (result == 0)
                    {
                        score = -1;//比对失败
                    }
                }
                catch { }
                return score;
            }
            return -3;
        }

        public int Init()
        {
            if (!isInited) { int result = DaqianSDK.init(); if (result == 1) this.isInited = true; }
            return isInited ? 1 : 0;
        }

        public int Release()
        {
            if (isInited) return DaqianSDK.release(); return 1;
        }
    }
}
