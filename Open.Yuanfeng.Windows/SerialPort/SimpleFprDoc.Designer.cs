namespace Open.Yuanfeng.Windows.SerialPort
{
    partial class SimpleFprDoc
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Channel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Timeout = new System.Windows.Forms.NumericUpDown();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FingerImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FingerQuality = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Channel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FingerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(383, 65);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel Selection";
            // 
            // Channel
            // 
            this.Channel.Location = new System.Drawing.Point(188, 63);
            this.Channel.Name = "Channel";
            this.Channel.Size = new System.Drawing.Size(120, 21);
            this.Channel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Live Timeout";
            // 
            // Timeout
            // 
            this.Timeout.Location = new System.Drawing.Point(188, 94);
            this.Timeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Timeout.Name = "Timeout";
            this.Timeout.Size = new System.Drawing.Size(120, 21);
            this.Timeout.TabIndex = 2;
            this.Timeout.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(383, 96);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(476, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Finger Quality:";
            // 
            // FingerImage
            // 
            this.FingerImage.Location = new System.Drawing.Point(188, 138);
            this.FingerImage.Name = "FingerImage";
            this.FingerImage.Size = new System.Drawing.Size(96, 116);
            this.FingerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FingerImage.TabIndex = 3;
            this.FingerImage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Finger Image";
            // 
            // FingerQuality
            // 
            this.FingerQuality.AutoSize = true;
            this.FingerQuality.Location = new System.Drawing.Point(391, 242);
            this.FingerQuality.Name = "FingerQuality";
            this.FingerQuality.Size = new System.Drawing.Size(0, 12);
            this.FingerQuality.TabIndex = 1;
            // 
            // SimpleFprDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 464);
            this.Controls.Add(this.FingerImage);
            this.Controls.Add(this.Timeout);
            this.Controls.Add(this.Channel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FingerQuality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnOpen);
            this.Name = "SimpleFprDoc";
            this.Text = "SimpleFprDoc";
            ((System.ComponentModel.ISupportInitialize)(this.Channel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FingerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Channel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Timeout;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox FingerImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label FingerQuality;
    }
}