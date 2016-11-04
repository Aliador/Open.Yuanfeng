using Yuanfeng.Unit.FaceFeatureCompare;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    partial class VidetekLiveingDetectDoc
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
            this.btnInit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.videtekLDControl1 = new VidetekLDControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(668, 12);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(668, 41);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(668, 70);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 23);
            this.btnRelease.TabIndex = 1;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(668, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // videtekLDControl1
            // 
            this.videtekLDControl1.BackColor = System.Drawing.Color.DarkKhaki;
            this.videtekLDControl1.Location = new System.Drawing.Point(12, 12);
            this.videtekLDControl1.Name = "videtekLDControl1";
            this.videtekLDControl1.Size = new System.Drawing.Size(640, 480);
            this.videtekLDControl1.TabIndex = 0;
            // 
            // VidetekLiveingDetectDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 479);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.videtekLDControl1);
            this.Name = "VidetekLiveingDetectDoc";
            this.Text = "VidetekLiveingDetectDoc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VidetekLiveingDetectDoc_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.PictureBox pictureBox1;
        private VidetekLDControl videtekLDControl1;
    }
}