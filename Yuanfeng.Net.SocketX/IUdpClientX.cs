using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Net.SocketX
{
    public interface IUdpClientX
    {
        /// <summary>
        /// 创建一个UDP客户端
        /// </summary>
        /// <param name="ipaddr">服务器IP地址（4）</param>
        /// <param name="port">服务器端口</param>
        void Create(string ipaddr,int port);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息内容（服务端须按发送格式解析）</param>
        void Send(object message);
        /// <summary>
        /// 关闭客户端
        /// </summary>
        void Close();
    }
}
