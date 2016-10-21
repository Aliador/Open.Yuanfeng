using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Yuanfeng.ImageUnit.FaceFeatureCompare
{
    public class DaqianSDK
    {
        [DllImport(@"lib\videtek\facemodel.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int init();

        [DllImport(@"lib\videtek\facemodel.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int detectface(string imgPath, ref int x, ref int y, ref int width, ref int height, ref int quality);

        [DllImport(@"lib\videtek\facemodel.dll", EntryPoint = "compareface", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int compareface(string imgPath1, string imgPath2, ref float score);

        [DllImport(@"lib\videtek\facemodel.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int release();
    }
}
