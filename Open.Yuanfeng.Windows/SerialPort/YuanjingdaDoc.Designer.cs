﻿namespace Open.Yuanfeng.Windows.SerialPort
{
    partial class YuanjingdaDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YuanjingdaDoc));
            this.cmbSerialPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeviceName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReceivedData = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnRealase = new System.Windows.Forms.Button();
            this.btnOpenOnline = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLiveScan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MatchCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSerialPortName
            // 
            this.cmbSerialPortName.FormattingEnabled = true;
            this.cmbSerialPortName.Items.AddRange(new object[] {
            "----COM1----",
            "----COM2----",
            "----COM3----",
            "----COM4----",
            "----COM5----",
            "----COM6----",
            "----COM7----",
            "----COM8----",
            "----COM9----",
            "----COM10----",
            "----COM11----",
            "----COM12----",
            "----COM13----",
            "----COM14----",
            "----COM15----",
            "----COM16----",
            "----COM17----",
            "----COM18----",
            "----COM19----",
            "----COM20----"});
            this.cmbSerialPortName.Location = new System.Drawing.Point(139, 31);
            this.cmbSerialPortName.Name = "cmbSerialPortName";
            this.cmbSerialPortName.Size = new System.Drawing.Size(247, 20);
            this.cmbSerialPortName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port Name :";
            // 
            // cmbDeviceName
            // 
            this.cmbDeviceName.FormattingEnabled = true;
            this.cmbDeviceName.Items.AddRange(new object[] {
            "----LV420R----",
            "----LV100R----"});
            this.cmbDeviceName.Location = new System.Drawing.Point(139, 61);
            this.cmbDeviceName.Name = "cmbDeviceName";
            this.cmbDeviceName.Size = new System.Drawing.Size(247, 20);
            this.cmbDeviceName.TabIndex = 0;
            this.cmbDeviceName.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Device Name :";
            // 
            // tbReceivedData
            // 
            this.tbReceivedData.Location = new System.Drawing.Point(44, 115);
            this.tbReceivedData.Multiline = true;
            this.tbReceivedData.Name = "tbReceivedData";
            this.tbReceivedData.Size = new System.Drawing.Size(603, 310);
            this.tbReceivedData.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(406, 30);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 21);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(406, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 21);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(572, 30);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 21);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnRealase
            // 
            this.btnRealase.Location = new System.Drawing.Point(572, 59);
            this.btnRealase.Name = "btnRealase";
            this.btnRealase.Size = new System.Drawing.Size(75, 21);
            this.btnRealase.TabIndex = 3;
            this.btnRealase.Text = "Realase";
            this.btnRealase.UseVisualStyleBackColor = true;
            this.btnRealase.Click += new System.EventHandler(this.btnRealase_Click);
            // 
            // btnOpenOnline
            // 
            this.btnOpenOnline.Location = new System.Drawing.Point(489, 30);
            this.btnOpenOnline.Name = "btnOpenOnline";
            this.btnOpenOnline.Size = new System.Drawing.Size(75, 21);
            this.btnOpenOnline.TabIndex = 3;
            this.btnOpenOnline.Text = "OpenOnline";
            this.btnOpenOnline.UseVisualStyleBackColor = true;
            this.btnOpenOnline.Click += new System.EventHandler(this.btnOpenOnline_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLiveScan);
            this.groupBox1.Location = new System.Drawing.Point(653, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 99);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拓展功能";
            // 
            // btnLiveScan
            // 
            this.btnLiveScan.Location = new System.Drawing.Point(6, 18);
            this.btnLiveScan.Name = "btnLiveScan";
            this.btnLiveScan.Size = new System.Drawing.Size(75, 21);
            this.btnLiveScan.TabIndex = 3;
            this.btnLiveScan.Text = "LiveScan";
            this.btnLiveScan.UseVisualStyleBackColor = true;
            this.btnLiveScan.Click += new System.EventHandler(this.btnLiveScan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "MatchCodeCount :";
            // 
            // MatchCount
            // 
            this.MatchCount.AutoSize = true;
            this.MatchCount.Location = new System.Drawing.Point(764, 136);
            this.MatchCount.Name = "MatchCount";
            this.MatchCount.Size = new System.Drawing.Size(0, 12);
            this.MatchCount.TabIndex = 1;
            // 
            // YuanjingdaDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 476);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRealase);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnOpenOnline);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbReceivedData);
            this.Controls.Add(this.MatchCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDeviceName);
            this.Controls.Add(this.cmbSerialPortName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YuanjingdaDoc";
            this.Text = "Yuanjingda BR/QR Device";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YuanjingdaDoc_FormClosing);
            this.Load += new System.EventHandler(this.YuanjingdaDoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSerialPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeviceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReceivedData;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnRealase;
        private System.Windows.Forms.Button btnOpenOnline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLiveScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MatchCount;
    }
}