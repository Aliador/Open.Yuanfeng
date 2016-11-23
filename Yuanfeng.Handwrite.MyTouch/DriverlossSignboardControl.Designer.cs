namespace Yuanfeng.Handwrite.MyTouch
{
    partial class DriverlossSignboardControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverlossSignboardControl));
            this.pbSignboard = new System.Windows.Forms.PictureBox();
            this.axActiveHandWrite1 = new AxACTIVEHANDWRITELib.AxActiveHandWrite();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHandWrite1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSignboard
            // 
            this.pbSignboard.BackColor = System.Drawing.Color.Transparent;
            this.pbSignboard.Location = new System.Drawing.Point(0, 0);
            this.pbSignboard.Name = "pbSignboard";
            this.pbSignboard.Size = new System.Drawing.Size(804, 313);
            this.pbSignboard.TabIndex = 0;
            this.pbSignboard.TabStop = false;
            // 
            // axActiveHandWrite1
            // 
            this.axActiveHandWrite1.Enabled = true;
            this.axActiveHandWrite1.Location = new System.Drawing.Point(0, 0);
            this.axActiveHandWrite1.Name = "axActiveHandWrite1";
            this.axActiveHandWrite1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActiveHandWrite1.OcxState")));
            this.axActiveHandWrite1.Size = new System.Drawing.Size(804, 313);
            this.axActiveHandWrite1.TabIndex = 2;
            // 
            // SimpleSignboardControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yuanfeng.Handwrite.MyTouch.Properties.Resources.SimpleSignboard2;
            this.Controls.Add(this.axActiveHandWrite1);
            this.Controls.Add(this.pbSignboard);
            this.Name = "SimpleSignboardControl2";
            this.Size = new System.Drawing.Size(804, 313);
            ((System.ComponentModel.ISupportInitialize)(this.pbSignboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHandWrite1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSignboard;
        private AxACTIVEHANDWRITELib.AxActiveHandWrite axActiveHandWrite1;
    }
}
