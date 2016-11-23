using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{
    public class ImageSection : ConfigurationSection
    {
        /// <summary>
        /// 背景图片
        /// </summary>
        [ConfigurationProperty("backgrounds", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DynImageCollection))]
        public DynImageCollection Backgrounds { get { return (DynImageCollection)base["backgrounds"]; } set { base["backgrounds"] = value; } }

        /// <summary>
        /// 图片
        /// </summary>
        [ConfigurationProperty("images", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DynImageCollection))]
        public DynImageCollection Images { get { return (DynImageCollection)base["images"]; } set { base["images"] = value; } }
    }
}
