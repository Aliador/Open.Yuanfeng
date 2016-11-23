using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.Unit.FaceFeatureCompare;
using Yuanfeng.Smarty;
using Yuanfeng.WinFormsUI.Docking;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class VidetekLiveingDetectDoc : DockContent
    {
        public VidetekLiveingDetectDoc()
        {
            InitializeComponent();
            this.videtekLDControl1.completedHandler += new LiveRecongtionCompletedHandler(handle);
        }

        void handle(string a, string b)
        {
            if (!string.IsNullOrEmpty(a))
            {
                this.Invoke(new Action(() => { this.pictureBox1.Image = Convert.FromBase64String(a).ToBitmap(); }));
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.videtekLDControl1.Init();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.videtekLDControl1.Start();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            this.videtekLDControl1.Close();
        }

        private void VidetekLiveingDetectDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.videtekLDControl1.Close();
        }
    }
}
