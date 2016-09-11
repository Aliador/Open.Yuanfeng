namespace Open.Yuanfeng.Windows.SerialPort
{
    partial class SimpleCameraDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleCameraDoc));
            this.CameraContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDeviceName = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnRealase = new System.Windows.Forms.Button();
            this.SnapshotImage = new System.Windows.Forms.PictureBox();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.btnSnapshotSwitch = new System.Windows.Forms.Button();
            this.SnapshotInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SnapshotCount = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraContainer
            // 
            this.CameraContainer.Location = new System.Drawing.Point(12, 55);
            this.CameraContainer.Name = "CameraContainer";
            this.CameraContainer.Size = new System.Drawing.Size(640, 443);
            this.CameraContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Camera Device Selection:";
            // 
            // textBoxDeviceName
            // 
            this.textBoxDeviceName.Location = new System.Drawing.Point(163, 20);
            this.textBoxDeviceName.Name = "textBoxDeviceName";
            this.textBoxDeviceName.Size = new System.Drawing.Size(322, 21);
            this.textBoxDeviceName.TabIndex = 2;
            this.textBoxDeviceName.Text = "HD USB Camera";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(496, 19);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 21);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "Open";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnRealase
            // 
            this.btnRealase.Location = new System.Drawing.Point(577, 19);
            this.btnRealase.Name = "btnRealase";
            this.btnRealase.Size = new System.Drawing.Size(75, 21);
            this.btnRealase.TabIndex = 3;
            this.btnRealase.Text = "Close";
            this.btnRealase.UseVisualStyleBackColor = true;
            this.btnRealase.Click += new System.EventHandler(this.btnRealase_Click);
            // 
            // SnapshotImage
            // 
            this.SnapshotImage.Location = new System.Drawing.Point(683, 55);
            this.SnapshotImage.Name = "SnapshotImage";
            this.SnapshotImage.Size = new System.Drawing.Size(200, 138);
            this.SnapshotImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SnapshotImage.TabIndex = 4;
            this.SnapshotImage.TabStop = false;
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Location = new System.Drawing.Point(683, 19);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(75, 21);
            this.btnSnapshot.TabIndex = 3;
            this.btnSnapshot.Text = "Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // btnSnapshotSwitch
            // 
            this.btnSnapshotSwitch.Location = new System.Drawing.Point(808, 213);
            this.btnSnapshotSwitch.Name = "btnSnapshotSwitch";
            this.btnSnapshotSwitch.Size = new System.Drawing.Size(75, 21);
            this.btnSnapshotSwitch.TabIndex = 3;
            this.btnSnapshotSwitch.Text = "Begin";
            this.btnSnapshotSwitch.UseVisualStyleBackColor = true;
            this.btnSnapshotSwitch.Click += new System.EventHandler(this.btnSnapshotSwitch_Click);
            // 
            // SnapshotInterval
            // 
            this.SnapshotInterval.Location = new System.Drawing.Point(742, 213);
            this.SnapshotInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SnapshotInterval.Name = "SnapshotInterval";
            this.SnapshotInterval.Size = new System.Drawing.Size(61, 21);
            this.SnapshotInterval.TabIndex = 5;
            this.SnapshotInterval.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(681, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Interval:";
            // 
            // SnapshotCount
            // 
            this.SnapshotCount.AutoSize = true;
            this.SnapshotCount.Location = new System.Drawing.Point(889, 182);
            this.SnapshotCount.Name = "SnapshotCount";
            this.SnapshotCount.Size = new System.Drawing.Size(0, 12);
            this.SnapshotCount.TabIndex = 6;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(683, 250);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 21);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(764, 250);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(75, 21);
            this.Decrypt.TabIndex = 3;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // SimpleCameraDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 519);
            this.Controls.Add(this.SnapshotCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SnapshotInterval);
            this.Controls.Add(this.SnapshotImage);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnSnapshotSwitch);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.btnRealase);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.textBoxDeviceName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CameraContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimpleCameraDoc";
            this.Text = "SimpleCamera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimpleCameraDoc_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CameraContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDeviceName;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnRealase;
        private System.Windows.Forms.PictureBox SnapshotImage;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Button btnSnapshotSwitch;
        private System.Windows.Forms.NumericUpDown SnapshotInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SnapshotCount;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button Decrypt;
    }
}