using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Yuanfeng.Smarty
{
    public class TypeHelper
    {
        public static string ParseString(object obj)
        {
            return (obj == null) ? string.Empty : obj.ToString();
        }

        public static bool IsInt(string value)
        {
            int num;
            return TypeHelper.IsInt(value, out num);
        }

        public static bool IsInt(string value, out int val)
        {
            bool result;
            if (string.IsNullOrEmpty(value))
            {
                val = 0;
                result = false;
            }
            else
            {
                result = int.TryParse(value, out val);
            }
            return result;
        }

        public static int ParseInt(object source)
        {
            return TypeHelper.ParseInt(source, 0);
        }

        public static int ParseInt(object source, int DefaultValue)
        {
            string value = TypeHelper.ParseString(source);
            int result;
            int num;
            if (string.IsNullOrEmpty(value))
            {
                result = DefaultValue;
            }
            else if (TypeHelper.IsInt(value, out num))
            {
                result = num;
            }
            else
            {
                result = DefaultValue;
            }
            return result;
        }

        public static bool IsLong(string value)
        {
            long num;
            return TypeHelper.IsLong(value, out num);
        }

        public static bool IsLong(string value, out long val)
        {
            bool result;
            if (string.IsNullOrEmpty(value))
            {
                val = 0L;
                result = false;
            }
            else
            {
                result = long.TryParse(value, out val);
            }
            return result;
        }

        public static long ParseLong(object source)
        {
            return TypeHelper.ParseLong(source, 0L);
        }

        public static long ParseLong(object source, long DefaultValue)
        {
            string value = TypeHelper.ParseString(source);
            long result;
            long num;
            if (string.IsNullOrEmpty(value))
            {
                result = DefaultValue;
            }
            else if (TypeHelper.IsLong(value, out num))
            {
                result = num;
            }
            else
            {
                result = DefaultValue;
            }
            return result;
        }

        public static bool IsDecimal(string value)
        {
            decimal num;
            return TypeHelper.IsDecimal(value, out num);
        }

        public static bool IsDecimal(string value, out decimal val)
        {
            bool result;
            if (string.IsNullOrEmpty(value))
            {
                val = 0m;
                result = false;
            }
            else
            {
                result = decimal.TryParse(value, out val);
            }
            return result;
        }

        public static decimal ParseDecimal(object source)
        {
            return TypeHelper.ParseDecimal(source, 0m);
        }

        public static decimal ParseDecimal(object source, decimal DefaultValue)
        {
            string value = TypeHelper.ParseString(source);
            decimal result;
            decimal num;
            if (string.IsNullOrEmpty(value))
            {
                result = DefaultValue;
            }
            else if (TypeHelper.IsDecimal(value, out num))
            {
                result = num;
            }
            else
            {
                result = DefaultValue;
            }
            return result;
        }

        public static bool IsUint(string value)
        {
            uint num;
            return !string.IsNullOrEmpty(value) && uint.TryParse(value, out num);
        }

        public static bool IsDateTime(object source)
        {
            string text = TypeHelper.ParseString(source);
            DateTime dateTime;
            return !string.IsNullOrEmpty(text) && DateTime.TryParse(text, out dateTime);
        }

        public static DateTime ParseDateTime(object source)
        {
            return TypeHelper.ParseDateTime(source, DateTime.Now);
        }

        public static DateTime ParseDateTime(object source, DateTime DefalutValue)
        {
            string text = TypeHelper.ParseString(source);
            DateTime result;
            DateTime dateTime;
            if (string.IsNullOrEmpty(text))
            {
                result = DefalutValue;
            }
            else if (DateTime.TryParse(text, out dateTime))
            {
                if (dateTime >= DateTime.Parse("1753-1-2 00:00:00") && dateTime <= DateTime.Parse("9999-12-31 11:59:59"))
                {
                    result = dateTime;
                }
                else
                {
                    result = DefalutValue;
                }
            }
            else
            {
                result = DefalutValue;
            }
            return result;
        }        

        public static int BoolToInt(bool val)
        {
            return val ? 1 : 0;
        }

        public static bool IntToBool(int val)
        {
            return val == 1;
        }
    }
}
