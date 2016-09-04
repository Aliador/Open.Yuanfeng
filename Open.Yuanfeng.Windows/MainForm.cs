using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Open.Yuanfeng.Windows
{
    public partial class MainForm : Form
    {
        private DummyOutputWindow outputWindow;
        private DeserializeDockContent deserializeDockContent;
        [DllImport("Kernel32.dll")]
        private static extern bool AllocConsole();
        [DllImport("kernel32.dll",
            EntryPoint = "GetStdHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        public MainForm()
        {
            InitializeComponent();

            //deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            ////this.MainDockPanel.Theme = this.vS2012LightTheme;
            //SetSchema();
            InitConsoleDummy();
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(DummyOutputWindow).ToString())
                return this.outputWindow;
            else
            {
                // DummyDoc overrides GetPersistString to add extra information into persistString.
                // Any DockContent may override this value to add any needed information for deserialization.

                string[] parsedStrings = persistString.Split(new char[] { ',' });
                if (parsedStrings.Length != 3)
                    return null;

                if (parsedStrings[0] != typeof(DummyDoc).ToString())
                    return null;

                DummyDoc dummyDoc = new DummyDoc();

                return dummyDoc;
            }
        }
        private void SetSchema()
        {
            // Persist settings when rebuilding UI
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            if (File.Exists(configFile))
                MainDockPanel.LoadFromXml(configFile, deserializeDockContent);
        }


        void InitConsoleDummy()
        {
            if (outputWindow == null || outputWindow.IsDisposed)
                outputWindow = new DummyOutputWindow();
        }

        private void ConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitConsoleDummy();
            if (this.ConsoleToolStripMenuItem.Checked)
            {
                outputWindow.Close();
            }
            else
            {
                outputWindow.Show(MainDockPanel, DockState.DockBottomAutoHide);
                outputWindow.FormClosing += DummyClosing;
                ConsoleToolStripMenuItem.Checked = true;
            }

        }

        private void DummyClosing(object sender, FormClosingEventArgs e)
        {
            if (sender == this.outputWindow) this.ConsoleToolStripMenuItem.Checked = false;

            if (sender == this.yuanjingdaDummy) this.YuanjingdaToolStripMenuItem.Checked = false;
        }


        private SerialPort.YuanjingdaDoc yuanjingdaDummy;
        public void InitYuanjingdaDummy()
        {
            if (yuanjingdaDummy == null || yuanjingdaDummy.IsDisposed) yuanjingdaDummy = new SerialPort.YuanjingdaDoc();
        }

        private void YuanjingdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitYuanjingdaDummy();
            this.YuanjingdaToolStripMenuItem.Checked = true;
            this.yuanjingdaDummy.Show(MainDockPanel, DockState.Document);
            this.yuanjingdaDummy.FormClosing += DummyClosing;
        }
    }
}
