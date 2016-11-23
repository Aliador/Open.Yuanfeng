using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{
    public class DynImageCollection : ConfigurationElementCollection
    {
        new public DynImage this[string name]
        {
            get
            {
                return (DynImage)base.BaseGet(name);
            }
        }

        public DynImage this[int index]
        {
            get
            {
                return (DynImage)base.BaseGet(index);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new DynImage();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DynImage)element).Key;
        }

        new public int Count { get { return base.Count; } }

        public DynImage GetElementByKey(string key)
        {
            return base.BaseGet(key) as DynImage;
        }

        public List<DynImage> Find(string key)
        {
            object[] keys = base.BaseGetAllKeys();
            List<object> matches = new List<object>();
            foreach (object item in keys)
            {
                if (item.ToString().Contains(key)) matches.Add(item);
            }
            List<DynImage> dnyImage = new List<DynImage>();
            foreach (object item in matches)
            {
                dnyImage.Add((DynImage)base.BaseGet(item));
            }

            return dnyImage;
        }
    }
}
