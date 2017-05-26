namespace Yuanfeng.Controls.Palette
{
    partial class PaletteControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPickColor = new System.Windows.Forms.PictureBox();
            this.btnCopy2Html = new System.Windows.Forms.Button();
            this.tnCopy2Argb = new System.Windows.Forms.Button();
            this.lblArgb = new System.Windows.Forms.Label();
            this.m_colorBar = new Palette.HSLColorBar();
            this.m_colorWheel = new Palette.ColorSetWheel();
            this.lblHtml = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPickColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPickColor
            // 
            this.pbPickColor.Location = new System.Drawing.Point(15, 211);
            this.pbPickColor.Name = "pbPickColor";
            this.pbPickColor.Size = new System.Drawing.Size(37, 41);
            this.pbPickColor.TabIndex = 2;
            this.pbPickColor.TabStop = false;
            // 
            // btnCopy2Html
            // 
            this.btnCopy2Html.Font = new System.Drawing.Font("SimSun", 9F);
            this.btnCopy2Html.Location = new System.Drawing.Point(135, 209);
            this.btnCopy2Html.Name = "btnCopy2Html";
            this.btnCopy2Html.Size = new System.Drawing.Size(51, 23);
            this.btnCopy2Html.TabIndex = 3;
            this.btnCopy2Html.Text = "Html";
            this.btnCopy2Html.UseVisualStyleBackColor = true;
            this.btnCopy2Html.Click += new System.EventHandler(this.btnCopy2Html_Click);
            // 
            // tnCopy2Argb
            // 
            this.tnCopy2Argb.Font = new System.Drawing.Font("SimSun", 9F);
            this.tnCopy2Argb.Location = new System.Drawing.Point(135, 232);
            this.tnCopy2Argb.Name = "tnCopy2Argb";
            this.tnCopy2Argb.Size = new System.Drawing.Size(51, 23);
            this.tnCopy2Argb.TabIndex = 3;
            this.tnCopy2Argb.Text = "Argb";
            this.tnCopy2Argb.UseVisualStyleBackColor = true;
            this.tnCopy2Argb.Click += new System.EventHandler(this.tnCopy2Argb_Click);
            // 
            // lblArgb
            // 
            this.lblArgb.AutoSize = true;
            this.lblArgb.Location = new System.Drawing.Point(58, 237);
            this.lblArgb.Name = "lblArgb";
            this.lblArgb.Size = new System.Drawing.Size(71, 12);
            this.lblArgb.TabIndex = 4;
            this.lblArgb.Text = "lblColorStr";
            // 
            // m_colorBar
            // 
            this.m_colorBar.BackColor = System.Drawing.SystemColors.Control;
            this.m_colorBar.Color1 = System.Drawing.Color.Black;
            this.m_colorBar.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.m_colorBar.Color3 = System.Drawing.Color.White;
            this.m_colorBar.ColorSelectorSize = new System.Drawing.Size(20, 20);
            this.m_colorBar.LightnessWidth = 20;
            this.m_colorBar.Location = new System.Drawing.Point(0, 0);
            this.m_colorBar.Name = "m_colorBar";
            this.m_colorBar.NumberOfColors = Palette.ColorBar.eNumberOfColors.Use3Colors;
            this.m_colorBar.Percent = 0D;
            this.m_colorBar.Size = new System.Drawing.Size(200, 200);
            this.m_colorBar.TabIndex = 1;
            this.m_colorBar.Text = "colorBar1";
            // 
            // m_colorWheel
            // 
            this.m_colorWheel.Location = new System.Drawing.Point(25, 25);
            this.m_colorWheel.Name = "m_colorWheel";
            this.m_colorWheel.Size = new System.Drawing.Size(150, 150);
            this.m_colorWheel.TabIndex = 0;
            this.m_colorWheel.Text = "colorSetWheel1";
            // 
            // lblHtml
            // 
            this.lblHtml.AutoSize = true;
            this.lblHtml.Location = new System.Drawing.Point(58, 214);
            this.lblHtml.Name = "lblHtml";
            this.lblHtml.Size = new System.Drawing.Size(71, 12);
            this.lblHtml.TabIndex = 4;
            this.lblHtml.Text = "lblColorStr";
            // 
            // PaletteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHtml);
            this.Controls.Add(this.lblArgb);
            this.Controls.Add(this.tnCopy2Argb);
            this.Controls.Add(this.btnCopy2Html);
            this.Controls.Add(this.pbPickColor);
            this.Controls.Add(this.m_colorBar);
            this.Controls.Add(this.m_colorWheel);
            this.Name = "PaletteControl";
            this.Size = new System.Drawing.Size(200, 263);
            this.Load += new System.EventHandler(this.PaletteControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPickColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorSetWheel m_colorWheel;
        private HSLColorBar m_colorBar;
        private System.Windows.Forms.PictureBox pbPickColor;
        private System.Windows.Forms.Button btnCopy2Html;
        private System.Windows.Forms.Button tnCopy2Argb;
        private System.Windows.Forms.Label lblArgb;
        private System.Windows.Forms.Label lblHtml;
    }
}
