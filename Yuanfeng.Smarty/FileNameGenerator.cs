using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.Smarty
{
    public enum GenaratorType
    {
        GUID, DATE, TICKS, RANDOM
    }

    /// <summary>
    /// this is create filename helper class .
    /// </summary>
    public class FileNameGenerator
    {
        /// <summary>
        /// this create string is use guid length is 32
        /// </summary>
        /// <returns></returns>
        public static string UseGuid()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            string guid = Encoding.Default.GetString(buffer);

            if (!string.IsNullOrEmpty(guid))
            {
                return guid.Replace("-", "");
            }

            return "00000000000000000000000000000000";//default value
        }

        /// <summary>
        /// this use datetime string length is 14
        /// </summary>
        /// <returns></returns>
        public static string UseTime()
        {
            DateTime now = DateTime.Now;
            return now.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// this use datetime ticks length is unkonw.
        /// </summary>
        /// <returns></returns>
        public static string UseTicks()
        {
            DateTime now = DateTime.Now;
            return now.Ticks.ToString();
        }

        /// <summary>
        /// this is use random number length is 7
        /// </summary>
        /// <returns></returns>
        public static string UseRandom()
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();

            int realNumber = (int)(randomNumber * 1000000);

            return realNumber.ToString().PadLeft(7, '0');
        }

        /// <summary>
        ///create dir use date format yyyy/MM/dd
        /// </summary>
        /// <returns></returns>
        public static string CreateDirUseDate()
        {
            return DateTime.Now.ToString("yyyy/MM/dd");
        }


        public static string Generator()
        {
            string filename = string.Empty;

            string cd = @"d:\";
            string rootDir = Path.Combine(cd, "Yuanfeng");
            filename = Generator(rootDir);

            return filename;
        }

        public static string Generator(string rootDir)
        {
            string filename = string.Empty;
            string ext = ".b";
            filename = Generator(rootDir, ext);

            return filename;
        }

        public static string Generator(string rootDir, string ext)
        {
            string filename = string.Empty;

            filename = Generator(rootDir, ext, GenaratorType.TICKS);

            return filename;
        }

        public static string Generator(string rootDir, string ext, GenaratorType genaratorType)
        {
            string filename = string.Empty;

            string dir = CreateDirUseDate();

            string name = UseTime();
            switch (genaratorType)
            {
                case GenaratorType.GUID:
                    name = UseGuid();
                    break;
                case GenaratorType.DATE:
                    name = UseTime();
                    break;
                case GenaratorType.TICKS:
                    name = UseTicks();
                    break;
                case GenaratorType.RANDOM:
                    name = UseRandom();
                    break;
                default:
                    break;
            }

            dir = Path.Combine(rootDir, dir);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            filename = Path.Combine(dir, name + ext);

            return filename;
        }
    }
}
