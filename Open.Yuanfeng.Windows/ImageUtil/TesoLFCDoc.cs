using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.ImageUnit.FaceFeatureCompare;
using Yuanfeng.Smarty;
using Yuanfeng.WinFormsUI.Docking;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class TesoLFCDoc : DockContent
    {
        public TesoLFCDoc()
        {
            InitializeComponent();
        }

        private ILiveFaceCompare LFC = new TesoLFContoller();
        private void btnOpen_Click(object sender, EventArgs e)
        {
            LFC.Init(this.panelContainer, new LFCompletedHandler((string bmp, string gray) =>
            {
                if (string.IsNullOrEmpty(bmp) || string.IsNullOrEmpty(gray))
                {
                    SimpleConsole.WriteLine("This take photo fail.");
                }
                else
                {
                    byte[] buffer1 = Convert.FromBase64String(bmp);
                    byte[] buffer2 = Convert.FromBase64String(gray);

                    this.picBmp.Image = buffer1.ToBitmap();
                    this.picGray.Image = buffer2.ToBitmap();
                }
            }));
            LFC.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LFC.Close();
        }
    }
}
