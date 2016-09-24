using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Log4netx
{
    public class Logx
    {
        private ILog log = LogManager.GetLogger(typeof(AppDomain));
        private static Logx instance;

        public static Logx Instance()
        {
            if (instance == null) instance = new Logx(); return instance;
        }

        public void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }
    }
}
