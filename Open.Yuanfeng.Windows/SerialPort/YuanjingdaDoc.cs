using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;

using Yuanfeng.Unit.SerialCommPort.Yuanjingda;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.SerialPort
{
    public partial class YuanjingdaDoc : DockContent
    {
        public YuanjingdaDoc()
        {
            InitializeComponent();
        }
        private ILongView longView;
        private void YuanjingdaDoc_Load(object sender, EventArgs e)
        {
            this.cmbDeviceName.SelectedIndex = 0;
            this.cmbSerialPortName.SelectedIndex = 2;
        }

        private void cmbDeviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDeviceName.SelectedItem.ToString().Contains("420"))
            {
                longView = new LongView420TwOprCmdClass();
                this.btnOpenOnline.Enabled = true;
            }
            else if (this.cmbDeviceName.SelectedItem.ToString().Contains("100"))
            {
                longView = new LongView100TwOprCmdClass();
                this.btnOpenOnline.Enabled = false;
            }
        }
        int count = 0;
        int matchCount = 0;
        private void btnInit_Click(object sender, EventArgs e)
        {
            if (longView.IsOpen)
            {
                SimpleConsole.WriteLine("This lv420r was init"); return;
            }

            matchCount = 0;
            int index = this.cmbSerialPortName.SelectedIndex;

            string serialPort = "COM" + (index + 1);
            longView.Init(serialPort, (SerialPortReceivedData arg) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    SimpleConsole.WriteLine(arg.Data);

                    int len1 = arg.Data.Length;
                    int len2 = UtilClass.RemoveNotNum(arg.Data).Length;
                    if (len1 != len2) MatchCount.Text = (++matchCount) + "";

                    this.tbReceivedData.AppendText(string.Format("{0} [Size={1}] {2}\r\n", ++count, arg.Size, arg.Data));
                }));
            });
            SimpleConsole.WriteLine(string.Format("This yuanjingda lv420r init {0}.", this.longView.IsOpen ? "successed" : "faild"));
        }

        private void btnRealase_Click(object sender, EventArgs e)
        {
            if (longView.IsOpen)
            {
                longView.Realase(); SimpleConsole.WriteLine("This lv420 is realased.");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (longView.IsOpen)
            {
                longView.Open(); SimpleConsole.WriteLine("This lv420r started.");
            }
            else SimpleConsole.WriteLine("This lv420r is realased please open.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (longView.IsOpen)
            {
                longView.Close(); SimpleConsole.WriteLine("This lv420r closed.");
            }
            else SimpleConsole.WriteLine("This lv420r is not open.");
        }

        private void btnOpenOnline_Click(object sender, EventArgs e)
        {
            if (longView.IsOpen) ((ILongView420R)longView).OpenOnLine();
        }

        private void YuanjingdaDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (longView.IsOpen) longView.Realase();
        }

        private void btnLiveScan_Click(object sender, EventArgs e)
        {
            if (longView.IsOpen) longView.LiveScan();
        }
    }
}
