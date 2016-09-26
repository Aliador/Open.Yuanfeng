using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{
    public class Plugin : ConfigurationElement
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ConfigurationProperty("key", IsKey = true)]
        public string Key { get { return this["key"] as string; } set { this["key"] = value; } }
        /// <summary>
        /// 插件版本
        /// </summary>
        [ConfigurationProperty("version")]
        public string Version { get { return this["version"] as string; } set { this["version"] = value; } }

        /// <summary>
        /// 插件名称
        /// </summary>
        [ConfigurationProperty("assembly")]
        public string Assembly { get { return this["assembly"] as string; } set { this["assembly"] = value; } }
    }
}
