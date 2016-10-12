using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuanfeng.Log4netX;
using Yuanfeng.Net.SocketX;
using Yuanfeng.Smarty;

namespace Yuanfeng.Log4netx.UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "[Yuanfeng] Log UDP Server v1.0";
            Console.WriteLine("正在启动日志服务...");

            ILogX log = LogX.NewLogger(typeof(Program));
            IUdpServerX server = new SimpleUdpServer();

            server.Create(8000, new OnReceivedMsgDelegate((string ipaddr, object obj) =>
            {
                UdpMsg msg = obj as UdpMsg;
                switch (msg.Level)
                {
                    case Level.DEBUG:
                        log.Debug(msg.Logger, msg.Message, msg.Exception);
                        break;
                    case Level.FATAL:
                        log.Fatal(msg.Logger, msg.Message, msg.Exception);
                        break;
                    case Level.INFO:
                        log.Info(msg.Logger, msg.Message, msg.Exception);
                        break;
                    case Level.ERROR:
                        log.Error(msg.Logger, msg.Message, msg.Exception);
                        break;
                    default:
                        break;
                }
                Console.Write("[" + ipaddr + "]");
                Console.Write(msg.Message + ",");
                Console.WriteLine(msg.Exception);
            }));
            Console.WriteLine("启动成功，退出系统[exit]");
            while (true)
            {
                string line = Console.ReadLine();
                if ("exit".Equals(line))
                {
                    server.Close();
                    break;
                }
            }
        }
    }
}
