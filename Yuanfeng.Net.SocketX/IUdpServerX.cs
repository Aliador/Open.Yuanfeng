using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Net.SocketX
{
    public delegate void OnReceivedMsgDelegate(string ipaddr, object message);
    public interface IUdpServerX
    {
        void Create(int port, OnReceivedMsgDelegate onReceivedMsgDelegate);
        void Close();
        string IpAddr { get; }
        List<string> Clients { get;}
    }
}
