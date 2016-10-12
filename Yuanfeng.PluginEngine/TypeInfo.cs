using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{

    public class TypeInfo
    {
        public bool Match(string @interface)
        {
            return Instance.Equals(@interface);
        }

        public bool Match(string assembly, string @interface)
        {
            return Assembly.Equals(assembly) && Interface.Equals(@interface);
        }

        /// <summary>
        /// 程序集名称
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        /// 创建该对象的接口
        /// </summary>
        public string Interface { get; set; }

        /// <summary>
        /// 实现类名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public object Instance { get; set; }

        public object CreateInstance()
        {
            return Activator.CreateInstance(Type);
        }
    }
}
