using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using Yuanfeng.ExternalUnit.SerialCommPort.Yuanjingda;

namespace Open.Yuanfeng.Windows.SerialPort
{
    public partial class YuanjingdaDoc : DockContent
    {
        public YuanjingdaDoc()
        {
            InitializeComponent();
        }
        private ILongView420R longView420R;
        private void YuanjingdaDoc_Load(object sender, EventArgs e)
        {
            this.cmbDeviceName.SelectedIndex = 0;
            this.cmbSerialPortName.SelectedIndex = 2;
        }

        private void cmbDeviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDeviceName.SelectedIndex == 0) longView420R = new LongView420TwOprCmdClass();
        }
        int count = 0;
        private void btnInit_Click(object sender, EventArgs e)
        {
            int index = this.cmbSerialPortName.SelectedIndex;

            string serialPort = "COM" + (index + 1);
            longView420R.Init(serialPort, (SerialPortReceivedData arg) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    this.tbReceivedData.AppendText(string.Format("{0}:[size={1}] {2}\r\n", ++count, arg.Size, arg.Data));
                }));
            });
        }

        private void btnRealase_Click(object sender, EventArgs e)
        {
            longView420R.Realase();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            longView420R.Open();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            longView420R.Close();
        }

        private void btnOpenOnline_Click(object sender, EventArgs e)
        {
            longView420R.OpenOnLine();
        }
    }
}
