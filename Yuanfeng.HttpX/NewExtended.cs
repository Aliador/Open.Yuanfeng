using Newtonsoft.Json;
using System;
using System.Text;
using Yuanfeng.Smarty;

namespace Yuanfeng.HttpX
{

    public static class NewExtended
    {
        public static TransObject ToTransObj(this string obj)
        {
            try
            {
                return JsonConvert.DeserializeObject<TransObject>(obj);
            }
            catch { return new TransObject(false,obj,-1); }
        }
        /// <summary>
        /// 解密出的字符串为BASE64格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DecryptX(this string obj)
        {
            if (obj.Length > 3 && "0x1".Equals(obj.Substring(0, 3)))
            {
                int len = obj.Length;
                return obj.Substring(3, len - 3).Decrypt();
            }
            else
            {
                return obj;
            }
        }

        /// <summary>
        /// 解密BASE64格式字符串
        /// </summary>
        /// <param name="obj">BASE64字符串</param>
        /// <returns></returns>
        public static string DecryptBase64(this string obj)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(obj));
        }

        /// <summary>
        /// 将本对象序列化成JSON字符串，并使用默认密钥对数据进行加密。
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <returns></returns>
        public static string ToJsonX(this object obj)
        {
            return JsonConvert.SerializeObject(obj).Encrypt().Insert(0, "0x1");
        }

        /// <summary>
        /// 将本对象序列化成JSON字符串。
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }

}
