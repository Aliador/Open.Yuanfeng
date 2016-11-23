using System.Configuration;

namespace Yuanfeng.PluginEngine
{
    public class DynImage : ConfigurationElement
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ConfigurationProperty("key", IsKey = true)]
        public string Key { get { return this["key"] as string; } set { this["key"] = value; } }
        /// <summary>
        /// 插件版本
        /// </summary>
        [ConfigurationProperty("image")]
        public string Image { get { return this["image"] as string; } set { this["image"] = value; } }

    }
}
