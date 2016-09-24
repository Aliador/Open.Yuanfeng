using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuanfeng.Net.SocketX;

namespace Yuanfeng.Log4netX
{
    public class SimpleUdpLog : IUdpLog
    {
        private static SimpleUdpLog instance;
        private IUdpClientX client;
        private string ipaddr;
        private UdpMsg message = new UdpMsg();
        private Type logger;

        private SimpleUdpLog(string ipaddr)
        {
            this.ipaddr = ipaddr;
            this.message.Logger = logger;
            client = new SimpleUdpClient();
            client.Create(ipaddr, 8000);
        }

        private SimpleUdpLog(string ipaddr, Type logger)
        {
            this.logger = logger;
            this.ipaddr = ipaddr;
            this.message.Logger = logger;
            client = new SimpleUdpClient();
            client.Create(ipaddr, 8000);
        }

        public static SimpleUdpLog NewInstance()
        {
            if (instance == null) instance = new SimpleUdpLog("127.0.0.1");
            return instance;
        }

        public static SimpleUdpLog NewInstance(string ipaddr)
        {
            if (instance == null) instance = new SimpleUdpLog(ipaddr);
            return instance;
        }


        public static SimpleUdpLog NewInstance(string ipaddr, Type logger)
        {
            if (instance == null) instance = new SimpleUdpLog(ipaddr, logger);
            return instance;
        }

        private void SendMsg()
        {
            if (logger == null) logger = typeof(SimpleUdpLog);
            message.IpAddr = ipaddr;
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

        public void Release()
        {
            if (client != null) client.Close();
        }
    }
}
