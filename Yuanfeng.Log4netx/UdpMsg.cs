using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Log4netX
{
    [Serializable]
    public class UdpMsg
    {
        public Level Level { get; set; }
        public string IpAddr { get; set; }
        public Type Logger { get; set; }
        public object Message { get; set; }
        public Exception Exception { get; set; }
    }

    [Serializable]
    public enum Level
    {
        DEBUG,FATAL,INFO,ERROR
    }
}
