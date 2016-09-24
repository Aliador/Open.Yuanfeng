using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuanfeng.Computer.Network;

namespace Yuanfeng.Log4netX
{
    public class LogX : ILogX
    {
        private string ipaddr = string.Empty;
        private ILog log;
        private static LogX instance;
        private object message;
        private Exception exception;

        public static ILogX NewLogger()
        {
           if (instance == null) instance = new LogX(); return instance;
        }

        public static ILogX NewLogger(Type logger)
        {
            if (instance == null) instance = new LogX(logger); return instance;
        }

        public string IpAddr
        {
            get
            {
                return ipaddr;
            }

            set
            {
                ipaddr = value;
            }
        }

        private LogX() {
            ipaddr = NetworkInfoClass.GetLocalIpAddr();
            log = LogManager.GetLogger("Yuanfeng log4net extern");
        }

        private LogX(Type logger)
        {
            ipaddr = NetworkInfoClass.GetLocalIpAddr();
            log = LogManager.GetLogger(logger);
        }

        private void bindCustomProperties()
        {
            log4net.LogicalThreadContext.Properties["IpAddr"] = ipaddr;
        }

        #region 一般实现
        private void Info()
        {
            if (log == null) return;
            bindCustomProperties();
            log.Info(message, exception);
        }

        private void Error()
        {
            if (log == null) return;
            bindCustomProperties();
            log.Error(message, exception);
        }

        private void Debug()
        {
            if (log == null) return;
            bindCustomProperties();
            log.Debug(message, exception);
        }

        private void Fatal()
        {
            if (log == null) return;
            bindCustomProperties();
            log.Fatal(message, exception);
        }
        #endregion

        #region 错误日志
        public void Error(object message)
        {
            this.message = message;
            Error();
        }
        public void Error(object message, Exception exception)
        {
            this.message = message;
            this.exception = exception;
            Error();
        }
        public void Error(string ipaddr, object message, Exception exception)
        {
            this.ipaddr = ipaddr;
            this.message = message;
            this.exception = exception;
            Error();
        }
        #endregion

        #region 一般消息
        public void Info(object message)
        {
            this.message = message;
            Info();
        }
        public void Info(object message, Exception exception)
        {
            this.message = message;
            this.exception = exception;
            Info();
        }
        public void Info(string ipaddr, object message, Exception exception)
        {
            this.ipaddr = ipaddr;
            this.message = message;
            this.exception = exception;
            Info();
        }
        #endregion

        #region 调试信息
        public void Debug(object message)
        {
            this.message = message;
            Debug();
        }
        public void Debug(object message, Exception exception)
        {
            this.message = message;
            this.exception = exception;
            Debug();
        }
        public void Debug(string ipaddr, object message, Exception exception)
        {
            this.ipaddr = ipaddr;
            this.message = message;
            this.exception = exception;
            Debug();
        }
        #endregion

        #region 致命错误
        public void Fatal(object message)
        {
            this.message = message;
            Fatal();
        }
        public void Fatal(object message, Exception exception)
        {
            this.message = message;
            this.exception = exception;
            Fatal();
        }
        public void Fatal(string ipaddr, object message, Exception exception)
        {
            this.ipaddr = ipaddr;
            this.message = message;
            this.exception = exception;
            Fatal();
        }
        #endregion
    }
}
