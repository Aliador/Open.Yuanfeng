using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.Smarty;
using Yuanfeng.Controls.Simple;
using Yuanfeng.Controls.Palette;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class ImageColorDoc : DockContent
    {
        public ImageColorDoc()
        {
            InitializeComponent();
        }

        private void btnSelectPic_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                this.pbOldPic.Image = filename.Reader().ToBitmap();
            }
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            var picker = new GUI();
            if (picker.ShowDialog() == DialogResult.OK)
            {
                this.pbPickColor.BackColor = picker.PickColor;
            }
        }

        private void btnClearColor_Click(object sender, EventArgs e)
        {
            this.pbNewPic.Image = this.pbOldPic.Image.ClearColor(this.pbPickColor.BackColor);
        }

        private void btnPalette_Click(object sender, EventArgs e)
        {
            var picker = new HSLPalette();
            picker.ShowDialog();
            this.pbPickColor.BackColor = picker.PickColor;
        }

        private void trackBarOffset_Scroll(object sender, EventArgs e)
        {
            if (this.pbNewPic.Image != null)
            {
                this.pbNewPic.Image = this.pbNewPic.Image.ClearColor(this.pbPickColor.BackColor, this.trackBarOffset.Value);
                this.pbNewPic.Image.Save(@"d:\tmp.bmp");
            }
        }
    }
}
