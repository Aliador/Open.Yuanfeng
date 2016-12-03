using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuanfeng.Unit.Print
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int counts = PrinterHelper.ClearJob();
            Console.Write(counts);
            Console.ReadKey();
            //FreeConsole();
        }
    }
}
