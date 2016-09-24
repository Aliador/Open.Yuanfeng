namespace Open.Yuanfeng.Windows
{
    partial class BugReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugReportForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRestart = new System.Windows.Forms.CheckBox();
            this.cbSendReport = new System.Windows.Forms.CheckBox();
            this.cbHelpus = new System.Windows.Forms.CheckBox();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDetail = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sorry ! This is a unkonw problem";
            // 
            // cbRestart
            // 
            this.cbRestart.AutoSize = true;
            this.cbRestart.Checked = true;
            this.cbRestart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRestart.Location = new System.Drawing.Point(41, 92);
            this.cbRestart.Name = "cbRestart";
            this.cbRestart.Size = new System.Drawing.Size(66, 16);
            this.cbRestart.TabIndex = 2;
            this.cbRestart.Text = "Restart";
            this.cbRestart.UseVisualStyleBackColor = true;
            // 
            // cbSendReport
            // 
            this.cbSendReport.AutoSize = true;
            this.cbSendReport.Checked = true;
            this.cbSendReport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendReport.Location = new System.Drawing.Point(41, 116);
            this.cbSendReport.Name = "cbSendReport";
            this.cbSendReport.Size = new System.Drawing.Size(90, 16);
            this.cbSendReport.TabIndex = 2;
            this.cbSendReport.Text = "Send Report";
            this.cbSendReport.UseVisualStyleBackColor = true;
            // 
            // cbHelpus
            // 
            this.cbHelpus.AutoSize = true;
            this.cbHelpus.Checked = true;
            this.cbHelpus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHelpus.Location = new System.Drawing.Point(41, 142);
            this.cbHelpus.Name = "cbHelpus";
            this.cbHelpus.Size = new System.Drawing.Size(174, 16);
            this.cbHelpus.TabIndex = 2;
            this.cbHelpus.Text = "Help us solve the problem";
            this.cbHelpus.UseVisualStyleBackColor = true;
            // 
            // tbReport
            // 
            this.tbReport.Location = new System.Drawing.Point(41, 190);
            this.tbReport.Multiline = true;
            this.tbReport.Name = "tbReport";
            this.tbReport.Size = new System.Drawing.Size(415, 97);
            this.tbReport.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "The problem detail reason:";
            // 
            // tbDetail
            // 
            this.tbDetail.Location = new System.Drawing.Point(41, 333);
            this.tbDetail.Multiline = true;
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.Size = new System.Drawing.Size(415, 97);
            this.tbDetail.TabIndex = 3;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(381, 299);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "OK";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(41, 299);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 4;
            this.btnDetail.Text = "Detail>>>";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // BugReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 327);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.tbDetail);
            this.Controls.Add(this.tbReport);
            this.Controls.Add(this.cbHelpus);
            this.Controls.Add(this.cbSendReport);
            this.Controls.Add(this.cbRestart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BugReportForm";
            this.Text = "BugReport";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbRestart;
        private System.Windows.Forms.CheckBox cbSendReport;
        private System.Windows.Forms.CheckBox cbHelpus;
        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDetail;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDetail;
    }
}