namespace Open.Yuanfeng.Windows.ImageUtil
{
    partial class SimpleQrCodeDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleQrCodeDoc));
            this.label1 = new System.Windows.Forms.Label();
            this.QrCodeString = new System.Windows.Forms.TextBox();
            this.QrCodeImage = new System.Windows.Forms.PictureBox();
            this.btnGenerator = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.QrCodeSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.QrCodeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QrCodeSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "QrCodeString:";
            // 
            // QrCodeString
            // 
            this.QrCodeString.Location = new System.Drawing.Point(101, 35);
            this.QrCodeString.Multiline = true;
            this.QrCodeString.Name = "QrCodeString";
            this.QrCodeString.Size = new System.Drawing.Size(502, 79);
            this.QrCodeString.TabIndex = 1;
            // 
            // QrCodeImage
            // 
            this.QrCodeImage.Location = new System.Drawing.Point(101, 156);
            this.QrCodeImage.Name = "QrCodeImage";
            this.QrCodeImage.Size = new System.Drawing.Size(230, 230);
            this.QrCodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QrCodeImage.TabIndex = 2;
            this.QrCodeImage.TabStop = false;
            // 
            // btnGenerator
            // 
            this.btnGenerator.Location = new System.Drawing.Point(528, 122);
            this.btnGenerator.Name = "btnGenerator";
            this.btnGenerator.Size = new System.Drawing.Size(75, 23);
            this.btnGenerator.TabIndex = 3;
            this.btnGenerator.Text = "Generator";
            this.btnGenerator.UseVisualStyleBackColor = true;
            this.btnGenerator.Click += new System.EventHandler(this.btnGenerator_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "QrCodeString:";
            // 
            // QrCodeSize
            // 
            this.QrCodeSize.Location = new System.Drawing.Point(101, 123);
            this.QrCodeSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.QrCodeSize.Name = "QrCodeSize";
            this.QrCodeSize.Size = new System.Drawing.Size(421, 21);
            this.QrCodeSize.TabIndex = 4;
            this.QrCodeSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // SimpleQrCodeDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 398);
            this.Controls.Add(this.QrCodeSize);
            this.Controls.Add(this.btnGenerator);
            this.Controls.Add(this.QrCodeImage);
            this.Controls.Add(this.QrCodeString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimpleQrCodeDoc";
            this.Text = "SimpleQrCode";
            ((System.ComponentModel.ISupportInitialize)(this.QrCodeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QrCodeSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox QrCodeString;
        private System.Windows.Forms.PictureBox QrCodeImage;
        private System.Windows.Forms.Button btnGenerator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown QrCodeSize;
    }
}