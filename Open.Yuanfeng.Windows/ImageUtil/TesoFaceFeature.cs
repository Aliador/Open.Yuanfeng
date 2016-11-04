using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.Unit.SerialCommPort.Camera;
using Yuanfeng.Unit.FaceFeatureCompare;
using Yuanfeng.Smarty;
using Yuanfeng.WinFormsUI.Docking;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class TesoFaceFeature : DockContent
    {
        private ICamera simpleCamera = new CameraDirectShowClass();
        private IFaceFeatureContoller feature = TesoController.New();
        public TesoFaceFeature()
        {
            InitializeComponent();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                simpleCamera.Init(this.CameraContainer, 640, 480, this.textBoxDeviceName.Text);
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception.Message);
            }

            try
            {
                int result = feature.Init();
                SimpleConsole.WriteLine(string.Format("Init face feature mudle success.buffer size:{0}", result));
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception.Message);
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (simpleCamera.IsOpen) simpleCamera.Release();
            if (feature.IsInited) feature.Release();
        }

        private void Snapshot_Click(object sender, EventArgs e)
        {
            if (simpleCamera.IsOpen)
            {
                byte[] buffer = null;
                bool right = simpleCamera.Snapshot(out buffer);
                if (right && buffer != null)
                {
                    string filename = "c:\\a.jpg";
                    this.picSnapshot.Image = buffer.ToBitmap();
                    this.picSnapshot.Tag = filename;
                    buffer.ToBitmap().Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else
            {
                SimpleConsole.WriteLine("This camera is not open.");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.openFileDialog1.ShowDialog())
            {
                string filename = this.openFileDialog1.FileName;
                if (string.IsNullOrEmpty(filename))
                {
                    SimpleConsole.WriteLine("Pleae select image before");
                }
                else
                {
                    this.textBoxFilename.Text = filename;
                    this.picPhoto.Image = filename.Reader().ToBitmap();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.picPhoto.Image == null)
            {
                SimpleConsole.WriteLine("This source photo is null");
            }
            else if (this.picSnapshot.Image == null)
            {
                SimpleConsole.WriteLine("This snapshot image is null");
            }
            else
            {
                float result = feature.Compare(this.textBoxFilename.Text,this.picSnapshot.Tag.ToString());
                if (result == 0)
                {
                    this.lblTips.Text = " Error ";
                }
                else
                {
                    this.lblTips.Text = "" + result;
                }
            }
        }
    }
}
