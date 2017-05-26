namespace Yuanfeng.Controls.Palette
{
    partial class HSLPalette
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
            this.paletteControl1 = new Yuanfeng.Controls.Palette.PaletteControl();
            this.SuspendLayout();
            // 
            // paletteControl1
            // 
            this.paletteControl1.Location = new System.Drawing.Point(0, 0);
            this.paletteControl1.Name = "paletteControl1";
            this.paletteControl1.Size = new System.Drawing.Size(200, 263);
            this.paletteControl1.TabIndex = 0;
            this.paletteControl1.ColorChanged += new Yuanfeng.Controls.Palette.ColorChangedHandle(this.paletteControl1_ColorChanged);
            // 
            // HSLPalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 269);
            this.Controls.Add(this.paletteControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HSLPalette";
            this.Text = "HSLPalette";
            this.ResumeLayout(false);

        }

        #endregion

        private PaletteControl paletteControl1;
    }
}