namespace Open.Yuanfeng.Windows.FileSection
{
    partial class TestDoc
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
            this.btnCompute = new System.Windows.Forms.Button();
            this.tbComputeBeginDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExpired = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(295, 24);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(75, 23);
            this.btnCompute.TabIndex = 0;
            this.btnCompute.Text = "计算";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // tbComputeBeginDate
            // 
            this.tbComputeBeginDate.Location = new System.Drawing.Point(131, 25);
            this.tbComputeBeginDate.Name = "tbComputeBeginDate";
            this.tbComputeBeginDate.Size = new System.Drawing.Size(158, 21);
            this.tbComputeBeginDate.TabIndex = 1;
            this.tbComputeBeginDate.Text = "20170221";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "总天数（含头尾）：";
            // 
            // btnExpired
            // 
            this.btnExpired.Location = new System.Drawing.Point(295, 53);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new System.Drawing.Size(75, 23);
            this.btnExpired.TabIndex = 0;
            this.btnExpired.Text = "过期时间";
            this.btnExpired.UseVisualStyleBackColor = true;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);
            // 
            // TestDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbComputeBeginDate);
            this.Controls.Add(this.btnExpired);
            this.Controls.Add(this.btnCompute);
            this.Name = "TestDoc";
            this.Text = "TestDoc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.TextBox tbComputeBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExpired;
    }
}