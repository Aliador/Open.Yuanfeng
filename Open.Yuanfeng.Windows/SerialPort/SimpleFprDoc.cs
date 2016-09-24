using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Yuanfeng.ExternalUnit.SerialCommPort.FPR;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.SerialPort
{
    public partial class SimpleFprDoc : DockContent
    {
        public SimpleFprDoc()
        {
            InitializeComponent();
        }
        private IFprCapture fprCapture = new FprCaptureSimpleClass();
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                fprCapture.Open(new CaptureFingerHandler((byte[] buffer) =>
                 {
                     this.Invoke(new Action(() => { this.FingerImage.Image = buffer.ToBitmap(); }));
                 }), new CaptureCompletedHandler((byte[] fingerBuffer, byte[] featureBuffer, int quality, float score) =>
                 {
                     this.Invoke(new Action(() => { this.FingerQuality.Text = quality.ToString(); this.btnCapture.Enabled = true; }));
                 }));
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            fprCapture.Close();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            int result = fprCapture.Capture(11, (int)this.Channel.Value, (int)this.Timeout.Value);

            if (result == 1) this.btnCapture.Enabled = false;
        }
    }
}
