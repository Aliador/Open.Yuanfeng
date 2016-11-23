namespace Yuanfeng.Handwrite.MyTouch
{
    partial class SimpleTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleTest));
            this.simpleHandwriteControl1 = new Yuanfeng.Handwrite.MyTouch.SimpleHandwriteControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // simpleHandwriteControl1
            // 
            this.simpleHandwriteControl1.BackColor = System.Drawing.Color.White;
            this.simpleHandwriteControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleHandwriteControl1.BackgroundImage")));
            this.simpleHandwriteControl1.Location = new System.Drawing.Point(31, 12);
            this.simpleHandwriteControl1.Name = "simpleHandwriteControl1";
            this.simpleHandwriteControl1.Size = new System.Drawing.Size(610, 400);
            this.simpleHandwriteControl1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 418);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(610, 44);
            this.textBox1.TabIndex = 1;
            // 
            // SimpleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 507);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.simpleHandwriteControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimpleTest";
            this.Text = "易维输入法（简单版）";
            this.Load += new System.EventHandler(this.SimpleTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimpleHandwriteControl simpleHandwriteControl1;
        private System.Windows.Forms.TextBox textBox1;
    }
}