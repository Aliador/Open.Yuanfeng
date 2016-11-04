using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Yuanfeng.Unit.SerialCommPort.Camera;
using System.Threading;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public partial class VidetekLDControl : UserControl
    {
        [DllImport(@"lib\living\LivingDetectSdk_x86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int LD_Init_SDK(int width, int height);

        [DllImport(@"lib\living\LivingDetectSdk_x86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void LD_CheckLiving_SDK(int handle, byte[] imgData, int width, int height,
            ref int isMouthOpen, ref int isEyeClose, ref int isNodHead, ref int isShakeHead,
            ref bool mouthOpen, ref bool EyeClose, ref bool NodHead, ref bool ShakeHead);
        [DllImport(@"lib\living\LivingDetectSdk_x86.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void LD_Release_SDK(int handle);


        private Thread beginDetect;
        private ICamera camera = new CameraDirectShowClass();
        private bool isOpened = false;
        private int handle;
        private int timeout = 30 * 1000;

        public LFCompletedHandler completedHandler;
        public VidetekLDControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            handle = LD_Init_SDK(640, 480);
            if (handle > 0) { bool ret = camera.Init(this.pbContainer); isOpened = ret; }
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 640 * 480)]
        public byte[] imgBuffer = null;
        private List<int> matchCount = new List<int>();
        private byte[] matchBuffer = null;
        public void Start()
        {
            matchBuffer = null;
            timeout = 30 * 1000;
            matchCount.Clear();
            beginDetect = new Thread(new ThreadStart(() =>
            {
                while (true && isOpened)
                {
                    bool snapshot = camera.Snapshot(out imgBuffer);
                    if (snapshot && handle > 0)
                    {
                        int isEyeClose = 0, isMouthOpen = 0, isShakeHead = 0, isNodHead = 0;
                        bool bEyeClose = true, bMouthOpen = true, bShakeHead = true, bNodHead = true;
                        LD_CheckLiving_SDK(handle, imgBuffer, 640, 480,
                            ref isMouthOpen, ref isEyeClose, ref isNodHead, ref isShakeHead,
                            ref bMouthOpen, ref bEyeClose, ref bNodHead, ref bShakeHead);

                        if (isEyeClose > 0 && !this.matchCount.Contains(0)) this.matchCount.Add(0);
                        if (isMouthOpen > 0 && !this.matchCount.Contains(1)) this.matchCount.Add(1);
                        if (isShakeHead > 0 && !this.matchCount.Contains(2)) this.matchCount.Add(2);
                        if (isNodHead > 0 && !this.matchCount.Contains(3)) this.matchCount.Add(3);

                        timeout -= 2;
                    }
                    if (matchCount.Count == 3 || timeout <= 0)
                    {
                        matchBuffer = imgBuffer;
                        break;
                    }
                }

                if (completedHandler != null)
                {
                    if (matchBuffer != null) completedHandler.Invoke(Convert.ToBase64String(matchBuffer), ""); else completedHandler.Invoke("", "");
                }
            }));
            beginDetect.Start();
        }

        public void Close()
        {
            try
            {
                if (beginDetect != null) beginDetect.Abort();
                if (isOpened)  LD_Release_SDK(handle); camera.Release();
                isOpened = false;
            }
            catch { }
        }
    }
}
