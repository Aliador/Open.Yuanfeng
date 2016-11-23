using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.Unit.SerialCommPort.Camera;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public class VidetekLFController : ILiveFaceCompare
    {
        [DllImport("LivingDetectSdk_x86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int LD_Init_SDK(int width, int height);

        [DllImport("LivingDetectSdk_x86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void LD_CheckLiving_SDK(int handle, byte[] imgData, int width, int height,
            ref int isMouthOpen, ref int isEyeClose, ref int isNodHead, ref int isShakeHead,
            ref bool mouthOpen, ref bool EyeClose, ref bool NodHead, ref bool ShakeHead);
        [DllImport("LivingDetectSdk_x86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void LD_Release_SDK(int handle);
        private ICamera camera = new CameraDirectShowClass();
        private bool isOpened = false;
        private LiveRecongtionCompletedHandler handler;
        private int handle;
        private string args;
        public bool IsOpen
        {
            get
            {
                return isOpened;
            }
        }

        public int Close()
        {
            return 0;
        }

        public int Init(Control container, LiveRecongtionCompletedHandler handler)
        {
            bool result = camera.Init(container);
            this.handler = handler;
            if (result)
            {
                handle = LD_Init_SDK(640, 480);
            }
            if (handle > 0) { isOpened = true; return 1; }
            else
            {
                return 0;
            }
        }

        public int Init(Control container,string args, LiveRecongtionCompletedHandler handler)
        {
            bool result = camera.Init(container);
            this.handler = handler;
            this.args = args;
            if (result)
            {
                handle = LD_Init_SDK(640, 480);
            }
            if (handle > 0) { isOpened = true; return 1; }
            else
            {
                return 0;
            }
        }

        public int Start()
        {
            throw new NotImplementedException();
        }
    }
}
