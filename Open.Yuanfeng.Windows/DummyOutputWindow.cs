using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using System.IO;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows
{
    public partial class DummyOutputWindow : DockContent
    {
        public DummyOutputWindow()
        {
            InitializeComponent();
        }


        private long startReaderIndex = 0;
        private void DummyOutputWindow_Load(object sender, EventArgs e)
        {
            string filename = "log/console.log";
            if (File.Exists(filename))
            {
                FileInfo info = new FileInfo(filename);
                FileSystemWatcher watcher = new FileSystemWatcher("log");

                startReaderIndex = info.Length;

                //初始化监听
                watcher.BeginInit();
                //设置监听文件类型
                watcher.Filter = "*.*";
                //设置是否监听子目录
                watcher.IncludeSubdirectories = true;
                //设置是否启用监听?
                watcher.EnableRaisingEvents = true;
                //设置需要监听的更改类型(如:文件或者文件夹的属性,文件或者文件夹的创建时间;NotifyFilters枚举的内容)
                watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
                //设置监听的路径
                watcher.Path = "log";
                //注册创建文件或目录时的监听事件
                //watcher.Created += new FileSystemEventHandler(watch_created);
                //注册当指定目录的文件或者目录发生改变的时候的监听事件
                watcher.Changed += new FileSystemEventHandler(Watcher_Changed);
                //注册当删除目录的文件或者目录的时候的监听事件
                //watcher.Deleted += new FileSystemEventHandler(watch_deleted);
                //当指定目录的文件或者目录发生重命名的时候的监听事件
                //watcher.Renamed += new RenamedEventHandler(watch_renamed);
                //结束初始化
                watcher.EndInit();
            }
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                string changeStrings = string.Empty;

                string filename = e.FullPath;

                long len = new FileInfo(filename).Length;

                long nextStartIndex = len;

                if (len <= 0) { return; }

                len = len - startReaderIndex;

                if (len <= 0) { return; }

                char[] changeBuffer = new char[len];
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    fs.Position = startReaderIndex;
                    StreamReader streamReader = new StreamReader(fs);
                    streamReader.Read(changeBuffer, 0, (int)len);
                    streamReader.Close();
                    changeStrings = new string(changeBuffer);
                    fs.Close();
                }
                startReaderIndex = nextStartIndex;
                if (this == null || this.IsDisposed) return;
                else
                {
                    this.Invoke(new MethodInvoker(() => { this.tbConsole.AppendText(changeStrings); this.tbConsole.SelectionStart = (int)nextStartIndex; this.tbConsole.ScrollToCaret(); }));
                }
            }
            catch (Exception exception) { SimpleConsole.WriteLine(exception.Message); }                 
        }
    }
}
