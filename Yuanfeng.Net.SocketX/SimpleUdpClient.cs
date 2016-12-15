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
    public class SimpleUdpClient : IUdpClientX
    {
        private string svrIpAddr = string.Empty;
        private int svrPort = 8000;

        private bool isOpen = false;

        private UdpClient simpleUdpClient;

        public void Close()
        {
            if (simpleUdpClient != null) simpleUdpClient.Close(); isOpen = false;
        }

        public void Create(string ipaddr, int port)
        {
            this.svrIpAddr = ipaddr;
            this.svrPort = port;

            if (isOpen) return;

            try
            {
                if (string.IsNullOrEmpty(svrIpAddr)) throw new Exception("指定服务器IP地址无效");

                simpleUdpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(NetworkInfoClass.GetLocalIpAddr()), 7788));
                simpleUdpClient.Connect(IPAddress.Parse(svrIpAddr), port);
                isOpen = true;
            }
            catch (Exception exception)
            {
                throw exception;
            };
        }

        public void Send(object message)
        {
            if (simpleUdpClient == null) throw new Exception("没有创建客户端");

            if (message == null) throw new Exception("目标数据不能为空");

            var threadSendBuffer = new System.Threading.Thread((object arg) =>
            {
                UdpClient client = arg as UdpClient;
                byte[] buffer = message.Serialize();
                client.Send(buffer, buffer.Length);
            });

            threadSendBuffer.Start(simpleUdpClient);
        }
    }
}
