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
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows
{
    public partial class MainForm : Form
    {
        private DummyOutputWindow outputWindow;
        //private DeserializeDockContent deserializeDockContent;
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

            if (File.Exists(configFile)) ;
            //MainDockPanel.LoadFromXml(configFile, deserializeDockContent);
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
                outputWindow.Show(MainDockPanel, DockState.DockBottom);
                outputWindow.FormClosing += DummyClosing;
                ConsoleToolStripMenuItem.Checked = true;
            }

        }

        private void DummyClosing(object sender, FormClosingEventArgs e)
        {
            if (sender == this.outputWindow) this.ConsoleToolStripMenuItem.Checked = false;

            if (sender == this.yuanjingdaDummy) this.YuanjingdaToolStripMenuItem.Checked = false;

            if (sender == this.cameraDummy) this.CameraToolStripMenuItem.Checked = false;

            if (sender == this.simpleCamera) this.SimpleCameraToolStripMenuItem.Checked = false;

            if (sender == this.simpleQrCodeDoc) this.SimpleQrCodeToolStripMenuItem.Checked = false;

            if (sender == this.findGrayImageDoc) this.FindGrayImageToolStripMenuItem.Checked = false;

            if (sender == this.simpleIDRDoc) this.SimpleIDRToolStripMenuItem.Checked = false;

            SimpleConsole.WriteLine(string.Format("This [{0}] is closed.", sender));
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

            SimpleConsole.WriteLine("This yuanjingda is loaded.");
        }
        private SerialPort.CameraControlToolDoc cameraDummy;
        void InitCameraDummy()
        {
            if (cameraDummy == null || cameraDummy.IsDisposed) cameraDummy = new SerialPort.CameraControlToolDoc();
        }
        private void CameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitCameraDummy();
            this.CameraToolStripMenuItem.Checked = true;
            this.cameraDummy.Show(MainDockPanel, DockState.Document);
            this.cameraDummy.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("This camera is loaded.");
        }

        private SerialPort.SimpleCameraDoc simpleCamera;
        void InitSimpleCameraDummy()
        {
            if (simpleCamera == null || simpleCamera.IsDisposed) simpleCamera = new SerialPort.SimpleCameraDoc();
        }

        private void SimpleCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitSimpleCameraDummy();
            this.SimpleCameraToolStripMenuItem.Checked = true;
            this.simpleCamera.Show(MainDockPanel, DockState.Document);
            this.simpleCamera.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("This simple camera is loaded.");
        }
        private ImageUtil.SimpleQrCodeDoc simpleQrCodeDoc;
        void InitSimpleQrCodeDummy()
        {
            if (simpleQrCodeDoc == null || simpleQrCodeDoc.IsDisposed) simpleQrCodeDoc = new ImageUtil.SimpleQrCodeDoc();
        }
        private void SimpleQrCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitSimpleQrCodeDummy();
            this.SimpleQrCodeToolStripMenuItem.Checked = true;
            this.simpleQrCodeDoc.Show(MainDockPanel, DockState.Document);
            this.simpleQrCodeDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The simple qrcode dummy loaded.");
        }

        private ImageUtil.FindGrayImageDoc findGrayImageDoc;
        void InitFindGrayImageDoc()
        {
            if (findGrayImageDoc == null || findGrayImageDoc.IsDisposed) findGrayImageDoc = new ImageUtil.FindGrayImageDoc();
        }
        private void FindGrayImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFindGrayImageDoc();
            this.FindGrayImageToolStripMenuItem.Checked = true;
            this.findGrayImageDoc.Show(MainDockPanel, DockState.Document);
            this.findGrayImageDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The sfind gray image dummy loaded.");
        }

        private SerialPort.SimpleIDRDoc simpleIDRDoc;
        void InitSimpleIDRDoc()
        {
            if (simpleIDRDoc == null || simpleIDRDoc.IsDisposed) simpleIDRDoc = new SerialPort.SimpleIDRDoc();
        }
        private void SimpleIDRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitSimpleIDRDoc();
            this.SimpleIDRToolStripMenuItem.Checked = true;
            this.simpleIDRDoc.Show(MainDockPanel, DockState.Document);
            this.simpleIDRDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The simpleIDR dummy loaded.");
        }
    }
}
