using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Yuanfeng.PluginEngine
{
    /// <summary>
    /// 插件加载器，根据制定目录加载可用插件
    /// </summary>
    public class PluginLoader
    {
        private PluginsSection plugins = new PluginsSection();
        /// <summary>
        /// 已创建的对象
        /// </summary>
        private List<TypeInfo> instances = new List<TypeInfo>();
        private static PluginLoader _instance;
        private List<Assembly> assemblys = new List<Assembly>();
        private List<string> assemblyfiles = new List<string>();

        private Dictionary<string, bool> assemblyFiles = new Dictionary<string, bool>();

        private object[] lockObjs = new object[] { };

        private List<string> GetAssemblyFiles()
        {
            lock (lockObjs)
            {
                if (!Directory.Exists(pluginRootDir)) throw new Exception("未找到指定目录：" + pluginRootDir);

                string[] exeFiles = Directory.GetFiles(pluginRootDir, "*.exe");
                string[] dllFiles = Directory.GetFiles(pluginRootDir, "*.dll");
                string[] files = new string[exeFiles.Length + dllFiles.Length];
                exeFiles.CopyTo(files, 0);
                dllFiles.CopyTo(files, exeFiles.Length);

                var matchFiles = from val in files where MatchFile(new FileInfo(val).Name) select val;

                return matchFiles.ToList<string>();
            }
        }

        private bool MatchFile(string fileName)
        {
            string filter = this.plugins.Filter;
            foreach (var item in filter.Split(','))
            {
                if (!string.IsNullOrEmpty(item) && fileName.Contains(item)) return false;
            }
            return true;
        }

        private TypeInfo FindTypeInfo(string assembly, string classname)
        {
            lock (lockObjs)
            {
                if (instances != null && instances.Count > 0)
                {
                    return (from type in instances where type.ClassName == classname && (type.Assembly.Contains(assembly + ".dll") || type.Assembly.Contains(assembly + ".exe")) select type).SingleOrDefault();
                }
                return null;
            }
        }

        private void LoadTypeFromFile()
        {
            List<string> files = GetAssemblyFiles();
            lock (lockObjs)
            {
                foreach (string file in files)
                {
                    if (!assemblyFiles.ContainsKey(file))
                    {
                        Assembly assembly = Assembly.LoadFile(file);
                        assemblys.Add(assembly);
                        assemblyFiles.Add(file, true);
                    }
                }
            }
        }

        private void NewAssemblyInstance(string @interface)
        {
            lock (lockObjs)
            {
                if (instances.Find((TypeInfo typeInfo) => { return typeInfo.Type.GetInterface(@interface) != null; }) != null)
                {
                    return;
                }

                foreach (var item in assemblys)
                {
                    Type[] types = item.GetExportedTypes();
                    foreach (var type in types)
                    {
                        if (type.IsClass && type.GetInterface(@interface, true) != null && instances.Find((TypeInfo typeInfo) => { return typeInfo.ClassName == type.Name; }) == null)
                        {
                            try
                            {
                                var typeInfo = new TypeInfo();
                                typeInfo.Interface = @interface;
                                typeInfo.Assembly = type.Assembly.GetName().Name;
                                typeInfo.Type = type;
                                typeInfo.ClassName = type.Name;
                                typeInfo.Instance = Activator.CreateInstance(type);

                                instances.Add(typeInfo);
                            }
                            catch (Exception exception) { throw new Exception(string.Format("{0},创建类“{1}”的对象失败", exception, type.Name)); }
                        }
                    }
                }
            }
        }

        private void NewAssemblyInstance(string @assembly, string @interface)
        {
            lock (lockObjs)
            {
                if (instances.Find((TypeInfo typeInfo) => { return typeInfo.Type.GetInterface(@interface) != null; }) != null)
                {
                    return;//如果该对象已创建则不重新创建
                }

                Assembly target = assemblys.Find((Assembly tmp) => { return tmp.GetName().Name == @assembly; });

                if (target == null) throw new Exception("未找到包含" + assembly + "." + @interface + "接口的程序集");

                Type[] types = target.GetExportedTypes();
                foreach (var type in types)
                {
                    if (type.IsClass && type.GetInterface(@interface, true) != null && instances.Find((TypeInfo typeInfo) => { return typeInfo.ClassName == type.Name; }) == null)
                    {
                        try
                        {
                            var typeInfo = new TypeInfo();
                            typeInfo.Interface = @interface;
                            typeInfo.Assembly = assembly;
                            typeInfo.Type = type;
                            typeInfo.ClassName = type.Name;
                            typeInfo.Instance = Activator.CreateInstance(type);

                            instances.Add(typeInfo);
                        }
                        catch (Exception exception) { throw new Exception(string.Format("{0},创建类“{1}”的对象失败", exception, type.Name)); }
                    }
                }

            }
        }

        private string pluginRootDir;
        public string PluginRootDir { set { this.pluginRootDir = value; } get { return this.pluginRootDir; } }

        private PluginLoader(string path)
        {
            this.pluginRootDir = path;//从制定目录加载插件
            LoadTypeFromFile();
        }
        private PluginLoader()
        {
            this.pluginRootDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.plugins.RootDir);
            LoadTypeFromFile();
        }

        public static PluginLoader NewInstance(string path)
        {
            if (_instance == null)
                _instance = new PluginLoader(path);
            else
            {
                _instance.PluginRootDir = path;
            }
            return _instance;
        }

        public static PluginLoader NewInstance()
        {
            if (_instance == null)
                _instance = new PluginLoader();
            return _instance;
        }

        /// <summary>
        /// 加载制定类型的插件
        /// </summary>
        /// <typeparam name="T">接口</typeparam>
        /// <returns>满足要求的插件集合</returns>
        public List<T> Load<T>()
        {
            try
            {
                return Load<T>(false);
            }
            catch (Exception exception) { throw exception; }
        }

        /// <summary>
        /// 加载制定类型的插件
        /// </summary>
        /// <typeparam name="T">接口</typeparam>
        /// <returns>满足要求的插件集合</returns>
        public List<T> Load<T>(bool @new = true)
        {
            lock (lockObjs)
            {
                List<T> pluginInstances = new List<T>();
                string interfacename = typeof(T).Name;
                if (!typeof(T).IsInterface) throw new Exception(string.Format("指定类型不是接口({0})", interfacename));

                try
                {
                    NewAssemblyInstance(interfacename);
                }
                catch (Exception exception) { throw exception; }
                var destTypes = from type in instances where type.Type.GetInterface(interfacename, true) != null select type;

                foreach (var type in destTypes)
                {
                    if (@new)
                    {
                        pluginInstances.Add((T)type.CreateInstance());
                    }
                    else
                    {
                        bool containts = false;
                        foreach (var item in pluginInstances)
                        {
                            if (item.GetType().Name == type.ClassName)
                            {
                                containts = true;
                            }
                        }
                        if (!containts) pluginInstances.Add((T)type.Instance);
                    }
                }
                if (pluginInstances.Count == 0)
                    throw new Exception(string.Format("没有找对实现该接口的类({0})", interfacename));

                return pluginInstances;
            }
        }

        /// <summary>
        /// 加载制定类型的插件
        /// </summary>
        /// <typeparam name="T">接口</typeparam>
        /// <returns>满足要求的插件集合</returns>
        public List<object> Load(string @assembly, string @interface, bool @new = true)
        {
            lock (lockObjs)
            {
                List<object> pluginInstances = new List<object>();
                try
                {
                    NewAssemblyInstance(assembly, @interface);
                }
                catch (Exception exception) { throw exception; }
                var destTypes = from type in instances where type.Match(assembly, @interface) select type;

                foreach (var type in destTypes)
                {
                    if (@new)
                    {
                        pluginInstances.Add(type.CreateInstance());
                    }
                    else
                    {
                        bool containts = false;
                        foreach (var item in pluginInstances)
                        {
                            if (item.GetType().Name == type.ClassName)
                            {
                                containts = true;
                            }
                        }
                        if (!containts) pluginInstances.Add(type.Instance);
                    }
                }
                if (pluginInstances.Count == 0)
                    throw new Exception(string.Format("没有找对实现该接口的类({0}.{1})", assembly, @interface));

                return pluginInstances;
            }
        }

        /// <summary>
        /// 获取单个指定接口类型的插件
        /// </summary>
        /// <typeparam name="T">接口</typeparam>
        /// <returns>唯一一个满足要求的插件</returns>
        public T GetSingle<T>(bool @new = false)
        {
            var instances = Load<T>(@new);
            return instances.SingleOrDefault<T>();
        }

        public object GetSingle(string assembly, string @interface, bool @new = false)
        {
            return Load(assembly, @interface, @new).SingleOrDefault();
        }

        public object GetMultiple(string assembly, string @interface, bool @new = false)
        {
            return Load(assembly, @interface, @new);
        }


    }
}
