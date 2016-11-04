using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Unit.SerialCommPort.FPR
{
    public interface IFprCapture
    {
        int Open(CaptureFingerHandler captureFingerHandler, CaptureCompletedHandler captureComletedHandler);
        bool IsOpen { get; }
        int Channels { get; }
        int Capture(byte fingerPosCode, int channel = 0, int operTimeout = 30 * 1000);
        int Capture(byte fingerPosCode, byte[] destFingerBuffer, byte destFingerPosCode, int channel = 0, int operTimeout = 30 * 1000);

        int Close();
    }

    public delegate void CaptureCompletedHandler(byte[] fingerBuffer, byte[] featureBuffer, int quality, float score);
    public delegate void CaptureFingerHandler(byte[] fingerBuffer);
}
