namespace Open.Yuanfeng.Windows.SerialPort
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
            "----COM5----"});
            this.cmbSerialPortName.Location = new System.Drawing.Point(139, 34);
            this.cmbSerialPortName.Name = "cmbSerialPortName";
            this.cmbSerialPortName.Size = new System.Drawing.Size(247, 21);
            this.cmbSerialPortName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port Name :";
            // 
            // cmbDeviceName
            // 
            this.cmbDeviceName.FormattingEnabled = true;
            this.cmbDeviceName.Items.AddRange(new object[] {
            "----LV420R----"});
            this.cmbDeviceName.Location = new System.Drawing.Point(139, 66);
            this.cmbDeviceName.Name = "cmbDeviceName";
            this.cmbDeviceName.Size = new System.Drawing.Size(247, 21);
            this.cmbDeviceName.TabIndex = 0;
            this.cmbDeviceName.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Device Name :";
            // 
            // tbReceivedData
            // 
            this.tbReceivedData.Location = new System.Drawing.Point(44, 125);
            this.tbReceivedData.Multiline = true;
            this.tbReceivedData.Name = "tbReceivedData";
            this.tbReceivedData.Size = new System.Drawing.Size(603, 222);
            this.tbReceivedData.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(406, 33);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(406, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(572, 33);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnRealase
            // 
            this.btnRealase.Location = new System.Drawing.Point(572, 64);
            this.btnRealase.Name = "btnRealase";
            this.btnRealase.Size = new System.Drawing.Size(75, 23);
            this.btnRealase.TabIndex = 3;
            this.btnRealase.Text = "Realase";
            this.btnRealase.UseVisualStyleBackColor = true;
            this.btnRealase.Click += new System.EventHandler(this.btnRealase_Click);
            // 
            // btnOpenOnline
            // 
            this.btnOpenOnline.Location = new System.Drawing.Point(489, 33);
            this.btnOpenOnline.Name = "btnOpenOnline";
            this.btnOpenOnline.Size = new System.Drawing.Size(75, 23);
            this.btnOpenOnline.TabIndex = 3;
            this.btnOpenOnline.Text = "OpenOnline";
            this.btnOpenOnline.UseVisualStyleBackColor = true;
            this.btnOpenOnline.Click += new System.EventHandler(this.btnOpenOnline_Click);
            // 
            // YuanjingdaDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 379);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRealase);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnOpenOnline);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbReceivedData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDeviceName);
            this.Controls.Add(this.cmbSerialPortName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YuanjingdaDoc";
            this.Text = "Yuanjingda BR & QR Device";
            this.Load += new System.EventHandler(this.YuanjingdaDoc_Load);
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
    }
}