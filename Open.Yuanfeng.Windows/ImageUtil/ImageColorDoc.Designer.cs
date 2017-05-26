namespace Open.Yuanfeng.Windows.ImageUtil
{
    partial class ImageColorDoc
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
            this.pbOldPic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectPic = new System.Windows.Forms.Button();
            this.pbNewPic = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.pbPickColor = new System.Windows.Forms.PictureBox();
            this.btnCalculateColorPorsent = new System.Windows.Forms.Button();
            this.btnClearColor = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnPalette = new System.Windows.Forms.Button();
            this.trackBarOffset = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPickColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOldPic
            // 
            this.pbOldPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOldPic.Location = new System.Drawing.Point(27, 24);
            this.pbOldPic.Name = "pbOldPic";
            this.pbOldPic.Size = new System.Drawing.Size(132, 152);
            this.pbOldPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOldPic.TabIndex = 0;
            this.pbOldPic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "原图片";
            // 
            // btnSelectPic
            // 
            this.btnSelectPic.Location = new System.Drawing.Point(56, 194);
            this.btnSelectPic.Name = "btnSelectPic";
            this.btnSelectPic.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPic.TabIndex = 2;
            this.btnSelectPic.Text = "选择";
            this.btnSelectPic.UseVisualStyleBackColor = true;
            this.btnSelectPic.Click += new System.EventHandler(this.btnSelectPic_Click);
            // 
            // pbNewPic
            // 
            this.pbNewPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNewPic.Location = new System.Drawing.Point(201, 24);
            this.pbNewPic.Name = "pbNewPic";
            this.pbNewPic.Size = new System.Drawing.Size(132, 152);
            this.pbNewPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNewPic.TabIndex = 0;
            this.pbNewPic.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "处理后图片";
            // 
            // btnPickColor
            // 
            this.btnPickColor.Location = new System.Drawing.Point(258, 194);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(75, 23);
            this.btnPickColor.TabIndex = 2;
            this.btnPickColor.Text = "取色器";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // pbPickColor
            // 
            this.pbPickColor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbPickColor.Location = new System.Drawing.Point(201, 194);
            this.pbPickColor.Name = "pbPickColor";
            this.pbPickColor.Size = new System.Drawing.Size(34, 25);
            this.pbPickColor.TabIndex = 3;
            this.pbPickColor.TabStop = false;
            // 
            // btnCalculateColorPorsent
            // 
            this.btnCalculateColorPorsent.Location = new System.Drawing.Point(27, 239);
            this.btnCalculateColorPorsent.Name = "btnCalculateColorPorsent";
            this.btnCalculateColorPorsent.Size = new System.Drawing.Size(75, 23);
            this.btnCalculateColorPorsent.TabIndex = 2;
            this.btnCalculateColorPorsent.Text = "计算颜色比例";
            this.btnCalculateColorPorsent.UseVisualStyleBackColor = true;
            // 
            // btnClearColor
            // 
            this.btnClearColor.Location = new System.Drawing.Point(27, 268);
            this.btnClearColor.Name = "btnClearColor";
            this.btnClearColor.Size = new System.Drawing.Size(75, 23);
            this.btnClearColor.TabIndex = 2;
            this.btnClearColor.Text = "清除颜色";
            this.btnClearColor.UseVisualStyleBackColor = true;
            this.btnClearColor.Click += new System.EventHandler(this.btnClearColor_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnPalette
            // 
            this.btnPalette.Location = new System.Drawing.Point(258, 223);
            this.btnPalette.Name = "btnPalette";
            this.btnPalette.Size = new System.Drawing.Size(75, 23);
            this.btnPalette.TabIndex = 2;
            this.btnPalette.Text = "调色板";
            this.btnPalette.UseVisualStyleBackColor = true;
            this.btnPalette.Click += new System.EventHandler(this.btnPalette_Click);
            // 
            // trackBarOffset
            // 
            this.trackBarOffset.LargeChange = 20;
            this.trackBarOffset.Location = new System.Drawing.Point(108, 268);
            this.trackBarOffset.Maximum = 255;
            this.trackBarOffset.Name = "trackBarOffset";
            this.trackBarOffset.Size = new System.Drawing.Size(467, 45);
            this.trackBarOffset.SmallChange = 5;
            this.trackBarOffset.TabIndex = 4;
            this.trackBarOffset.Value = 20;
            this.trackBarOffset.Scroll += new System.EventHandler(this.trackBarOffset_Scroll);
            // 
            // ImageColorDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 430);
            this.Controls.Add(this.trackBarOffset);
            this.Controls.Add(this.pbPickColor);
            this.Controls.Add(this.btnPalette);
            this.Controls.Add(this.btnPickColor);
            this.Controls.Add(this.btnClearColor);
            this.Controls.Add(this.btnCalculateColorPorsent);
            this.Controls.Add(this.btnSelectPic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbNewPic);
            this.Controls.Add(this.pbOldPic);
            this.Name = "ImageColorDoc";
            this.Text = "ImageColorDoc";
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPickColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOldPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectPic;
        private System.Windows.Forms.PictureBox pbNewPic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.PictureBox pbPickColor;
        private System.Windows.Forms.Button btnCalculateColorPorsent;
        private System.Windows.Forms.Button btnClearColor;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnPalette;
        private System.Windows.Forms.TrackBar trackBarOffset;
    }
}