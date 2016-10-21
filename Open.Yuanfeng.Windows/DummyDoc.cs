using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.Controls.Simple;

namespace Open.Yuanfeng.Windows
{
    public partial class DummyDoc : DockContent
    {
        public DummyDoc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpaquePlayerController.New().Show(this);   
        }
    }
}
