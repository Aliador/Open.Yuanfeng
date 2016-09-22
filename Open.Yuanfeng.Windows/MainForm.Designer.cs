namespace Open.Yuanfeng.Windows
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NwListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NwSwithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YuanjingdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageUtilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleQrCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindGrayImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.vS2012LightTheme = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            this.MainDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.SimpleIDRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.NetworkToolStripMenuItem,
            this.WindowsToolStripMenuItem,
            this.HelperToolStripMenuItem,
            this.SerialPortToolStripMenuItem,
            this.ImageUtilToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(957, 25);
            this.MainMenuStrip.TabIndex = 0;
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // NetworkToolStripMenuItem
            // 
            this.NetworkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NwListToolStripMenuItem,
            this.NwSwithToolStripMenuItem});
            this.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem";
            this.NetworkToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.NetworkToolStripMenuItem.Text = "Network(&N)";
            // 
            // NwListToolStripMenuItem
            // 
            this.NwListToolStripMenuItem.Name = "NwListToolStripMenuItem";
            this.NwListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.NwListToolStripMenuItem.Text = "Interface List(&L)";
            // 
            // NwSwithToolStripMenuItem
            // 
            this.NwSwithToolStripMenuItem.Name = "NwSwithToolStripMenuItem";
            this.NwSwithToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.NwSwithToolStripMenuItem.Text = "Enable All(&E)";
            // 
            // WindowsToolStripMenuItem
            // 
            this.WindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConsoleToolStripMenuItem});
            this.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem";
            this.WindowsToolStripMenuItem.Size = new System.Drawing.Size(87, 21);
            this.WindowsToolStripMenuItem.Text = "Window(&W)";
            // 
            // ConsoleToolStripMenuItem
            // 
            this.ConsoleToolStripMenuItem.Name = "ConsoleToolStripMenuItem";
            this.ConsoleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ConsoleToolStripMenuItem.Text = "Console(&C)";
            this.ConsoleToolStripMenuItem.Click += new System.EventHandler(this.ConsoleToolStripMenuItem_Click);
            // 
            // HelperToolStripMenuItem
            // 
            this.HelperToolStripMenuItem.Name = "HelperToolStripMenuItem";
            this.HelperToolStripMenuItem.Size = new System.Drawing.Size(76, 21);
            this.HelperToolStripMenuItem.Text = "Helper(&H)";
            // 
            // SerialPortToolStripMenuItem
            // 
            this.SerialPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YuanjingdaToolStripMenuItem,
            this.CameraToolStripMenuItem,
            this.SimpleCameraToolStripMenuItem,
            this.SimpleIDRToolStripMenuItem});
            this.SerialPortToolStripMenuItem.Name = "SerialPortToolStripMenuItem";
            this.SerialPortToolStripMenuItem.Size = new System.Drawing.Size(91, 21);
            this.SerialPortToolStripMenuItem.Text = "SerialPort(&P)";
            // 
            // YuanjingdaToolStripMenuItem
            // 
            this.YuanjingdaToolStripMenuItem.Name = "YuanjingdaToolStripMenuItem";
            this.YuanjingdaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.YuanjingdaToolStripMenuItem.Text = "Yuanjingda(&Y)";
            this.YuanjingdaToolStripMenuItem.Click += new System.EventHandler(this.YuanjingdaToolStripMenuItem_Click);
            // 
            // CameraToolStripMenuItem
            // 
            this.CameraToolStripMenuItem.Name = "CameraToolStripMenuItem";
            this.CameraToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.CameraToolStripMenuItem.Text = "Camera(&C)";
            this.CameraToolStripMenuItem.Click += new System.EventHandler(this.CameraToolStripMenuItem_Click);
            // 
            // SimpleCameraToolStripMenuItem
            // 
            this.SimpleCameraToolStripMenuItem.Name = "SimpleCameraToolStripMenuItem";
            this.SimpleCameraToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.SimpleCameraToolStripMenuItem.Text = "SimpleCamera(&D)";
            this.SimpleCameraToolStripMenuItem.Click += new System.EventHandler(this.SimpleCameraToolStripMenuItem_Click);
            // 
            // ImageUtilToolStripMenuItem
            // 
            this.ImageUtilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleQrCodeToolStripMenuItem,
            this.FindGrayImageToolStripMenuItem});
            this.ImageUtilToolStripMenuItem.Name = "ImageUtilToolStripMenuItem";
            this.ImageUtilToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.ImageUtilToolStripMenuItem.Text = "ImageUtil(&I)";
            // 
            // SimpleQrCodeToolStripMenuItem
            // 
            this.SimpleQrCodeToolStripMenuItem.Name = "SimpleQrCodeToolStripMenuItem";
            this.SimpleQrCodeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.SimpleQrCodeToolStripMenuItem.Text = "SimpleQrCode(&Q)";
            this.SimpleQrCodeToolStripMenuItem.Click += new System.EventHandler(this.SimpleQrCodeToolStripMenuItem_Click);
            // 
            // FindGrayImageToolStripMenuItem
            // 
            this.FindGrayImageToolStripMenuItem.Name = "FindGrayImageToolStripMenuItem";
            this.FindGrayImageToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.FindGrayImageToolStripMenuItem.Text = "FindGrayImage(&F)";
            this.FindGrayImageToolStripMenuItem.Click += new System.EventHandler(this.FindGrayImageToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 479);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(957, 22);
            this.MainStatusStrip.TabIndex = 1;
            // 
            // MainDockPanel
            // 
            this.MainDockPanel.AllowDrop = true;
            this.MainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDockPanel.Location = new System.Drawing.Point(0, 25);
            this.MainDockPanel.Name = "MainDockPanel";
            this.MainDockPanel.ShowDocumentIcon = true;
            this.MainDockPanel.Size = new System.Drawing.Size(957, 454);
            this.MainDockPanel.TabIndex = 2;
            // 
            // SimpleIDRToolStripMenuItem
            // 
            this.SimpleIDRToolStripMenuItem.Name = "SimpleIDRToolStripMenuItem";
            this.SimpleIDRToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.SimpleIDRToolStripMenuItem.Text = "SimpleIDR(&E)";
            this.SimpleIDRToolStripMenuItem.Click += new System.EventHandler(this.SimpleIDRToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 501);
            this.Controls.Add(this.MainDockPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Yuanfeng Open Source Lib Test v1.0";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NwListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NwSwithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsoleToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme;
        private WeifenLuo.WinFormsUI.Docking.DockPanel MainDockPanel;
        private System.Windows.Forms.ToolStripMenuItem HelperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SerialPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YuanjingdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageUtilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleQrCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindGrayImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleIDRToolStripMenuItem;
    }
}

