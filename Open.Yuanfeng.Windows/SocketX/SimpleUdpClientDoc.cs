using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.Log4netX;
using Yuanfeng.Net.SocketX;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.SocketX
{
    public partial class SimpleUdpClientDoc : DockContent
    {
        public SimpleUdpClientDoc()
        {
            InitializeComponent();
        }

        private IUdpClientX client = new SimpleUdpClient();
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                client.Send(this.tbMsg.Text.ToBuffer());
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception);
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                client.Create(tbSvrIpAddr.Text, TypeHelper.ParseInt(tbSvrPort.Text));
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            client.Close();
        }

        private IUdpLog log = SimpleUdpLog.NewInstance("192.168.100.2");
        private void btnBug_Click(object sender, EventArgs e)
        {
            log.Debug("UDP-Debug方式发送异常", new Exception("UDP-Debug发送异常"));
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            log.Error("UDP-Error方式发送异常", new Exception("UDP-Error发送异常"));
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            log.Info("UDP-Infor方式发送异常", new Exception("UDP-Info发送异常"));
        }

        private void btnFatal_Click(object sender, EventArgs e)
        {
            log.Fatal("UDP-Fatal方式发送异常", new Exception("UDP-Fatal发送异常"));
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            log.Release();
        }
    }
}
