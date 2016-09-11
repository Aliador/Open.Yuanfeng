using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Yuanfeng.ImageUtil.QrCode;
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
    }
}
