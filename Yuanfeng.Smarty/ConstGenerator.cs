using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Smarty
{
    public class ConstGenerator
    {
        public static string UseTimeId()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
    }
}
