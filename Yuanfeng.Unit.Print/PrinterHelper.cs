using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Printing;
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

        /// <summary>
        /// Cancel Print Job
        /// </summary>
        /// <param name="printName"></param>
        public static void ClearJob(string printName)
        {
            PrintServer localPrintServer = new LocalPrintServer();
            PrintQueue pq = localPrintServer.GetPrintQueue(printName);
            pq.Refresh();
            PrintJobInfoCollection allPrintJobs = pq.GetPrintJobInfoCollection();
            foreach (PrintSystemJobInfo printJob in allPrintJobs)
            {
                printJob.Cancel();
            }
        }
    }
}
