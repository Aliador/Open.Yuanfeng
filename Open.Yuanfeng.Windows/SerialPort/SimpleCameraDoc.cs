using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Yuanfeng.ExternalUnit.SerialCommPort.Camera;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.SerialPort
{
    public partial class SimpleCameraDoc : DockContent
    {
        public SimpleCameraDoc()
        {
            InitializeComponent();
        }
        private ICamera simpleCamera = new CameraDirectShowClass();
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

        }

        private void btnRealase_Click(object sender, EventArgs e)
        {
            try
            {
                simpleCamera.Realase();
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception.Message);
            }
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            Snapshot();
        }

        private void Snapshot()
        {
            try
            {
                byte[] snapshotImageBuffer = null;
                bool snapshot = simpleCamera.Snapshot(out snapshotImageBuffer);
                if (snapshot) this.SnapshotImage.Image = new Bitmap(new MemoryStream(snapshotImageBuffer));

                SimpleConsole.WriteLine("Snapshot.");
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception.Message);
            }
        }

        private void SimpleCameraDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.isStoped = true; System.Threading.Thread.Sleep(20);
            if (threadSnapshot != null && isStarted) threadSnapshot.Abort();//force exit child thread.
            else if (threadSnapshot != null) { threadSnapshot.Resume(); threadSnapshot.Abort(); }
            this.simpleCamera.Realase();
        }
        private bool isStoped = false;
        private bool isStarted = false;
        private System.Threading.Thread threadSnapshot;
        private void btnSnapshotSwitch_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                int count = 0;
                if (threadSnapshot == null || threadSnapshot.ThreadState == System.Threading.ThreadState.Stopped) threadSnapshot = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    while (true)
                    {
                        if (isStoped) break;
                        else
                        {
                            this.Invoke(new Action(() =>
                            {
                                Snapshot();
                                this.SnapshotCount.Text = "" + (++count);                               
                            }));
                            System.Threading.Thread.Sleep((int)this.SnapshotInterval.Value);
                            Application.DoEvents();
                        }
                    }

                }));

                if (threadSnapshot == null) throw new Exception("This thread snapshot is null.");

                if (threadSnapshot.ThreadState == System.Threading.ThreadState.Suspended) threadSnapshot.Resume();

                if (threadSnapshot.ThreadState == System.Threading.ThreadState.Unstarted) threadSnapshot.Start();

                this.btnSnapshotSwitch.Text = "End";
                isStarted = true;
            }
            else
            {
                if (threadSnapshot == null) return;

                threadSnapshot.Suspend();

                isStarted = false;

                this.btnSnapshotSwitch.Text = "Begin";
            }
        }
    }
}
