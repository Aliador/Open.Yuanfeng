using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.HttpX;

namespace Open.Yuanfeng.Windows.HttpX
{
    public partial class DynamicHttpRequest : DockContent
    {
        public DynamicHttpRequest()
        {
            InitializeComponent();
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {

            string[] args = null;
            if (!string.IsNullOrEmpty(this.tbArgs.Text)) args = this.tbArgs.Text.Split(',');

            HttpStaticRequest.InvokeWebService(this.tbUrl.Text, "Open.Yuanfeng.Windows.HttpX", this.tbMethod.Text,args, new HttpStaticRequest.ASyncResultCallback((object result) =>
            {
                string xml = (string)result;
                this.Invoke(new Action(() =>
                {
                    this.tbResponse.AppendText(xml + Environment.NewLine);
                }));
            }));
        }
    }
}
