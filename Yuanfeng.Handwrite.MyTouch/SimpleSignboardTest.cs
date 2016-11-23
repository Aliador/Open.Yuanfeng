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
    public partial class SimpleSignboardTest : Form
    {
        public SimpleSignboardTest()
        {
            InitializeComponent();
        }

        private void SimpleSignboardTest_Load(object sender, EventArgs e)
        {
            this.simpleSignboardControl1.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.simpleSignboardControl1.GetSignImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.simpleSignboardControl1.Clear();
        }
    }
}
