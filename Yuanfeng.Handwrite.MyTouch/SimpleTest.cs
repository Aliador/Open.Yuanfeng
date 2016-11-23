using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Handwrite.MyTouch
{
    public partial class SimpleTest : Form
    {
        public SimpleTest()
        {
            InitializeComponent();
        }

        private void SimpleTest_Load(object sender, EventArgs e)
        {
            this.simpleHandwriteControl1.Init();
        }
    }
}
