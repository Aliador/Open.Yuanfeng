using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuanfeng.Smarty;

namespace Yuanfeng.Unit.SerialCommPort.FPR
{
    public class IDFprFeature
    {
        public int Extract(byte fingerPosCode, byte[] fingerBuffer, byte[] featureBuffer)
        {
            if (fingerBuffer == null) return 0;

            int result = IDFprDll.FP_Begin();

            if (result == 0) return 0;

            result = IDFprDll.FP_FeatureExtract(0x1, fingerPosCode, fingerBuffer, featureBuffer);

            SimpleConsole.WriteLine(new Exception(string.Format("extract finger feature result {0}.", result)));

            return IDFprDll.FP_End();
        }
        public int Quality(byte[] fingerBuffer)
        {
            if (fingerBuffer == null) return 0;

            int result = IDFprDll.FP_Begin();

            if (result == 0) return 0;

            int quality = 0x0;

            result = IDFprDll.FP_GetQualityScore(fingerBuffer, ref quality);

            SimpleConsole.WriteLine(new Exception(string.Format("get finger quality result {0}", result)));

            result = IDFprDll.FP_End();

            return (int)quality;
        }

        public int Match(byte[] finger1Buffer, byte[] finger2Buffer, out float quality)
        {
            quality = 0f;
            if (finger1Buffer == null || finger1Buffer == null) return 0;

            int result = IDFprDll.FP_Begin();

            if (result == 0) return 0;

            result = IDFprDll.FP_FeatureMatch(finger1Buffer, finger2Buffer, ref quality);

            SimpleConsole.WriteLine(new Exception(string.Format("get feature match result {0}.", result)));

            return IDFprDll.FP_End();
        }
    }
}
