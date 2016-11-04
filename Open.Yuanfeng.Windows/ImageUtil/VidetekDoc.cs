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
    public partial class VidetekDoc : DockContent
    {
        public VidetekDoc()
        {
            InitializeComponent();
        }

        private IFaceFeatureContoller controller = VidetekController.New();

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pbImg1.Image = openFileDialog1.FileName.Reader().ToBitmap();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pbImg2.Image = openFileDialog1.FileName.Reader().ToBitmap();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = controller.Init();
            MessageBox.Show(result.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float core = controller.Compare(this.pbImg1.Image.ToBuffer(), this.pbImg2.Image.ToBuffer());
            this.label1.Text = "Comare completed score=" + core;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controller.Release();
        }
    }
}
