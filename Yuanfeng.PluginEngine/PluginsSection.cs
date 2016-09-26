using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{
    public class PluginsSection : ConfigurationSection
    {
        /// <summary>
        /// 配置文件版本
        /// </summary>
        [ConfigurationProperty("version")]
        public string Version { get { return this["version"] as string; } set { this["version"] = value; } }

        /// <summary>
        /// 允许存在多个子项
        /// </summary>
        [ConfigurationProperty("multiple")]
        public string Multiple { get { return this["multiple"] as string; } set { this["multiple"] = value; } }

        /// <summary>
        /// 存放插件的根目录
        /// </summary>
        [ConfigurationProperty("dir")]
        public string RootDir { get { return this["dir"] as string; } set { this["dir"] = value; } }

        [ConfigurationProperty("filter")]
        public string Filter { get { return this["filter"] as string; } set { this["filter"] = value; } }

        /// <summary>
        /// 子插件集合
        /// </summary>
        [ConfigurationProperty("plugins",IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(PluginCollection))]
        public PluginCollection Plugins { get { return (PluginCollection)base["plugins"]; } set { base["plugins"] = value; } }
    }
}
