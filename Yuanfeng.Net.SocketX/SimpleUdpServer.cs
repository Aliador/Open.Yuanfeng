using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Yuanfeng.Computer.Network;
using Yuanfeng.Smarty;

namespace Yuanfeng.Net.SocketX
{
    public class SimpleUdpServer : IUdpServerX
    {
        private OnReceivedMsgDelegate onReceivedMsgDelegate;
        private int port = 8000;
        private string localIpAddr = string.Empty;
        private UdpClient simpleSvrClient;
        private System.Threading.Thread threadlistener;
        private bool isOpen = false;
        public void Close()
        {
            if (isOpen && simpleSvrClient != null)
            {
                threadlistener.Abort();
                simpleSvrClient.Close(); isOpen = false;
            }
        }

        private void Listener(object arg)
        {
            if (simpleSvrClient == null) return;
            var udpServer = arg as UdpClient;
            if (udpServer == null) throw new Exception("UdpClient不能为空");
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7788);
            while (true)
            {
                byte[] buffer = udpServer.Receive(ref remoteIpEndPoint);
                if (buffer == null) continue;
                if (onReceivedMsgDelegate != null) { onReceivedMsgDelegate.Invoke(remoteIpEndPoint.Address.ToString(),buffer.Deserialize());  }
            }
        }

        public void Create(int port,OnReceivedMsgDelegate onReceivedMsgDelegate)
        {
            this.port = port;
            this.onReceivedMsgDelegate = onReceivedMsgDelegate;
            if (string.IsNullOrEmpty(localIpAddr)) localIpAddr = NetworkInfoClass.GetLocalIpAddr();
            simpleSvrClient = new UdpClient(new IPEndPoint(IPAddress.Parse(localIpAddr), port));
            threadlistener = new System.Threading.Thread(Listener);
            threadlistener.Start(simpleSvrClient);
            isOpen = true;
        }
    }
}
