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
        private List<TypeInfo> assemblyTypes = new List<TypeInfo>();
        private static PluginLoader _instance;
        private List<Assembly> assemblys = new List<Assembly>();
        private List<string> interfaceNames = new List<string>();
        private Dictionary<string, bool> assemblyFiles = new Dictionary<string, bool>();

        private object[] lockObjs = new object[] { };

        public object CreateInstanceFromName(string assemblyName, string className)
        {
            string[] files = GetAssemblyFiles();

            LoadTypeFromFile(files);

            return FindTypeInfo(assemblyName, className);
        }

        private string[] GetAssemblyFiles()
        {
            lock (lockObjs)
            {
                if (!Directory.Exists(pluginRootDir)) throw new Exception("未找到指定目录");

                string[] exeFiles = Directory.GetFiles(pluginRootDir, "*.exe");
                string[] dllFiles = Directory.GetFiles(pluginRootDir, "*.dll");
                string[] files = new string[exeFiles.Length + dllFiles.Length];
                exeFiles.CopyTo(files, 0);
                dllFiles.CopyTo(files, exeFiles.Length);

                var matchFiles = from val in files where MatchFile(new FileInfo(val).Name) select val;

                return matchFiles.ToArray();
            }
        }

        private bool MatchFile(string fileName)
        {
            string filter = this.plugins.Filter;
            foreach (var item in filter.Split(','))
            {
                if (fileName.Contains(item)) return false;
            }
            return true;
        }

        private TypeInfo FindTypeInfo(string assembly, string className)
        {
            lock (lockObjs)
            {
                if (assemblyTypes != null && assemblyTypes.Count > 0)
                {
                    return (from type in assemblyTypes where type.ClassName == className && (type.Assembly.Contains(assembly + ".dll") || type.Assembly.Contains(assembly + ".exe")) select type).SingleOrDefault();
                }
                return null;
            }
        }


        private void LoadTypeFromFile(string[] files)
        {
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

        private void newAssemblyInstance(string interfacename)
        {
            lock (lockObjs)
            {
                if (assemblyTypes.Find((TypeInfo typeInfo) => { return typeInfo.Type.GetInterface(interfacename) != null; }) != null)
                {
                    return;
                }

                foreach (var item in assemblys)
                {
                    Type[] types = item.GetExportedTypes();
                    foreach (var type in types)
                    {
                        if (type.IsClass && type.GetInterface(interfacename, true) != null && assemblyTypes.Find((TypeInfo typeInfo) => { return typeInfo.ClassName == type.Name; }) == null)
                        {
                            try
                            {
                                var typeInfo = new TypeInfo();
                                typeInfo.Assembly = item.Location;
                                typeInfo.Type = type;
                                typeInfo.ClassName = type.Name;
                                typeInfo.Instance = Activator.CreateInstance(type);

                                assemblyTypes.Add(typeInfo);
                            }
                            catch (Exception exception) { throw new Exception(string.Format("{0},创建类“{1}”的对象失败", exception, type.Name)); }
                        }
                    }
                }
            }
        }

        private string pluginRootDir;
        public string PluginRootDir { set { this.pluginRootDir = value; } get { return this.pluginRootDir; } }

        private PluginLoader(string path)
        {
            this.pluginRootDir = path;//从制定目录加载插件
        }
        private PluginLoader()
        {
            this.pluginRootDir = this.plugins.RootDir;
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
        public List<T> Load<T>(bool newInstance = true)
        {
            lock (lockObjs)
            {
                string[] files = GetAssemblyFiles();

                if (files.Length <= 0) throw new DllNotFoundException(pluginRootDir);

                List<T> pluginInstances = new List<T>();

                if (!typeof(T).IsInterface) throw new Exception("指定类型不是接口");

                string interfacename = typeof(T).Name;

                interfaceNames.Add(interfacename);

                LoadTypeFromFile(files);
                try
                {
                    newAssemblyInstance(interfacename);
                }
                catch (Exception exception) { throw exception; }
                var destTypes = from type in assemblyTypes where type.Type.GetInterface(interfacename, true) != null select type;

                foreach (var type in destTypes)
                {
                    if (newInstance)
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
                if (pluginInstances.Count <= 0)
                    throw new Exception("没有找对实现该接口的类");

                return pluginInstances;
            }
        }
        /// <summary>
        /// 获取单个制定接口类型的插件
        /// </summary>
        /// <typeparam name="T">接口</typeparam>
        /// <returns>唯一一个满足要求的插件</returns>
        public T GetSinglePlugin<T>()
        {
            return GetSinglePlugin<T>(false);
        }

        /// <summary>
        /// 获取单个指定接口类型的插件
        /// </summary>
        /// <typeparam name="T">接口</typeparam>
        /// <returns>唯一一个满足要求的插件</returns>
        public T GetSinglePlugin<T>(bool newInstance = true)
        {
            var instances = Load<T>(newInstance);
            return instances.SingleOrDefault<T>();
        }
    }
}
