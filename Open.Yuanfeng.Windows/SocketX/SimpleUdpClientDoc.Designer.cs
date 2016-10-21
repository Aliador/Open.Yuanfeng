namespace Open.Yuanfeng.Windows.SocketX
{
    partial class SimpleUdpClientDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleUdpClientDoc));
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbSvrIpAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSvrPort = new System.Windows.Forms.TextBox();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnBug = new System.Windows.Forms.Button();
            this.btnError = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnFatal = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(101, 215);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(474, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbSvrIpAddr
            // 
            this.tbSvrIpAddr.Location = new System.Drawing.Point(101, 32);
            this.tbSvrIpAddr.Name = "tbSvrIpAddr";
            this.tbSvrIpAddr.Size = new System.Drawing.Size(167, 21);
            this.tbSvrIpAddr.TabIndex = 2;
            this.tbSvrIpAddr.Text = "192.168.100.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server IpAddr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // tbSvrPort
            // 
            this.tbSvrPort.Location = new System.Drawing.Point(309, 32);
            this.tbSvrPort.Name = "tbSvrPort";
            this.tbSvrPort.Size = new System.Drawing.Size(67, 21);
            this.tbSvrPort.TabIndex = 2;
            this.tbSvrPort.Text = "8099";
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(101, 74);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(448, 135);
            this.tbMsg.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(393, 31);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnBug
            // 
            this.btnBug.Location = new System.Drawing.Point(176, 215);
            this.btnBug.Name = "btnBug";
            this.btnBug.Size = new System.Drawing.Size(75, 23);
            this.btnBug.TabIndex = 0;
            this.btnBug.Text = "Debug";
            this.btnBug.UseVisualStyleBackColor = true;
            this.btnBug.Click += new System.EventHandler(this.btnBug_Click);
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(251, 215);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(75, 23);
            this.btnError.TabIndex = 0;
            this.btnError.Text = "Error";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(326, 215);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 0;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnFatal
            // 
            this.btnFatal.Location = new System.Drawing.Point(401, 215);
            this.btnFatal.Name = "btnFatal";
            this.btnFatal.Size = new System.Drawing.Size(75, 23);
            this.btnFatal.TabIndex = 0;
            this.btnFatal.Text = "Fatal";
            this.btnFatal.UseVisualStyleBackColor = true;
            this.btnFatal.Click += new System.EventHandler(this.btnFatal_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(476, 215);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 23);
            this.btnRelease.TabIndex = 0;
            this.btnRelease.Text = "Close";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // SimpleUdpClientDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 443);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSvrPort);
            this.Controls.Add(this.tbSvrIpAddr);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnFatal);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.btnBug);
            this.Controls.Add(this.btnSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimpleUdpClientDoc";
            this.Text = "SimpleUdpClientDoc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbSvrIpAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSvrPort;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnBug;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnFatal;
        private System.Windows.Forms.Button btnRelease;
    }
}