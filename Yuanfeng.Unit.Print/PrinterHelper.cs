using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Yuanfeng.Unit.Print
{
    public class PrinterHelper
    {
        public static int ClearJob()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PrintJob");

            ManagementObjectCollection printerJobs = searcher.Get();

            int deleteCounts = 0;
            foreach (ManagementObject item in printerJobs)
            {
                item.Delete();deleteCounts += 1;
            }
            return deleteCounts;
        }
    }
}
