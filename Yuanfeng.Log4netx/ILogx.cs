using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Log4netX
{
    public interface ILogX
    {
        /// <summary>
        /// 客户端IP（默认使用本机IP）
        /// </summary>
        string IpAddr { get; set; }

        void Error(object message);
        void Info(object message);
        void Debug(object message);
        void Fatal(object message);

        void Error(object message, Exception exception);
        void Info(object message, Exception exception);
        void Debug(object message, Exception exception);
        void Fatal(object message, Exception exception);

        void Error(string ipaddr,object message, Exception exception);
        void Info(string ipaddr, object message, Exception exception);
        void Debug(string ipaddr, object message, Exception exception);
        void Fatal(string ipaddr, object message, Exception exception);
    }
}
