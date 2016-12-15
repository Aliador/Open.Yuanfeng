using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Log4netX
{
    public interface IUdpLog
    {
        void Error(object message);
        void Info(object message);
        void Debug(object message);
        void Fatal(object message);

        void Error(object message, Exception exception);
        void Info(object message, Exception exception);
        void Debug(object message, Exception exception);
        void Fatal(object message, Exception exception);
    }
}
