using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Yuanfeng.Smarty
{
    public static class SimpleConsole
    {
        private static object[] inter = new object[] { };
        private const string path = "log";
        private const string consolefilename = "log/console.log";
        public static void Write(object value)
        {
            lock (consolefilename)
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (!File.Exists(consolefilename)) File.CreateText(consolefilename);
                using (FileStream fs = new FileStream(consolefilename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.AutoFlush = true; writer.Write(value);
                    }
                }
            }
        }

        public static void WriteLine(object value)
        {
            lock (consolefilename)
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (!File.Exists(consolefilename)) File.CreateText(consolefilename);
                using (FileStream fs = new FileStream(consolefilename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        StringBuilder sbline = new StringBuilder();
                        sbline.Append("[");
                        sbline.Append(DateTime.Now);
                        sbline.Append("]");
                        sbline.Append(value);
                        writer.AutoFlush = true; writer.WriteLine(sbline);
                    }
                }
            }
        }
    }
}
