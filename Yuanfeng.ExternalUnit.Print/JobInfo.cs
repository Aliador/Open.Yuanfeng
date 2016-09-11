using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.ExternalUnit.Print
{
    public class JobInfo
    {
        public string Name { get; set; }

        public Stream Job { get; set; }
        
        public bool Cancel { get; set; }
    }
}
