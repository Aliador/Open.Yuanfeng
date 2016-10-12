using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Yuanfeng.Log4netX
{
    [XmlRootAttribute("UdpMsg")]
    [Serializable]
    public class UdpMsg
    {
        [XmlAttribute("Level")]
        public Level Level { get; set; }
        [XmlAttribute("IpAddr")]
        public string IpAddr { get; set; }
        [XmlAttribute("Logger")]
        public string Logger { get; set; }
        [XmlAttribute("Message")]
        public object Message { get; set; }
        [XmlAttribute("Exception")]
        public Exception Exception { get; set; }
    }
    [XmlRootAttribute("UdpMsg")]
    [Serializable]
    public enum Level
    {
        DEBUG,FATAL,INFO,ERROR
    }
}
