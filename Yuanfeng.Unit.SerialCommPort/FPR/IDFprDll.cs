using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.FPR
{
    public class IDFprDll
    {
        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_GetVersion(byte[] code);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_Begin();

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_FeatureExtract(byte cScannerType, byte cFingerCode, byte[] pFingerImgBuf, byte[] pFeatureData);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_FeatureMatch(byte[] pFeatureData1, byte[] pFeatureData2, ref float pfSimilarity);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_ImageMatch(byte[] pFingerImgBuf, byte[] pFeatureData, ref float pfSimilarity);

        [DllImport(@"lib\fpr\ID_Fpr.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FP_Compress(byte cScannerType, byte cEnrolResult, byte cFingerCode, byte[] pFingerImgBuf, int nCompressRatio, byte[] pCompressedImgBuf, byte[] strBuf);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_Decompress(byte[] pCompressedImgBuf, byte[] pFingerImgBuf, byte[] strBuf);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_GetQualityScore(byte[] pFingerImgBuf,ref int pnScore);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_GenFeatureFromEmpty1(int cScannerType, byte cFingerCode, byte[] pFeatureData);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_GenFeatureFromEmpty2(byte cFingerCode, byte[] pFeatureData);

        [DllImport(@"lib\fpr\ID_Fpr.dll")]
        public static extern int FP_End();
    }
}
