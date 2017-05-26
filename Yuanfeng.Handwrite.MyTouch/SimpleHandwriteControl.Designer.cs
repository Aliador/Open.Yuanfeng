using AxMyTouchHandwriteActiveX;

namespace Yuanfeng.Handwrite.MyTouch
{
    partial class SimpleHandwriteControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleHandwriteControl));
            this.panelWords = new System.Windows.Forms.Panel();
            this.pbClear = new System.Windows.Forms.PictureBox();
            this.pbHandwrite = new System.Windows.Forms.PictureBox();
            this.axActiveHandWrite1 = new AxMyTouchHandwriteActiveX.AxHandwrite();
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHandwrite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHandWrite1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWords
            // 
            this.panelWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWords.BackColor = System.Drawing.Color.Transparent;
            this.panelWords.Location = new System.Drawing.Point(0, 0);
            this.panelWords.Name = "panelWords";
            this.panelWords.Size = new System.Drawing.Size(525, 49);
            this.panelWords.TabIndex = 1;
            // 
            // pbClear
            // 
            this.pbClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClear.BackColor = System.Drawing.Color.Transparent;
            this.pbClear.Location = new System.Drawing.Point(522, 0);
            this.pbClear.Name = "pbClear";
            this.pbClear.Size = new System.Drawing.Size(88, 49);
            this.pbClear.TabIndex = 2;
            this.pbClear.TabStop = false;
            this.pbClear.Click += new System.EventHandler(this.pbClear_Click);
            // 
            // pbHandwrite
            // 
            this.pbHandwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHandwrite.BackColor = System.Drawing.Color.Transparent;
            this.pbHandwrite.Location = new System.Drawing.Point(2, 61);
            this.pbHandwrite.Name = "pbHandwrite";
            this.pbHandwrite.Size = new System.Drawing.Size(606, 337);
            this.pbHandwrite.TabIndex = 3;
            this.pbHandwrite.TabStop = false;
            // 
            // axActiveHandWrite1
            // 
            this.axActiveHandWrite1.Enabled = true;
            this.axActiveHandWrite1.Location = new System.Drawing.Point(3, 59);
            this.axActiveHandWrite1.Name = "axActiveHandWrite1";
            this.axActiveHandWrite1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActiveHandWrite1.OcxState")));
            this.axActiveHandWrite1.Size = new System.Drawing.Size(604, 337);
            this.axActiveHandWrite1.TabIndex = 0;
            // 
            // SimpleHandwriteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Yuanfeng.Handwrite.MyTouch.Properties.Resources.SimpleHandwrite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pbHandwrite);
            this.Controls.Add(this.pbClear);
            this.Controls.Add(this.panelWords);
            this.Controls.Add(this.axActiveHandWrite1);
            this.DoubleBuffered = true;
            this.Name = "SimpleHandwriteControl";
            this.Size = new System.Drawing.Size(610, 398);
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHandwrite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHandWrite1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxHandwrite axActiveHandWrite1;
        private System.Windows.Forms.Panel panelWords;
        private System.Windows.Forms.PictureBox pbClear;
        private System.Windows.Forms.PictureBox pbHandwrite;
    }
}
