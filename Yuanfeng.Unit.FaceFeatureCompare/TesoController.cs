using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public class TesoController : IFaceFeatureContoller
    {
        public bool IsInited { get { return isInited; } }
        private bool isInited = false;
        private int featureBuffer = 3088;
        private static TesoController @this;
        private TesoController() { }
        public static TesoController New()
        {
            if (@this == null) @this = new TesoController(); return @this;
        }

        public float Compare(string img1, string img2)
        {
            byte[] feature1 = new byte[featureBuffer * 2];
            byte[] feature2 = new byte[featureBuffer * 2];

            int ret1 = TaiSDK.face_get_feature_from_image(img1, feature1);
            int ret2 = TaiSDK.face_get_feature_from_image(img2, feature2);

            if (ret1 > 0 && ret2 > 0)
            {
                int score = TaiSDK.face_comp_feature(feature1, feature2); return score;
            }
            else if (ret1 <= 0)
            {
                throw new Exception("提取图片1特征点失败");
            }
            else
            {
                throw new Exception("提取图片2特征点失败");
            }
        }

        public float Compare(byte[] buffer1, byte[] buffer2)
        {
            string b1 = Convert.ToBase64String(buffer1);
            string b2 = Convert.ToBase64String(buffer2);

            byte[] feature1 = new byte[8000];
            byte[] feature2 = new byte[8000];

            int ret1 = TaiSDK.face_get_feature(b1, feature1, "c:\\a11.jpg");
            int ret2 = TaiSDK.face_get_feature(b2, feature2, "c:\\a22.jpg");

            if (ret1 > 0 && ret2 > 0)
            {
                int score = TaiSDK.face_comp_feature(feature1, feature2); return score;
            }
            else if (ret1 <= 0)
            {
                throw new Exception(string.Format("提取图片1特征点失败:{0}",ret1));
            }
            else
            {
                throw new Exception(string.Format("提取图片2特征点失败:{0}", ret2));
            }
        }

        public int Init()
        {
            if (!isInited)
            {
                featureBuffer = TaiSDK.face_init();
                if (featureBuffer >= 0) isInited = true;
            }
            return featureBuffer;
        }

        public int Release()
        {
            if (isInited)
            {
                int result = TaiSDK.face_exit();
                if (result >= 0) isInited = false; return result;
            }
            return 0;
        }

        public FaceQuality Detect(byte[] buffer1)
        {
            throw new NotImplementedException();
        }
    }
}
