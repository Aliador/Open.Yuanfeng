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

namespace Open.Yuanfeng.Windows.Print
{
    public partial class SimplePrintDoc : DockContent
    {
        public SimplePrintDoc()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            TextDocPrintHelper printer = new TextDocPrintHelper();
        }
    }
}
