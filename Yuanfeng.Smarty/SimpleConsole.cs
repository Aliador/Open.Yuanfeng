using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Yuanfeng.Smarty
{
    public static class SimpleConsole
    {
        private const string path = "log";
        public static void Write(object value)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string name = "console.log";

            string filename = Path.Combine(path, name);

            TextWriter writer = Console.Out;

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fs))
                {
                    streamWriter.Write(value);
                    //Console.SetOut(streamWriter);
                }
            }
        }

        public static void WriteLine(object line)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string name = "console.log";

            string filename = Path.Combine(path, name);

            TextWriter writer = Console.Out;

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fs))
                {
                    streamWriter.WriteLine(line);
                    //Console.SetOut(streamWriter);
                }
            }
        }
    }
}
