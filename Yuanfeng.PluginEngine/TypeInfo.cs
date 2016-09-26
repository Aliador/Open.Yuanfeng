using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{

    public class TypeInfo
    {
        public string Assembly { get; set; }

        public string ClassName { get; set; }

        public Type Type { get; set; }

        public object Instance { get; set; }

        public object CreateInstance()
        {
            return Activator.CreateInstance(Type);
        }
    }
}
