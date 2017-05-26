using System;
using System.Collections.Generic;
using System.Threading;
using Yuanfeng.Smarty;

namespace Yuanfeng.Unit.SerialCommPort.FPR
{
    public class FprCaptureSimpleClass : IFprCapture
    {
        private bool isOpened = false;
        private CaptureCompletedHandler captureCompletedHandler;
        private CaptureFingerHandler captureFingerHandler;
        private Dictionary<int, int> channelSizeDict = new Dictionary<int, int>();
        private IDFprFeature feature = new IDFprFeature();
        private Thread threadCaptureFinger;

        public bool IsOpen
        {
            get
            {
                return isOpened;
            }
        }

        private int channels = 0;

        public int Channels
        {
            get
            {
                return channels;
            }
        }

        public int Capture(byte fingerPosCode, int channel = 0, int operTimeout = 30000)
        {
            if (channel + 1 > channels) throw new Exception("Not find target device.");

            if (!isOpened) throw new Exception("Please open device first.");

            threadCaptureFinger = new Thread((object arg) =>
            {
                byte[] imageBuffer = null;
                int quality = 0;
                byte[] featureBuffer = null;
                int tempTimeout = (int)arg;
                while (tempTimeout >= 0 && isOpened)
                {
                    byte[] pRawData = null;
                    byte[] pBmpData = null;
                    int result = 0;
                    pRawData = new byte[channelSizeDict[channel]];
                    pBmpData = new byte[channelSizeDict[channel] + 1078];

                    IDFprCapDll.LIVESCAN_BeginCapture(channel);

                    result = IDFprCapDll.LIVESCAN_GetFPBmpData(channel, pBmpData);
                    result = IDFprCapDll.LIVESCAN_GetFPRawData(channel, pRawData);
                    if (result == 1)
                    {
                        result = feature.Quality(pRawData);
                        if (result > 0)
                        {
                            quality = result;
                            featureBuffer = new byte[512];
                            result = feature.Extract(fingerPosCode, pRawData, featureBuffer);
                        }
                        else
                        {
                            SimpleConsole.WriteLine(new Exception(string.Format("get finger quality failed, error code:{0}", result)));
                        }
                        imageBuffer = pBmpData;
                    }
                    else
                    {
                        SimpleConsole.WriteLine(new Exception(string.Format("get finger bmp or fpr failed, error code:{0}", result)));
                    }
                    IDFprCapDll.LIVESCAN_EndCapture(channel);

                    if (pBmpData != null && captureFingerHandler != null) captureFingerHandler.Invoke(pBmpData);
                    if (this.captureCompletedHandler != null) this.captureCompletedHandler.Invoke(imageBuffer, featureBuffer, quality, 0);

                    pRawData = null;
                    pBmpData = null;

                    GC.Collect();//force
                }                
            });

            threadCaptureFinger.Start(operTimeout);
            return 1;
        }

        public int Capture(byte fingerPosCode, byte[] destFingerBuffer, byte destFingerPosCode, int channel = 0, int operTimeout = 30000)
        {
            throw new NotImplementedException();
        }

        public int Close()
        {
            if (isOpened)
            {
                this.captureCompletedHandler = null;
                this.captureFingerHandler = null;
                this.isOpened = false;
                if (this.threadCaptureFinger != null) this.threadCaptureFinger.Abort();
                for (int i = 0; i < channels; i++)
                {
                    IDFprCapDll.LIVESCAN_EndCapture(i);
                }
                return IDFprCapDll.LIVESCAN_Close();
            }

            return 1;
        }

        public int Open(CaptureFingerHandler captureFingerHandler, CaptureCompletedHandler captureCompletedHandler)
        {
            if (isOpened) return 1;
            try
            {
                int result = IDFprCapDll.LIVESCAN_Init();
                if (result != 1)
                {
                    throw new Exception(string.Format("The device is error.error code:{0}", result));
                }
                int nChannelCount = IDFprCapDll.LIVESCAN_GetChannelCount();
                if (nChannelCount <= 0)
                {
                    throw new Exception("The device channel is not find.");
                }
                channelSizeDict.Clear();
                for (int i = 0; i < nChannelCount; i++)
                {
                    result = IDFprCapDll.LIVESCAN_SetContrast(i, 127);
                    int x = 256, y = 360;
                    result = IDFprCapDll.LIVESCAN_GetMaxImageSize(i, ref x, ref y);
                    channelSizeDict.Add(i, x * y);
                }
                channels = nChannelCount;

                if (result == 1) isOpened = true;

                this.captureCompletedHandler = captureCompletedHandler;
                this.captureFingerHandler = captureFingerHandler;

                return result;
            }
            catch (Exception excetion) { throw new Exception(excetion.Message); }
        }
    }
}
