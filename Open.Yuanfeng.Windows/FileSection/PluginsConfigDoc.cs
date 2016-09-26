using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Yuanfeng.PluginEngine;

namespace Open.Yuanfeng.Windows.FileSection
{
    public partial class PluginsConfigDoc : DockContent
    {
        public PluginsConfigDoc()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ConfigParser parser = new ConfigParser(this.tbFilename.Text);
            var plugins = parser.Plugins;

            if (plugins != null)
            {
                this.lbConfigs.Items.Add("Version:" + plugins.Version + ",RootDir:" + plugins.RootDir + ",Multiple:" + plugins.Multiple);

                int count = plugins.Plugins.Count;
                for (int i = 0; i < count; i++)
                {
                    Plugin item = plugins.Plugins[i];
                    this.lbConfigs.Items.Add("Key:" + item.Key + ",Version:" + item.Version + ",Assembly:" + item.Assembly);
                }
            }
        }
    }
}
