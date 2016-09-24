using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        ///<summary> 
        /// 序列化 
        /// </summary> 
        /// <param name="obj">要序列化的对象</param> 
        /// <returns>返回存放序列化后的数据缓冲区</returns> 
        public static byte[] Serialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return stream.GetBuffer();
            }
        }

        /// <summary> 
        /// 反序列化 
        /// </summary> 
        /// <param name="obj">数据缓冲区</param> 
        /// <returns>对象</returns> 
        public static object Deserialize(byte[] obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(obj))
            {
                obj = null;
                return formatter.Deserialize(stream);
            }
        }
    }
}
