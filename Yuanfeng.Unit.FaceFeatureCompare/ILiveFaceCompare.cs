using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public delegate void LiveRecongtionCompletedHandler(string bmp, string gray);
    public interface ILiveFaceCompare
    {
        int Init(Control container, LiveRecongtionCompletedHandler handler);
        int Init(Control container,string args, LiveRecongtionCompletedHandler handler);
        int Start();
        int Close();
        bool IsOpen { get; }
    }
}
