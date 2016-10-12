namespace Open.Yuanfeng.Windows.HttpX
{
    partial class DynamicHttpRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicHttpRequest));
            this.btnInvoke = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbArgs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMethod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnInvoke
            // 
            this.btnInvoke.Location = new System.Drawing.Point(528, 34);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(75, 48);
            this.btnInvoke.TabIndex = 0;
            this.btnInvoke.Text = "Invoke";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request Url";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(92, 34);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(430, 21);
            this.tbUrl.TabIndex = 2;
            this.tbUrl.Text = "http://www.webservicex.net/globalweather.asmx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Args";
            // 
            // tbArgs
            // 
            this.tbArgs.Location = new System.Drawing.Point(92, 88);
            this.tbArgs.Name = "tbArgs";
            this.tbArgs.Size = new System.Drawing.Size(430, 21);
            this.tbArgs.TabIndex = 2;
            this.tbArgs.Text = "Shenzhen,China";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Response";
            // 
            // tbResponse
            // 
            this.tbResponse.Location = new System.Drawing.Point(92, 127);
            this.tbResponse.Multiline = true;
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Size = new System.Drawing.Size(430, 194);
            this.tbResponse.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Method";
            // 
            // tbMethod
            // 
            this.tbMethod.Location = new System.Drawing.Point(92, 61);
            this.tbMethod.Name = "tbMethod";
            this.tbMethod.Size = new System.Drawing.Size(430, 21);
            this.tbMethod.TabIndex = 2;
            this.tbMethod.Text = "GetWeather";
            // 
            // DynamicHttpRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 434);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbArgs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInvoke);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DynamicHttpRequest";
            this.Text = "DynamicHttpRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvoke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbArgs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMethod;
    }
}