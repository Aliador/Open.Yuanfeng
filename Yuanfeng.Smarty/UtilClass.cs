using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Smarty
{
    /// <summary>
    /// some thing tool / method
    /// </summary>
    public class UtilClass
    {
        public static string RemoveNotNum(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string match = "0123456789";
            char[] chars = s.ToCharArray();
            List<char> newchars = new List<char>();
            foreach (char c in chars)
            {
                if (match.IndexOf(c) >= 0) newchars.Add(c);
            }

            return new string(newchars.ToArray<char>());
        }
    }
}
