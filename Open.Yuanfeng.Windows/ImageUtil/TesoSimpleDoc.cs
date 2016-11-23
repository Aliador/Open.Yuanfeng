using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.Unit.FaceFeatureCompare;
using System.Threading;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class TesoSimpleDoc : DockContent
    {
        public TesoSimpleDoc()
        {
            InitializeComponent();
        }
        private TesoSimpleControl ulfControl1;
        private void btnOpen_Click(object sender, EventArgs e)
        {
           bool result = this.ulfControl1.Start(new LiveRecongtionCompletedHandler((string a, string b) =>
            {
                MessageBox.Show(a.Length.ToString());
                MessageBox.Show(b.Length.ToString());
            }));
            MessageBox.Show(result.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ulfControl1.Close();
        }

        private void TesoSimpleDoc_Load(object sender, EventArgs e)
        {
            ulfControl1 = new TesoSimpleControl(); this.Controls.Add(ulfControl1);
        }
    }
}
