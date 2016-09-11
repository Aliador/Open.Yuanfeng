using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Yuanfeng.Smarty.Encrypt;

namespace Yuanfeng.Smarty
{
    public class ConfigManager
    {
        private byte[] sourceBuffer;
        public int SettingSize { get; set; }

        /// <summary>
        /// app config path. defualt in this bin.
        /// </summary>
        public string DefaultPath
        {
            get
            {
                return defaultPath;
            }

            set
            {
                defaultPath = value;
            }
        }

        private string defaultPath = "Config";

        private string fileName = "DefaultConfig.b";

        public ConfigManager()
        {
            try
            {
                if (!Directory.Exists(defaultPath)) Directory.CreateDirectory(defaultPath);
            }
            catch (Exception exception) { throw new Exception("The set path is invalid.",exception); }
                        
            fileName = Path.Combine(defaultPath, fileName);

            if (File.Exists(fileName))
            {
                sourceBuffer = File.ReadAllBytes(fileName);

                if (sourceBuffer != null && sourceBuffer.Length > 0) sourceBuffer = AES.AESDecrypt(sourceBuffer, "yuanfeng");
            }
        }

    }
}
