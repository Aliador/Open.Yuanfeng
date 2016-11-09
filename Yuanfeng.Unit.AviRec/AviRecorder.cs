using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Yuanfeng.Unit.AviRec
{
    public class AviRecorder     //视频类
    {
        public List<string> CamDicts = new List<string>();
        private bool delsrc = false;
        public bool flag = true;
        private IntPtr lwndC;       //保存无符号句柄
        private IntPtr mControlPtr; //保存管理指示器
        private int mWidth;
        private int mHeight;
        public delegate void RecievedFrameEventHandler(byte[] data);
        public event RecievedFrameEventHandler RecievedFrame;

        public Win32.CAPTUREPARMS Capparms;
        private Win32.FrameEventHandler mFrameEventHandler;
        public Win32.CAPDRIVERCAPS CapDriverCAPS;//捕获驱动器的能力，如有无视频叠加能力、有无控制视频源、视频格式的对话框等；
        public Win32.CAPSTATUS CapStatus;//该结构用于保存视频设备捕获窗口的当前状态，如图像的宽、高等
        private string destFilename;        
        public AviRecorder(IntPtr handle, int width, int height)
        {
            CapDriverCAPS = new Win32.CAPDRIVERCAPS();//捕获驱动器的能力，如有无视频叠加能力、有无控制视频源、视频格式的对话框等；
            CapStatus = new Win32.CAPSTATUS();//该结构用于保存视频设备捕获窗口的当前状态，如图像的宽、高等
            mControlPtr = handle; //显示视频控件的句柄
            mWidth = width;      //视频宽度
            mHeight = height;    //视频高度

            for (int i = 0; i < 10; i++)
            {
                byte[] lpszName = new byte[100];
                byte[] lpszVer = new byte[100];
                if (Win32.capGetDriverDescriptionA((short)i, lpszName, 100, lpszVer, 100))
                {
                    CamDicts.Add(Convert.ToBase64String(lpszName).Trim());
                }
            }
        }
        public bool StartWebCam()
        {
            return StartWebCam(mWidth, mHeight);
        }
        /// <summary>
        ///  打开视频设备
        /// </summary>
        /// <param name="width">捕获窗口的宽度</param>
        /// <param name="height">捕获窗口的高度</param>
        /// <returns></returns>
        public bool StartWebCam(int width, int height)
        {
            //byte[] lpszName = new byte[100];
            //byte[] lpszVer = new byte[100];
            //Win32.capGetDriverDescriptionA(0, lpszName, 100, lpszVer, 100);
            //this.lwndC = Win32.capCreateCaptureWindowA(lpszName, Win32.WS_CHILD | Win32.WS_VISIBLE, 0, 0, mWidth, mHeight, mControlPtr, 0);
            //if (Win32.SendMessage(lwndC, Win32.WM_CAP_DRIVER_CONNECT, 0, 0))
            //{
            //    Win32.SendMessage(lwndC, Win32.WM_CAP_SET_PREVIEWRATE, 100, 0);
            //    Win32.SendMessage(lwndC, Win32.WM_CAP_SET_PREVIEW, true, 0);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            this.lwndC = Win32.capCreateCaptureWindow("My Own Capture Control", Win32.WS_CHILD | Win32.WS_VISIBLE, 0, 0, mWidth, mHeight, mControlPtr, 0);//AVICap类的捕捉窗口
            Win32.FrameEventHandler FrameEventHandler = new Win32.FrameEventHandler(FrameCallback);
            Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_ERROR, 0, 0);//注册错误回调函数
            Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_STATUS, 0, 0);//注册状态回调函数 
            Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, 0);//注册视频流回调函数
            Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_FRAME, 0, FrameEventHandler);//注册帧回调函数

            //if (!CapDriverCAPS.fCaptureInitialized)//判断当前设备是否被其他设备连接已经连接
            //{

            if (Win32.SendMessage(this.lwndC, Win32.WM_CAP_DRIVER_CONNECT, 0, 0))
            {
                //-----------------------------------------------------------------------
                Win32.SendMessage(this.lwndC, Win32.WM_CAP_DRIVER_GET_CAPS, Win32.SizeOf(CapDriverCAPS), ref CapDriverCAPS);//获得当前视频 CAPDRIVERCAPS定义了捕获驱动器的能力，如有无视频叠加能力、有无控制视频源、视频格式的对话框等；
                Win32.SendMessage(this.lwndC, Win32.WM_CAP_GET_STATUS, Win32.SizeOf(CapStatus), ref CapStatus);//获得当前视频流的尺寸 存入CapStatus结构

                Win32.BITMAPINFO bitmapInfo = new Win32.BITMAPINFO();//设置视频格式 (height and width in pixels, bits per frame). 
                bitmapInfo.bmiHeader = new Win32.BITMAPINFOHEADER();
                bitmapInfo.bmiHeader.biSize = Win32.SizeOf(bitmapInfo.bmiHeader);
                bitmapInfo.bmiHeader.biWidth = mWidth;
                bitmapInfo.bmiHeader.biHeight = mHeight;
                bitmapInfo.bmiHeader.biPlanes = 1;
                bitmapInfo.bmiHeader.biBitCount = 24;
                Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_PREVIEWRATE, 40, 0);//设置在PREVIEW模式下设定视频窗口的刷新率 设置每40毫秒显示一帧，即显示帧速为每秒25帧
                Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_SCALE, 1, 0);//打开预览视频的缩放比例
                Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_VIDEOFORMAT, Win32.SizeOf(bitmapInfo), ref bitmapInfo);

                this.mFrameEventHandler = new Win32.FrameEventHandler(FrameCallback);
                this.capSetCallbackOnFrame(this.lwndC, this.mFrameEventHandler);


                Win32.CAPTUREPARMS captureparms = new Win32.CAPTUREPARMS();
                Win32.SendMessage(this.lwndC, Win32.WM_CAP_GET_SEQUENCE_SETUP, Win32.SizeOf(captureparms), ref captureparms);
                if (CapDriverCAPS.fHasOverlay)
                {
                    Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_OVERLAY, 1, 0);//启用叠加 注：据说启用此项可以加快渲染速度    
                }
                Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_PREVIEW, 1, 0);//设置显示图像启动预览模式 PREVIEW
                Win32.SetWindowPos(this.lwndC, 0, 0, 0, width, height, Win32.SWP_NOZORDER | Win32.SWP_NOMOVE);//使捕获窗口与进来的视频流尺寸保持一致
                return true;
            }
            else
            {

                flag = false;
                return false;
            }
        }
        public bool ReSizePic(int width, int height)
        {
            try
            {
                //  CloseWebcam();
                //  StartWebCam();
                //  this.lwndC = Win32.capCreateCaptureWindow("", Win32.WS_CHILD | Win32.WS_VISIBLE, 0, 0, mWidth, mHeight, mControlPtr, 0);

                //  Win32.SendMessage(this.lwndC, Win32.WM_CAP_GET_STATUS, Win32.SizeOf(CapStatus), ref CapStatus);//获得当前视频流的尺寸 存入CapStatus结构
                //   Win32.FrameEventHandler FrameEventHandler = new Win32.FrameEventHandler(FrameCallback);
                //   Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_ERROR, 0, 0);//注册错误回调函数
                //   Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_STATUS, 0, 0);//注册状态回调函数 
                //   Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, 0);//注册视频流回调函数
                //   Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_FRAME, 0, FrameEventHandler);//注册帧回调函数
                ////   if (Win32.SendMessage(this.lwndC, Win32.WM_CAP_DRIVER_CONNECT, 0, 0))
                //   {
                //       Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_SCALE, 1, 0);
                //       Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_PREVIEWRATE, 40, 0);
                //       Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_PREVIEW, 1, 0);

                return Win32.SetWindowPos(this.lwndC, 0, 0, 0, width, height, Win32.SWP_NOZORDER | Win32.SWP_NOMOVE) > 0;
                //  }
                // return false;
            }
            catch
            {
                return false;
            }
        }
        public void get()
        {
            Win32.SendMessage(this.lwndC, Win32.WM_CAP_GET_SEQUENCE_SETUP, Win32.SizeOf(Capparms), ref Capparms);
        }
        public void set()
        {
            Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_SEQUENCE_SETUP, Win32.SizeOf(Capparms), ref Capparms);
        }
        private bool capSetCallbackOnFrame(IntPtr lwnd, Win32.FrameEventHandler lpProc)
        {
            return Win32.SendMessage(this.lwndC, Win32.WM_CAP_SET_CALLBACK_FRAME, 0, lpProc);
        }
        /// <summary>
        /// 关闭视频设备
        /// </summary>
        public void CloseWebcam()
        {
            Win32.SendMessage(lwndC, Win32.WM_CAP_DRIVER_DISCONNECT, 0, 0);
        }
        ///   <summary>   
        ///   拍照
        ///   </summary>   
        ///   <param   name="path">要保存bmp文件的路径</param>   
        public void GrabImage(IntPtr hWndC, string path)
        {
            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);
            Win32.SendMessage(lwndC, Win32.WM_CAP_SAVEDIB, 0, hBmp.ToInt32());
        }
        public bool StarKinescope(string path)
        {
            try
            {
                destFilename = path;
                string dir = path.Remove(path.LastIndexOf("\\"));
                if (!File.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                int hBmp = Marshal.StringToHGlobalAnsi(path).ToInt32();
                bool b = Win32.SendMessage(this.lwndC, Win32.WM_CAP_FILE_SET_CAPTURE_FILE, 0, hBmp);
                b = b && Win32.SendMessage(this.lwndC, Win32.WM_CAP_SEQUENCE, 0, 0);
                return b;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 停止录像
        /// </summary>
        public bool StopKinescope()
        {
            return Win32.SendMessage(lwndC, Win32.WM_CAP_STOP, 0, 0);
        }
        private void FrameCallback(IntPtr lwnd, IntPtr lpvhdr)
        {
            Win32.VIDEOHDR videoHeader = new Win32.VIDEOHDR();
            byte[] VideoData;
            videoHeader = (Win32.VIDEOHDR)Win32.GetStructure(lpvhdr, videoHeader);
            VideoData = new byte[videoHeader.dwBytesUsed];
            Win32.Copy(videoHeader.lpData, VideoData);
            if (this.RecievedFrame != null)
                this.RecievedFrame(VideoData);
        }
        public void CompressVideoFfmpeg(bool delsrc)
        {
            testfn();
            this.delsrc = delsrc;
        }
        private void testfn()
        {
            string filename = destFilename;
            string args = " -i " + filename + " -vcodec libx264 -cqp 25 -y " + filename.Replace(".avi", "_264") + ".avi";
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            proc.StartInfo.UseShellExecute = false; //use false if you want to hide the window
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "ffmpeg";
            proc.StartInfo.Arguments = args;
            proc.Start();
            proc.WaitForExit();
            proc.Close();

            if (delsrc && File.Exists(filename)) File.Delete(filename);
        }
    }
}
