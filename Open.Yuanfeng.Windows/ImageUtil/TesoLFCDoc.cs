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
            int isOpen = LFC.Start();
            if (isOpen == 0) SimpleConsole.WriteLine("This lf start faild.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int isClose = LFC.Close(); if (isClose == 0) SimpleConsole.WriteLine("lf is not open.");
        }
        private int testCount = 0;
        private int failCount = 0;
        private void btnAutoTest_Click(object sender, EventArgs e)
        {
            testCount = 0;
            failCount = 0;
            LFC.Init(this.panelContainer, new LFCompletedHandler((string bmp, string gray) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.lblCount.Text = "" + (++testCount);

                    if (string.IsNullOrEmpty(bmp) || string.IsNullOrEmpty(gray))
                    {
                        SimpleConsole.WriteLine("This take photo fail.");
                        failCount += 1;
                        this.lblFail.Text = "" + failCount;
                    }
                    else
                    {
                        byte[] buffer1 = Convert.FromBase64String(bmp);
                        byte[] buffer2 = Convert.FromBase64String(gray);

                        this.picBmp.Image = buffer1.ToBitmap();
                        this.picGray.Image = buffer2.ToBitmap();
                    }

                    //if (LFC.IsOpen) LFC.Close(); LFC.Start();
                }));
            }));
            if (LFC.IsOpen) LFC.Close(); LFC.Start();
        }
    }
}
