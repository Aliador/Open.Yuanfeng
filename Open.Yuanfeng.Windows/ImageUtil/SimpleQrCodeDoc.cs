using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.Unit.QrCode;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class SimpleQrCodeDoc : DockContent
    {
        public SimpleQrCodeDoc()
        {
            InitializeComponent();
        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {
            BaseQrCode simpleQrCode = new BaseQrCode(QrCodeString.Text, (int)QrCodeSize.Value);
            this.QrCodeImage.Image = simpleQrCode.Generator().ToBitmap();
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (this.QrCodeImage.Image != null) this.QrCodeImage.Image.Save(@"d:\qrcode.bmp");
        }

        private void btnLoadLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "bmp|*.bmp|jpg|*.jpg|png|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                this.LogoImage.Image = Image.FromFile(filename);
            }
        }

        private void btnMargeLogo_Click(object sender, EventArgs e)
        {
            ImageExternalClass util = new ImageExternalClass();
            this.QrCodeImage.Image = util.MergeQrImg((Bitmap)this.QrCodeImage.Image, (Bitmap)this.LogoImage.Image);
        }

        private void btnTrafficGen_Click(object sender, EventArgs e)
        {
            this.QrCodeImage.Image = TrafficPoliceQrCode.NewQrCode(QrCodeString.Text);
        }
    }
}
