﻿//using Yuanfeng.WinFormsUI.Docking;

using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.WinFormsUI.Docking.ThemeVS2012;

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
            this.pluginsConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NwListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NwSwithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleSocketXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleUdpClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleUdpServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redisClientDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YuanjingdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleIDRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleFprCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aviRecorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageUtilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleQrCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindGrayImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleOcrDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tesoFaceFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tesoLFCDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videtekFeactureDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynamicInvokeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printerPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleTextDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.vS2012LightTheme = new VS2012LightTheme();
            this.MainDockPanel = new DockPanel();
            this.sendMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ImageUtilToolStripMenuItem,
            this.httpXToolStripMenuItem,
            this.printerPToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(957, 24);
            this.MainMenuStrip.TabIndex = 0;
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginsConfigToolStripMenuItem,
            this.testDocToolStripMenuItem,
            this.copyScreenToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // pluginsConfigToolStripMenuItem
            // 
            this.pluginsConfigToolStripMenuItem.Name = "pluginsConfigToolStripMenuItem";
            this.pluginsConfigToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.pluginsConfigToolStripMenuItem.Text = "PluginsConfig";
            this.pluginsConfigToolStripMenuItem.Click += new System.EventHandler(this.pluginsConfigToolStripMenuItem_Click);
            // 
            // testDocToolStripMenuItem
            // 
            this.testDocToolStripMenuItem.Name = "testDocToolStripMenuItem";
            this.testDocToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.testDocToolStripMenuItem.Text = "TestDoc";
            this.testDocToolStripMenuItem.Click += new System.EventHandler(this.testDocToolStripMenuItem_Click);
            // 
            // copyScreenToolStripMenuItem
            // 
            this.copyScreenToolStripMenuItem.Name = "copyScreenToolStripMenuItem";
            this.copyScreenToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.copyScreenToolStripMenuItem.Text = "CopyScreen";
            this.copyScreenToolStripMenuItem.Click += new System.EventHandler(this.copyScreenToolStripMenuItem_Click);
            // 
            // NetworkToolStripMenuItem
            // 
            this.NetworkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NwListToolStripMenuItem,
            this.NwSwithToolStripMenuItem,
            this.simpleSocketXToolStripMenuItem,
            this.redisClientDocToolStripMenuItem});
            this.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem";
            this.NetworkToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.NetworkToolStripMenuItem.Text = "Network(&N)";
            // 
            // NwListToolStripMenuItem
            // 
            this.NwListToolStripMenuItem.Name = "NwListToolStripMenuItem";
            this.NwListToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.NwListToolStripMenuItem.Text = "Interface List(&L)";
            // 
            // NwSwithToolStripMenuItem
            // 
            this.NwSwithToolStripMenuItem.Name = "NwSwithToolStripMenuItem";
            this.NwSwithToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.NwSwithToolStripMenuItem.Text = "Enable All(&E)";
            // 
            // simpleSocketXToolStripMenuItem
            // 
            this.simpleSocketXToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleUdpClientToolStripMenuItem,
            this.simpleUdpServerToolStripMenuItem});
            this.simpleSocketXToolStripMenuItem.Name = "simpleSocketXToolStripMenuItem";
            this.simpleSocketXToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.simpleSocketXToolStripMenuItem.Text = "SimpleSocketX";
            // 
            // simpleUdpClientToolStripMenuItem
            // 
            this.simpleUdpClientToolStripMenuItem.Name = "simpleUdpClientToolStripMenuItem";
            this.simpleUdpClientToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.simpleUdpClientToolStripMenuItem.Text = "SimpleUdpClient";
            this.simpleUdpClientToolStripMenuItem.Click += new System.EventHandler(this.simpleUdpClientToolStripMenuItem_Click);
            // 
            // simpleUdpServerToolStripMenuItem
            // 
            this.simpleUdpServerToolStripMenuItem.Name = "simpleUdpServerToolStripMenuItem";
            this.simpleUdpServerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.simpleUdpServerToolStripMenuItem.Text = "SimpleUdpServer";
            this.simpleUdpServerToolStripMenuItem.Click += new System.EventHandler(this.simpleUdpServerToolStripMenuItem_Click);
            // 
            // redisClientDocToolStripMenuItem
            // 
            this.redisClientDocToolStripMenuItem.Name = "redisClientDocToolStripMenuItem";
            this.redisClientDocToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.redisClientDocToolStripMenuItem.Text = "RedisClientDoc(&R)";
            this.redisClientDocToolStripMenuItem.Click += new System.EventHandler(this.redisClientDocToolStripMenuItem_Click);
            // 
            // WindowsToolStripMenuItem
            // 
            this.WindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConsoleToolStripMenuItem});
            this.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem";
            this.WindowsToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.WindowsToolStripMenuItem.Text = "Window(&W)";
            // 
            // ConsoleToolStripMenuItem
            // 
            this.ConsoleToolStripMenuItem.Name = "ConsoleToolStripMenuItem";
            this.ConsoleToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ConsoleToolStripMenuItem.Text = "Console(&C)";
            this.ConsoleToolStripMenuItem.Click += new System.EventHandler(this.ConsoleToolStripMenuItem_Click);
            // 
            // HelperToolStripMenuItem
            // 
            this.HelperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.HelperToolStripMenuItem.Name = "HelperToolStripMenuItem";
            this.HelperToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.HelperToolStripMenuItem.Text = "Helper(&H)";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "About(&X)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // SerialPortToolStripMenuItem
            // 
            this.SerialPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YuanjingdaToolStripMenuItem,
            this.CameraToolStripMenuItem,
            this.SimpleCameraToolStripMenuItem,
            this.SimpleIDRToolStripMenuItem,
            this.SimpleFprCaptureToolStripMenuItem,
            this.aviRecorderToolStripMenuItem});
            this.SerialPortToolStripMenuItem.Name = "SerialPortToolStripMenuItem";
            this.SerialPortToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.SerialPortToolStripMenuItem.Text = "SerialPort(&P)";
            // 
            // YuanjingdaToolStripMenuItem
            // 
            this.YuanjingdaToolStripMenuItem.Name = "YuanjingdaToolStripMenuItem";
            this.YuanjingdaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.YuanjingdaToolStripMenuItem.Text = "Yuanjingda(&Y)";
            this.YuanjingdaToolStripMenuItem.Click += new System.EventHandler(this.YuanjingdaToolStripMenuItem_Click);
            // 
            // CameraToolStripMenuItem
            // 
            this.CameraToolStripMenuItem.Name = "CameraToolStripMenuItem";
            this.CameraToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.CameraToolStripMenuItem.Text = "Camera(&C)";
            this.CameraToolStripMenuItem.Click += new System.EventHandler(this.CameraToolStripMenuItem_Click);
            // 
            // SimpleCameraToolStripMenuItem
            // 
            this.SimpleCameraToolStripMenuItem.Name = "SimpleCameraToolStripMenuItem";
            this.SimpleCameraToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.SimpleCameraToolStripMenuItem.Text = "SimpleCamera(&D)";
            this.SimpleCameraToolStripMenuItem.Click += new System.EventHandler(this.SimpleCameraToolStripMenuItem_Click);
            // 
            // SimpleIDRToolStripMenuItem
            // 
            this.SimpleIDRToolStripMenuItem.Name = "SimpleIDRToolStripMenuItem";
            this.SimpleIDRToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.SimpleIDRToolStripMenuItem.Text = "SimpleIDR(&E)";
            this.SimpleIDRToolStripMenuItem.Click += new System.EventHandler(this.SimpleIDRToolStripMenuItem_Click);
            // 
            // SimpleFprCaptureToolStripMenuItem
            // 
            this.SimpleFprCaptureToolStripMenuItem.Name = "SimpleFprCaptureToolStripMenuItem";
            this.SimpleFprCaptureToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.SimpleFprCaptureToolStripMenuItem.Text = "SimpleFprCapture(&F)";
            this.SimpleFprCaptureToolStripMenuItem.Click += new System.EventHandler(this.SimpleFprCaptureToolStripMenuItem_Click);
            // 
            // aviRecorderToolStripMenuItem
            // 
            this.aviRecorderToolStripMenuItem.Name = "aviRecorderToolStripMenuItem";
            this.aviRecorderToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.aviRecorderToolStripMenuItem.Text = "AviRecorder(&R)";
            this.aviRecorderToolStripMenuItem.Click += new System.EventHandler(this.aviRecorderToolStripMenuItem_Click);
            // 
            // ImageUtilToolStripMenuItem
            // 
            this.ImageUtilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleQrCodeToolStripMenuItem,
            this.FindGrayImageToolStripMenuItem,
            this.SimpleOcrDocToolStripMenuItem,
            this.tesoFaceFeatureToolStripMenuItem,
            this.tesoLFCDocToolStripMenuItem,
            this.videtekFeactureDToolStripMenuItem,
            this.imageColorToolStripMenuItem});
            this.ImageUtilToolStripMenuItem.Name = "ImageUtilToolStripMenuItem";
            this.ImageUtilToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.ImageUtilToolStripMenuItem.Text = "ImageUtil(&I)";
            // 
            // SimpleQrCodeToolStripMenuItem
            // 
            this.SimpleQrCodeToolStripMenuItem.Name = "SimpleQrCodeToolStripMenuItem";
            this.SimpleQrCodeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.SimpleQrCodeToolStripMenuItem.Text = "SimpleQrCode(&Q)";
            this.SimpleQrCodeToolStripMenuItem.Click += new System.EventHandler(this.SimpleQrCodeToolStripMenuItem_Click);
            // 
            // FindGrayImageToolStripMenuItem
            // 
            this.FindGrayImageToolStripMenuItem.Name = "FindGrayImageToolStripMenuItem";
            this.FindGrayImageToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.FindGrayImageToolStripMenuItem.Text = "FindGrayImage(&F)";
            this.FindGrayImageToolStripMenuItem.Click += new System.EventHandler(this.FindGrayImageToolStripMenuItem_Click);
            // 
            // SimpleOcrDocToolStripMenuItem
            // 
            this.SimpleOcrDocToolStripMenuItem.Name = "SimpleOcrDocToolStripMenuItem";
            this.SimpleOcrDocToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.SimpleOcrDocToolStripMenuItem.Text = "SimpleOcrDoc(&O)";
            this.SimpleOcrDocToolStripMenuItem.Click += new System.EventHandler(this.SimpleOcrDocToolStripMenuItem_Click);
            // 
            // tesoFaceFeatureToolStripMenuItem
            // 
            this.tesoFaceFeatureToolStripMenuItem.Name = "tesoFaceFeatureToolStripMenuItem";
            this.tesoFaceFeatureToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.tesoFaceFeatureToolStripMenuItem.Text = "TesoFaceFeature(&T)";
            this.tesoFaceFeatureToolStripMenuItem.Click += new System.EventHandler(this.tesoFaceFeatureToolStripMenuItem_Click);
            // 
            // tesoLFCDocToolStripMenuItem
            // 
            this.tesoLFCDocToolStripMenuItem.Name = "tesoLFCDocToolStripMenuItem";
            this.tesoLFCDocToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.tesoLFCDocToolStripMenuItem.Text = "TesoLFCDoc(&L)";
            this.tesoLFCDocToolStripMenuItem.Click += new System.EventHandler(this.tesoLFCDocToolStripMenuItem_Click);
            // 
            // videtekFeactureDToolStripMenuItem
            // 
            this.videtekFeactureDToolStripMenuItem.Name = "videtekFeactureDToolStripMenuItem";
            this.videtekFeactureDToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.videtekFeactureDToolStripMenuItem.Text = "VidetekFeacture(&D)";
            this.videtekFeactureDToolStripMenuItem.Click += new System.EventHandler(this.videtekFeactureDToolStripMenuItem_Click);
            // 
            // imageColorToolStripMenuItem
            // 
            this.imageColorToolStripMenuItem.Name = "imageColorToolStripMenuItem";
            this.imageColorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.imageColorToolStripMenuItem.Text = "ImageColor";
            this.imageColorToolStripMenuItem.Click += new System.EventHandler(this.imageColorToolStripMenuItem_Click);
            // 
            // httpXToolStripMenuItem
            // 
            this.httpXToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dynamicInvokeToolStripMenuItem,
            this.sendMailToolStripMenuItem});
            this.httpXToolStripMenuItem.Name = "httpXToolStripMenuItem";
            this.httpXToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.httpXToolStripMenuItem.Text = "HttpX";
            // 
            // dynamicInvokeToolStripMenuItem
            // 
            this.dynamicInvokeToolStripMenuItem.Name = "dynamicInvokeToolStripMenuItem";
            this.dynamicInvokeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.dynamicInvokeToolStripMenuItem.Text = "DynamicInvoke";
            this.dynamicInvokeToolStripMenuItem.Click += new System.EventHandler(this.dynamicInvokeToolStripMenuItem_Click);
            // 
            // printerPToolStripMenuItem
            // 
            this.printerPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleTextDocToolStripMenuItem});
            this.printerPToolStripMenuItem.Name = "printerPToolStripMenuItem";
            this.printerPToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.printerPToolStripMenuItem.Text = "Printer(&P)";
            // 
            // simpleTextDocToolStripMenuItem
            // 
            this.simpleTextDocToolStripMenuItem.Name = "simpleTextDocToolStripMenuItem";
            this.simpleTextDocToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.simpleTextDocToolStripMenuItem.Text = "SimpleTextDoc";
            this.simpleTextDocToolStripMenuItem.Click += new System.EventHandler(this.simpleTextDocToolStripMenuItem_Click);
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
            this.MainDockPanel.Location = new System.Drawing.Point(0, 24);
            this.MainDockPanel.Name = "MainDockPanel";
            this.MainDockPanel.ShowDocumentIcon = true;
            this.MainDockPanel.Size = new System.Drawing.Size(957, 455);
            this.MainDockPanel.TabIndex = 2;
            // 
            // sendMailToolStripMenuItem
            // 
            this.sendMailToolStripMenuItem.Name = "sendMailToolStripMenuItem";
            this.sendMailToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.sendMailToolStripMenuItem.Text = "SendMail";
            this.sendMailToolStripMenuItem.Click += new System.EventHandler(this.sendMailToolStripMenuItem_Click);
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
        private VS2012LightTheme vS2012LightTheme;
        private DockPanel MainDockPanel;
        private System.Windows.Forms.ToolStripMenuItem HelperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SerialPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YuanjingdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageUtilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleQrCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindGrayImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleIDRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleFprCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleOcrDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleSocketXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleUdpClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleUdpServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem httpXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dynamicInvokeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tesoFaceFeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tesoLFCDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redisClientDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videtekFeactureDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aviRecorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printerPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleTextDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMailToolStripMenuItem;
    }
}

