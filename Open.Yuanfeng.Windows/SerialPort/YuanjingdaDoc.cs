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
using Yuanfeng.Smarty;

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
            if (longView420R.IsOpen)
            {
                SimpleConsole.WriteLine("This lv420r was init"); return;
            }

            int index = this.cmbSerialPortName.SelectedIndex;

            string serialPort = "COM" + (index + 1);
            longView420R.Init(serialPort, (SerialPortReceivedData arg) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    SimpleConsole.WriteLine(arg.Data);
                    this.tbReceivedData.AppendText(string.Format("{0}:[size={1}] {2}\r\n", ++count, arg.Size, arg.Data));
                }));
            });
            SimpleConsole.WriteLine(string.Format("This yuanjingda lv420r init {0}.", this.longView420R.IsOpen ? "successed" : "faild"));
        }

        private void btnRealase_Click(object sender, EventArgs e)
        {
            if (longView420R.IsOpen)
            {
                longView420R.Realase(); SimpleConsole.WriteLine("This lv420 is realased.");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (longView420R.IsOpen)
            {
                longView420R.Open(); SimpleConsole.WriteLine("This lv420r started.");
            }
            else SimpleConsole.WriteLine("This lv420r is realased please open.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (longView420R.IsOpen)
            {
                longView420R.Close(); SimpleConsole.WriteLine("This lv420r closed.");
            }
            else SimpleConsole.WriteLine("This lv420r is not open.");
        }

        private void btnOpenOnline_Click(object sender, EventArgs e)
        {
            if (longView420R.IsOpen) longView420R.OpenOnLine();
        }

        private void YuanjingdaDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (longView420R.IsOpen) longView420R.Realase();
        }
    }
}
