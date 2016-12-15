using Newtonsoft.Json;
using System;
using Yuanfeng.WinFormsUI.Docking;
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
                server.Create(TypeHelper.ParseInt(tbSvrPort.Text), new OnReceivedMsgDelegate((string ipaddr,object msg) =>
                {
                    //UdpMsg message = JsonConvert.DeserializeObject<UdpMsg>(msg.ToString());
                    /*
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
                    */
                    
                    SimpleConsole.WriteLine(((byte[])msg).BufferToStr());
                    this.Invoke(new Action(() =>
                    {
                        this.tbMsg.AppendText("[" + ipaddr + "]" +((byte[]) msg).BufferToStr() + Environment.NewLine);
                    }));
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
