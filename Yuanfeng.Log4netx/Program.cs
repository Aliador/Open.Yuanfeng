using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Log4netx
{
   
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*
            ILog log = LogManager.GetLogger(typeof(AppDomain));

            log.Debug("这里是debug方法", new Exception("空指针异常"));
            log.Info("这里是info方法",new Exception("空指针异常"));
            log.Error("这里是error方法", new Exception("空指针异常"));
            log.Fatal("这里是fatal方法", new Exception("空指针异常"));
            
             */

            ILogx log = Logx.NewLogger();
            //log.IpAddr = "127.0.0.1";
            log.Error("这里扩展方法", new Exception("特殊异常"));
            Console.ReadKey();
        }
    }
}
