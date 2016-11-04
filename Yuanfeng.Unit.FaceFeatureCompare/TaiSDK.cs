using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public class TaiSDK
    {
        [DllImport(@"lib\teso\TaiSDK.dll", EntryPoint = "face_comp_feature", CallingConvention = CallingConvention.Cdecl)]
        public static extern int face_comp_feature(byte[] feature1, byte[] feature2);

        [DllImport(@"lib\teso\TaiSDK.dll", EntryPoint = "face_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int face_init();

        [DllImport(@"lib\teso\TaiSDK.dll", EntryPoint = "face_get_feature", CallingConvention = CallingConvention.Cdecl)]
        public static extern int face_get_feature(string pic_sec64, byte[] feature, string savePic);

        [DllImport(@"lib\teso\TaiSDK.dll", EntryPoint = "face_get_feature_from_image", CallingConvention = CallingConvention.Cdecl)]
        public static extern int face_get_feature_from_image(string savePic, byte[] feature);

        [DllImport(@"lib\teso\TaiSDK.dll", EntryPoint = "face_exit")]
        public static extern int face_exit();
    }
}
