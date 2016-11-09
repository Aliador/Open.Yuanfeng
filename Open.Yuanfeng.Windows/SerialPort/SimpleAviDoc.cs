using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.Unit.AviRec;
using Yuanfeng.WinFormsUI.Docking;

namespace Open.Yuanfeng.Windows.SerialPort
{
    public partial class SimpleAviDoc : DockContent
    {
        public SimpleAviDoc()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tbDestfile.Text = saveFileDialog1.FileName;
            }
        }
        private AviRecorder video;
        private bool isOpened = false;
        private bool isRecord = false;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            int x = 320;
            int y = 240;
            int index = this.cbbDvrs.SelectedIndex;
            if (index == 1) { x = 640; y = 480; }
            //打开视频
            if (video.StartWebCam(x, y))
            {
                video.get();
                video.Capparms.fYield = true;
                video.Capparms.fAbortLeftMouse = false;
                video.Capparms.fAbortRightMouse = false;
                video.Capparms.fCaptureAudio = false;
                video.Capparms.dwRequestMicroSecPerFrame = 0x9C40; // 设定帧率25fps： 1*1000000/25 = 0x9C40
                video.set();
                isOpened = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isOpened && isRecord)
            {
                video.StopKinescope();
                video.CompressVideoFfmpeg(true);
                isRecord = false;
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            isRecord = video.StarKinescope(this.tbDestfile.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isOpened)
            {
                video.CloseWebcam();
                isOpened = false;
            }
        }

        private void SimpleAviDoc_Load(object sender, EventArgs e)
        {            
            video = new AviRecorder(this.pictureBox1.Handle, 320, 240);
            this.cbbDvrs.DataSource = video.CamDicts;
        }
    }
}
