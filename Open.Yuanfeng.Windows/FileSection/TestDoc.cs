﻿using System;
using System.Windows.Forms;
using Yuanfeng.Smarty;
using Yuanfeng.WinFormsUI.Docking;

namespace Open.Yuanfeng.Windows.FileSection
{
    public partial class TestDoc : DockContent
    {
        public TestDoc()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            int totalDays = this.tbComputeBeginDate.Text.TryTotalDays();
            MessageBox.Show("共：" + totalDays.ToString());
        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            var a1 = this.tbComputeBeginDate.Text.TryDate();
            a1 = a1.AddDays(1).AddDays(-90);
            MessageBox.Show(a1.ToString("yyyy/MM/dd HH:mm:ss"));
        }
    }
}
