using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.PluginEngine
{
    public class ConfigParser
    {
        private bool isUsingDefaultConfig = false;
        private string filename = "plugins.config";
        private PluginsSection plugins = new PluginsSection();

        public bool IsUsingDefaultConfig { get { return isUsingDefaultConfig; } }

        public ConfigParser()
        {
            LoadpluginConfig();
        }

        public ConfigParser(string filename)
        {
            if (!string.IsNullOrEmpty(filename)) this.filename = filename;
            LoadpluginConfig();
        }

        void LoadpluginConfig()
        {
            filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            if (File.Exists(filename))//如果存在独立文件
            {
                var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = filename };
                var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                this.plugins = config.GetSection("plugin-section") as PluginsSection;
            }
            else
            {
                this.plugins = ConfigurationManager.GetSection("plugin-section") as PluginsSection;
            }

            if (this.plugins == null)
            {
                isUsingDefaultConfig = true;
            }
        }

        /// <summary>
        /// 插件配置项
        /// </summary>
        public PluginsSection Plugins { get { return this.plugins; } }

        /// <summary>
        /// 解析配置文件
        /// </summary>
        /// <returns></returns>
        public PluginsSection Parse()
        {
            return this.plugins;
        }
    }
}
