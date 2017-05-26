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
using Yuanfeng.WinFormsUI;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.Smarty;
using Yuanfeng.Unit.QrCode;

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

            if (sender == this.simpleFprCaptureDoc) this.SimpleFprCaptureToolStripMenuItem.Checked = false;

            if (sender == this.simpleUdpClientDoc) this.simpleUdpClientToolStripMenuItem.Checked = false;

            if (sender == this.simpleUdpServerDoc) this.simpleUdpServerToolStripMenuItem.Checked = false;

            if (sender == this.dynamicHttpRequestDoc) this.dynamicInvokeToolStripMenuItem.Checked = false;

            if (sender == this.faceFeatureDoc) this.tesoFaceFeatureToolStripMenuItem.Checked = false;

            if (sender == this.tesoLFCDoc) this.tesoLFCDocToolStripMenuItem.Checked = false;

            if (sender == this.iamgeColorDoc) this.imageColorToolStripMenuItem.Checked = false;

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

        private SerialPort.SimpleFprDoc simpleFprCaptureDoc;
        void InitSimpleFprCaptureDoc()
        {
            if (simpleFprCaptureDoc == null || simpleFprCaptureDoc.IsDisposed) simpleFprCaptureDoc = new SerialPort.SimpleFprDoc();
        }
        private void SimpleFprCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitSimpleFprCaptureDoc();
            this.SimpleFprCaptureToolStripMenuItem.Checked = false;
            this.simpleFprCaptureDoc.Show(MainDockPanel, DockState.Document);
            this.simpleFprCaptureDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The SimpleFprCapture dummy loaded.");
        }

        private ImageUtil.SimpleOcrDoc SimpleOcrDoc;
        void InitSimpleOcrDoc()
        {
            if (SimpleOcrDoc == null || SimpleOcrDoc.IsDisposed) SimpleOcrDoc = new ImageUtil.SimpleOcrDoc();
        }
        private void SimpleOcrDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitSimpleOcrDoc();
            this.SimpleOcrDocToolStripMenuItem.Checked = true;
            SimpleOcrDoc.Show(MainDockPanel, DockState.Document);
            SimpleOcrDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The SimpleOcrDoc dummy loaded.");
        }
        private SocketX.SimpleUdpServerDoc simpleUdpServerDoc;
        void InitSsimpleUdpServerDoc()
        {
            if (simpleUdpServerDoc == null || simpleUdpServerDoc.IsDisposed) simpleUdpServerDoc = new SocketX.SimpleUdpServerDoc();
        }
        private void simpleUdpServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitSsimpleUdpServerDoc();
            this.simpleUdpServerToolStripMenuItem.Checked = true;
            simpleUdpServerDoc.Show(MainDockPanel, DockState.Document);
            simpleUdpServerDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The simpleUdpServerDoc dummy loaded.");
        }
        private SocketX.SimpleUdpClientDoc simpleUdpClientDoc;
        void InitSimpleUdpClientDoc()
        {
            if (simpleUdpClientDoc == null || simpleUdpClientDoc.IsDisposed) simpleUdpClientDoc = new SocketX.SimpleUdpClientDoc();
        }
        private void simpleUdpClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitSimpleUdpClientDoc();
            this.simpleUdpClientToolStripMenuItem.Checked = true;
            simpleUdpClientDoc.Show(MainDockPanel, DockState.Document);
            simpleUdpClientDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The simpleUdpClientDoc dummy loaded.");
        }

        private FileSection.PluginsConfigDoc PluginsConfigDoc;
        void InitPluginsConfigDoc()
        {
            if (PluginsConfigDoc == null || PluginsConfigDoc.IsDisposed) PluginsConfigDoc = new FileSection.PluginsConfigDoc();
        }
        private void pluginsConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitPluginsConfigDoc();
            this.pluginsConfigToolStripMenuItem.Checked = true;
            PluginsConfigDoc.Show(MainDockPanel, DockState.Document);
            PluginsConfigDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The PluginsConfigDoc dummy loaded.");
        }

        private HttpX.DynamicHttpRequest dynamicHttpRequestDoc;
        void InitDynamicHttpRequestDoc()
        {
            if (dynamicHttpRequestDoc == null || dynamicHttpRequestDoc.IsDisposed) dynamicHttpRequestDoc = new HttpX.DynamicHttpRequest();
        }

        private void dynamicInvokeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDynamicHttpRequestDoc();
            this.dynamicInvokeToolStripMenuItem.Checked = true;
            dynamicHttpRequestDoc.Show(MainDockPanel, DockState.Document);
            dynamicHttpRequestDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The dynamicHttpRequestDoc dummy loaded.");
        }

        private ImageUtil.TesoFaceFeature faceFeatureDoc;
        void InitFaceFeatureDoc()
        {
            if (faceFeatureDoc == null || faceFeatureDoc.IsDisposed) faceFeatureDoc = new ImageUtil.TesoFaceFeature();
        }
        private void tesoFaceFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFaceFeatureDoc();
            this.tesoFaceFeatureToolStripMenuItem.Checked = true;
            faceFeatureDoc.Show(MainDockPanel, DockState.Document);
            faceFeatureDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The faceFeatureDoc dummy loaded.");
        }
        private ImageUtil.TesoLFCDoc tesoLFCDoc;
        void InitTesoLFCDoc()
        {
            if (tesoLFCDoc == null || tesoLFCDoc.IsDisposed) tesoLFCDoc = new ImageUtil.TesoLFCDoc();
        }
        private void tesoLFCDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitTesoLFCDoc();
            this.tesoLFCDocToolStripMenuItem.Checked = true;
            tesoLFCDoc.Show(MainDockPanel, DockState.Document);
            tesoLFCDoc.FormClosing += DummyClosing;

            SimpleConsole.WriteLine("The tesoLFCDoc dummy loaded.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = new DummyDoc();
            doc.Show(MainDockPanel, DockState.Document);
            doc.FormClosing += DummyClosing;
        }

        private SocketX.RedisClientDoc redisDoc;
        private void InitRedisDoc()
        {
            if (redisDoc == null || redisDoc.IsDisposed) redisDoc = new SocketX.RedisClientDoc();
        }
        private void redisClientDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitRedisDoc();
            this.redisClientDocToolStripMenuItem.Checked = true;
            redisDoc.Show(MainDockPanel, DockState.Document);
            redisDoc.FormClosing += DummyClosing;
        }

        private ImageUtil.VidetekDoc videtekDoc;
        private void InitvidetekDoc()
        {
            if (videtekDoc == null || videtekDoc.IsDisposed) videtekDoc = new ImageUtil.VidetekDoc();
        }
        private void videtekFeactureDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitvidetekDoc();
            this.videtekFeactureDToolStripMenuItem.Checked = true;
            videtekDoc.Show(MainDockPanel, DockState.Document);
            videtekDoc.FormClosing += DummyClosing;
        }

        private SerialPort.SimpleAviDoc aviDoc;
        private void InitAviDoc()
        {
            if (aviDoc == null || aviDoc.IsDisposed) aviDoc = new SerialPort.SimpleAviDoc();
        }
        private void aviRecorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitAviDoc();
            this.aviRecorderToolStripMenuItem.Checked = true;
            aviDoc.Show(MainDockPanel, DockState.Document);
            aviDoc.FormClosing += DummyClosing;
        }
        private FileSection.TestDoc testDoc;
        private void InitTestDoc()
        {
            if (testDoc == null || testDoc.IsDisposed) testDoc = new FileSection.TestDoc();
        }
        private void testDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitTestDoc();
            this.testDocToolStripMenuItem.Checked = true;
            testDoc.Show(MainDockPanel, DockState.Document);
            testDoc.FormClosing += DummyClosing;
        }

        private void copyScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var copyScreen = new CopyScreen();
            copyScreen.GetScreenImage += CopyScreen_GetScreenImage;
            copyScreen.GerScreenFormRectangle();
        }

        private void CopyScreen_GetScreenImage(Image p_Image)
        {
            var form = new Form(); form.BackgroundImage = p_Image; form.Size = p_Image.Size; form.Show(); this.Show();
        }

        private void simpleTextDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TextDocPrintHelper().Print(mutiContent(), 80, true);
        }

        public PrintFixedImage testImage()
        {
            Image image = ((Bitmap)@"C:\Users\Yuanfeng Recluse\Pictures\myhead_mini.jpg".Reader().ToBitmap()).GetThumbnail(150, 150);
            Image newImage = image.FixedPos(new Size(332, 453), new Point(247, 102));
            return new PrintFixedImage() { X = -7, Y = 0, Page = 1, PrintOffset = true, Content = newImage };
        }


        private TextPrintContentBuffer mutiContent()
        {
            TextPrintContentBuffer sb = new TextPrintContentBuffer();
            sb.AppendText("党的十九大是在我国全面建成小康社会决胜阶段召开的一次十分重要的代表大会十九大代表是从全体党员中千挑万选出来的优秀分子坚决同以习近平同志为核心的党中央保持高度一致", 9, false);
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("导办信息单", 20, true);

            Bitmap img = new BaseQrCode().Generator("http://image.baidu.com/search/index?tn=baiduimage&ct=201326592&lm=-1&cl=2&ie=gbk&word=%C8%FD%BD%C7%BC%FD%CD%B7%20%CD%BC%C6%AC&hs=2&xthttps=000000&fr=ala&ori_query=%E4%B8%89%E8%A7%92%E7%AE%AD%E5%A4%B4%20%E5%9B%BE%E7%89%87&ala=0&alatpl=sp&pos=0", 170).ToBitmap();

            sb.AppendImage(img);
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("浙江温州浙江温州皮革厂倒闭了");
            sb.AppendText("安全驾驶，文明出行", 20);

            return sb;
        }

        private StringBuilder testContent()
        {
            StringBuilder sb = new StringBuilder();

            string tou = "派号信息单 [福南中队]".PadSpaceOfMiddle(44);

            string saleID = "201703310001";

            sb.AppendLine(tou);

            sb.AppendLine("日期:" + DateTime.Now.ToShortDateString() + "  单号:" + saleID);
            sb.AppendLine("------------------------------");
            sb.AppendLine("必需要在窗口办理的违章：");
            sb.AppendLine("序号  违法行为  违法时间  违法地点  采集机关");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("------------------------------");
            sb.AppendLine("可在好易自助终端处理的违章：");
            sb.AppendLine("序号  违法行为  违法时间  违法地点  采集机关");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("------------------------------");

            sb.AppendLine("必需回采集机关处理的违章：");
            sb.AppendLine("序号  违法行为  违法时间  违法地点  采集机关");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("1  闯红灯  2017/01/1  龙井路  南山大队");
            sb.AppendLine("------------------------------");
            sb.AppendLine("安全驾驶，文明出行".PadSpaceOfMiddle(44));

            return sb;
        }

        private void imageColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitImageColorDoc();
            this.imageColorToolStripMenuItem.Checked = true;
            iamgeColorDoc.Show(MainDockPanel, DockState.Document);
            iamgeColorDoc.FormClosing += DummyClosing;
        }

        private ImageUtil.ImageColorDoc iamgeColorDoc;
        private void InitImageColorDoc()
        {
            if (iamgeColorDoc == null || iamgeColorDoc.IsDisposed) iamgeColorDoc = new ImageUtil.ImageColorDoc();
        }

        private void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = new MailHelper().Send("smtp.163.com", 25, "p2soft@163.com", "", "Sanyi", new string[] { "aping.yellow@qq.com" }, new string[] { "sanyiws@qq.com" }, "This is test mail", "Hello world.");
            MessageBox.Show(result);
        }
    }
}
