using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Yuanfeng.Log4netX;
using Yuanfeng.Net.SocketX;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.SocketX
{
    public partial class SimpleUdpServerDoc : DockContent
    {
        public SimpleUdpServerDoc()
        {
            InitializeComponent();
        }
        private ILogX log = LogX.NewLogger(typeof(SimpleUdpClientDoc));
        private IUdpServerX server = new SimpleUdpServer();
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                server.Create(TypeHelper.ParseInt(tbSvrPort.Text), new OnReceivedMsgDelegate((string ipaddr, object msg) =>
                {
                    UdpMsg message = msg as UdpMsg;

                    switch (message.Level)
                    {
                        case Level.DEBUG:
                            log.Debug(message.Message, message.Exception);
                            break;
                        case Level.FATAL:
                            log.Fatal(message.Message, message.Exception);
                            break;
                        case Level.INFO:
                            log.Info(message.Message,message.Exception);
                            break;
                        case Level.ERROR:
                            log.Error(message.Message,message.Exception);
                            break;
                        default:
                            break;
                    }

                    this.Invoke(new Action(() =>
                    {
                        this.tbMsg.AppendText("[" + ipaddr + "]" + message.Message + Environment.NewLine);
                    }));
                    /*
                    SimpleConsole.WriteLine(msg);
                    this.Invoke(new Action(() =>
                    {
                        this.tbMsg.AppendText("[" + ipaddr + "]" + msg.ToString() + Environment.NewLine);
                    }));*/
                }));
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            server.Close();
        }
    }
}
