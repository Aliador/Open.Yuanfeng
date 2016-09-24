using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Log4netx
{
    public interface ILogx
    {
        void Error(string ipaddr, object message, Exception exception);
    }
}
