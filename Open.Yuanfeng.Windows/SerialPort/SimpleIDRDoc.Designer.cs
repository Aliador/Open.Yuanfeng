namespace Open.Yuanfeng.Windows.SerialPort
{
    partial class SimpleIDRDoc
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
            this.Channel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LiveTimeOut = new System.Windows.Forms.NumericUpDown();
            this.RicContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.Photo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Channel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiveTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).BeginInit();
            this.SuspendLayout();
            // 
            // Channel
            // 
            this.Channel.Location = new System.Drawing.Point(127, 40);
            this.Channel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Channel.Name = "Channel";
            this.Channel.Size = new System.Drawing.Size(77, 21);
            this.Channel.TabIndex = 0;
            this.Channel.Value = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device Selection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Live Scan Timeout";
            // 
            // LiveTimeOut
            // 
            this.LiveTimeOut.Location = new System.Drawing.Point(127, 67);
            this.LiveTimeOut.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.LiveTimeOut.Name = "LiveTimeOut";
            this.LiveTimeOut.Size = new System.Drawing.Size(78, 21);
            this.LiveTimeOut.TabIndex = 0;
            this.LiveTimeOut.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // RicContent
            // 
            this.RicContent.Location = new System.Drawing.Point(119, 96);
            this.RicContent.Multiline = true;
            this.RicContent.Name = "RicContent";
            this.RicContent.Size = new System.Drawing.Size(467, 333);
            this.RicContent.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ric Content";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(213, 39);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Begin";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(213, 66);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // Photo
            // 
            this.Photo.Location = new System.Drawing.Point(601, 96);
            this.Photo.Name = "Photo";
            this.Photo.Size = new System.Drawing.Size(106, 126);
            this.Photo.TabIndex = 4;
            this.Photo.TabStop = false;
            this.Photo.Click += new System.EventHandler(this.Photo_Click);
            // 
            // SimpleIDRDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 461);
            this.Controls.Add(this.Photo);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.RicContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LiveTimeOut);
            this.Controls.Add(this.Channel);
            this.Name = "SimpleIDRDoc";
            this.Text = "SimpleIDRDoc";
            ((System.ComponentModel.ISupportInitialize)(this.Channel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiveTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Channel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown LiveTimeOut;
        private System.Windows.Forms.TextBox RicContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.PictureBox Photo;
    }
}