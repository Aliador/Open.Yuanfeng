using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Yuanfeng.Net.SocketX;
using Yuanfeng.Smarty;

namespace Yuanfeng.Log4netX
{
    public class SimpleUpdLogManager
    {
        private const int port = 8000;
        private static Dictionary<string, IUdpClientX> clients = new Dictionary<string, IUdpClientX>();
        public static SimpleUdpLog Create(string ipaddr, string logger)
        {
            if (!clients.ContainsKey(ipaddr))
            {
                var temp = new SimpleUdpClient();
                temp.Create(ipaddr, port);
                clients.Add(ipaddr, temp);
            }
            var client = clients[ipaddr];
            return new SimpleUdpLog(client, logger);
        }
    }

    public class SimpleUdpLog : IUdpLog
    {
        private SimpleUdpLog instance;
        private IUdpClientX client;
        private string ipaddr;
        private UdpMsg message = new UdpMsg();

        private string logger;

        public SimpleUdpLog(IUdpClientX client, string logger)
        {
            this.client = client;
            this.logger = logger;
        }

        private void SendMsg()
        {
            message.IpAddr = ipaddr;
            message.Logger = logger;
            client.Send(message);
        }

        public void Debug(object message)
        {
            this.message.Message = message;
            this.message.Level = Level.DEBUG;
            SendMsg();
        }

        public void Debug(object message, Exception exception)
        {
            this.message.Message = message;
            this.message.Exception = exception;
            this.message.Level = Level.DEBUG;
            SendMsg();
        }

        public void Error(object message)
        {
            this.message.Message = message;
            this.message.Level = Level.ERROR;
            SendMsg();
        }

        public void Error(object message, Exception exception)
        {
            this.message.Message = message;
            this.message.Exception = exception;
            this.message.Level = Level.ERROR;
            SendMsg();
        }

        public void Fatal(object message)
        {
            this.message.Message = message;
            this.message.Level = Level.FATAL;
            SendMsg();
        }

        public void Fatal(object message, Exception exception)
        {
            this.message.Message = message;
            this.message.Exception = exception;
            this.message.Level = Level.FATAL;
            SendMsg();
        }

        public void Info(object message)
        {
            this.message.Message = message;
            this.message.Level = Level.INFO;
            SendMsg();
        }

        public void Info(object message, Exception exception)
        {
            this.message.Message = message;
            this.message.Exception = exception;
            this.message.Level = Level.INFO;
            SendMsg();
        }
    }
}
