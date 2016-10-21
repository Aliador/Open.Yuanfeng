using Yuanfeng.ImageUnit.FaceFeatureCompare;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    partial class TesoLFCDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesoLFCDoc));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picBmp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picGray = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGray)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Location = new System.Drawing.Point(12, 44);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(640, 480);
            this.panelContainer.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(496, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Init";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(577, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Release";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picBmp
            // 
            this.picBmp.Location = new System.Drawing.Point(658, 68);
            this.picBmp.Name = "picBmp";
            this.picBmp.Size = new System.Drawing.Size(205, 144);
            this.picBmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBmp.TabIndex = 2;
            this.picBmp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "24bit BMP Image";
            // 
            // picGray
            // 
            this.picGray.Location = new System.Drawing.Point(660, 250);
            this.picGray.Name = "picGray";
            this.picGray.Size = new System.Drawing.Size(205, 144);
            this.picGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGray.TabIndex = 2;
            this.picGray.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(660, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "2bit BMP Image";
            // 
            // btnAutoTest
            // 
            this.btnAutoTest.Location = new System.Drawing.Point(12, 12);
            this.btnAutoTest.Name = "btnAutoTest";
            this.btnAutoTest.Size = new System.Drawing.Size(75, 23);
            this.btnAutoTest.TabIndex = 1;
            this.btnAutoTest.Text = "AuoTest";
            this.btnAutoTest.UseVisualStyleBackColor = true;
            this.btnAutoTest.Click += new System.EventHandler(this.btnAutoTest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Test Count:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(160, 17);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 12);
            this.lblCount.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fail Count:";
            // 
            // lblFail
            // 
            this.lblFail.AutoSize = true;
            this.lblFail.Location = new System.Drawing.Point(298, 17);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(0, 12);
            this.lblFail.TabIndex = 4;
            // 
            // TesoLFCDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 545);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblFail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGray);
            this.Controls.Add(this.picBmp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAutoTest);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.panelContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TesoLFCDoc";
            this.Text = "TesoLFCDoc";
            ((System.ComponentModel.ISupportInitialize)(this.picBmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGray)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox picBmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picGray;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAutoTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFail;
    }
}