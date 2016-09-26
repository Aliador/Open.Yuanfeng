using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{
    public class PluginCollection : ConfigurationElementCollection
    {
        new public Plugin this[string name]
        {
            get
            {
                return (Plugin)base.BaseGet(name);
            }
        }

        public Plugin this[int index]
        {
            get
            {
                return (Plugin)base.BaseGet(index);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new Plugin();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Plugin)element).Key;
        }

        new public int Count { get { return base.Count; } }

        public Plugin GetElementByKey(string key)
        {
            return base.BaseGet(key) as Plugin;
        }
    }
}
