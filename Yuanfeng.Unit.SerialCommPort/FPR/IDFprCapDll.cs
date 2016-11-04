using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.FPR
{
    public class IDFprCapDll
    {
        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_Init();

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_Close();

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetChannelCount();

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_SetBright(int nChannel, int nBright);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_SetContrast(int nChannel, int nContrast);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetBright(int nChannel, ref int pnBright);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetContrast(int nChannel, ref int pnContrast);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetMaxImageSize(int nChannel, ref int pnWidth, ref int pnHeight);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetCaptWindow(int nChannel, ref int pnOriginX, ref int pnOriginY, ref int pnWidth, ref int pnHeight);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_SetCaptWindow(int nChannel, int nOriginX, int nOriginY, int nWidth, int nHeight);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_Setup();

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_BeginCapture(int nChannel);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetFPRawData(int nChannel, byte[] pRawData);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetFPBmpData(int nChannel, byte[] pBmpData);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_EndCapture(int nChannel);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_IsSupportSetup();

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetVersion();

        [DllImport(@"lib\fpr\ID_FprCap.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int LIVESCAN_GetDesc(byte[] pszDesc);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_GetErrorInfo(int nErrorNo, byte[] pszErrorInfo);

        [DllImport(@"lib\fpr\ID_FprCap.dll")]
        public static extern int LIVESCAN_SetBufferEmpty(byte[] pImageData, int imageLength);

    }
}
