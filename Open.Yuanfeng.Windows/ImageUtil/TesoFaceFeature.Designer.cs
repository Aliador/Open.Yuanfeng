namespace Open.Yuanfeng.Windows.ImageUtil
{
    partial class TesoFaceFeature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesoFaceFeature));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDeviceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.CameraContainer = new System.Windows.Forms.Panel();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTips = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Snapshot = new System.Windows.Forms.Button();
            this.picSnapshot = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSnapshot)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera Selection";
            // 
            // textBoxDeviceName
            // 
            this.textBoxDeviceName.Location = new System.Drawing.Point(139, 29);
            this.textBoxDeviceName.Name = "textBoxDeviceName";
            this.textBoxDeviceName.Size = new System.Drawing.Size(232, 21);
            this.textBoxDeviceName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source Image";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(139, 55);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(232, 21);
            this.textBoxFilename.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(377, 54);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // CameraContainer
            // 
            this.CameraContainer.Location = new System.Drawing.Point(58, 95);
            this.CameraContainer.Name = "CameraContainer";
            this.CameraContainer.Size = new System.Drawing.Size(400, 300);
            this.CameraContainer.TabIndex = 3;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(477, 27);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 2;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(477, 54);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 23);
            this.btnRelease.TabIndex = 2;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // picPhoto
            // 
            this.picPhoto.Location = new System.Drawing.Point(477, 95);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(115, 138);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.TabIndex = 4;
            this.picPhoto.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Compare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Location = new System.Drawing.Point(570, 284);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(0, 12);
            this.lblTips.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Compare Result";
            // 
            // Snapshot
            // 
            this.Snapshot.Location = new System.Drawing.Point(649, 210);
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.Size = new System.Drawing.Size(75, 23);
            this.Snapshot.TabIndex = 2;
            this.Snapshot.Text = "Snapshot";
            this.Snapshot.UseVisualStyleBackColor = true;
            this.Snapshot.Click += new System.EventHandler(this.Snapshot_Click);
            // 
            // picSnapshot
            // 
            this.picSnapshot.Location = new System.Drawing.Point(624, 109);
            this.picSnapshot.Name = "picSnapshot";
            this.picSnapshot.Size = new System.Drawing.Size(120, 90);
            this.picSnapshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSnapshot.TabIndex = 4;
            this.picSnapshot.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TesoFaceFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 441);
            this.Controls.Add(this.picSnapshot);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.CameraContainer);
            this.Controls.Add(this.Snapshot);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.textBoxFilename);
            this.Controls.Add(this.textBoxDeviceName);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TesoFaceFeature";
            this.Text = "TesoFaceFeature";
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSnapshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDeviceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel CameraContainer;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Snapshot;
        private System.Windows.Forms.PictureBox picSnapshot;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}