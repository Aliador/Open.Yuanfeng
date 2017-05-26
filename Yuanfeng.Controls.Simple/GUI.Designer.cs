namespace Yuanfeng.Controls.Simple
{
    partial class GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pPickColor = new System.Windows.Forms.Panel();
            this.btnCopyWeb = new System.Windows.Forms.Button();
            this.btnCopyRgb = new System.Windows.Forms.Button();
            this.btnPickDone = new System.Windows.Forms.Button();
            this.magnifyingGlass1 = new Yuanfeng.Controls.Simple.MagnifyingGlass();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(123, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 97);
            this.panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 114);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(156, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Show the current pixel";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(12, 135);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(216, 16);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Show the current cursor position";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pPickColor);
            this.groupBox1.Location = new System.Drawing.Point(12, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last selected color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 1;
            // 
            // pPickColor
            // 
            this.pPickColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pPickColor.Location = new System.Drawing.Point(111, 18);
            this.pPickColor.Name = "pPickColor";
            this.pPickColor.Size = new System.Drawing.Size(99, 36);
            this.pPickColor.TabIndex = 0;
            // 
            // btnCopyWeb
            // 
            this.btnCopyWeb.Location = new System.Drawing.Point(234, 139);
            this.btnCopyWeb.Name = "btnCopyWeb";
            this.btnCopyWeb.Size = new System.Drawing.Size(75, 23);
            this.btnCopyWeb.TabIndex = 5;
            this.btnCopyWeb.Text = "Copy Web";
            this.btnCopyWeb.UseVisualStyleBackColor = true;
            this.btnCopyWeb.Click += new System.EventHandler(this.btnCopyWeb_Click);
            // 
            // btnCopyRgb
            // 
            this.btnCopyRgb.Location = new System.Drawing.Point(234, 110);
            this.btnCopyRgb.Name = "btnCopyRgb";
            this.btnCopyRgb.Size = new System.Drawing.Size(75, 23);
            this.btnCopyRgb.TabIndex = 5;
            this.btnCopyRgb.Text = "Copy RGB";
            this.btnCopyRgb.UseVisualStyleBackColor = true;
            this.btnCopyRgb.Click += new System.EventHandler(this.btnCopyRgb_Click);
            // 
            // btnPickDone
            // 
            this.btnPickDone.Location = new System.Drawing.Point(234, 170);
            this.btnPickDone.Name = "btnPickDone";
            this.btnPickDone.Size = new System.Drawing.Size(75, 45);
            this.btnPickDone.TabIndex = 5;
            this.btnPickDone.Text = "OK";
            this.btnPickDone.UseVisualStyleBackColor = true;
            this.btnPickDone.Click += new System.EventHandler(this.btnPickDone_Click);
            // 
            // magnifyingGlass1
            // 
            this.magnifyingGlass1.BackColor = System.Drawing.Color.Black;
            this.magnifyingGlass1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.magnifyingGlass1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.magnifyingGlass1.ForeColor = System.Drawing.Color.White;
            this.magnifyingGlass1.Location = new System.Drawing.Point(12, 11);
            this.magnifyingGlass1.Name = "magnifyingGlass1";
            this.magnifyingGlass1.PixelRange = 10;
            this.magnifyingGlass1.PixelSize = 5;
            this.magnifyingGlass1.PosAlign = System.Drawing.ContentAlignment.TopLeft;
            this.magnifyingGlass1.PosFormat = "#x ; #y";
            this.magnifyingGlass1.ShowPixel = true;
            this.magnifyingGlass1.ShowPosition = true;
            this.magnifyingGlass1.Size = new System.Drawing.Size(105, 105);
            this.magnifyingGlass1.TabIndex = 0;
            this.magnifyingGlass1.UseMovingGlass = true;
            this.magnifyingGlass1.DisplayUpdated += new Yuanfeng.Controls.Simple.MagnifyingGlass.DisplayUpdatedDelegate(this.magnifyingGlass1_DisplayUpdated);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 234);
            this.Controls.Add(this.btnPickDone);
            this.Controls.Add(this.btnCopyRgb);
            this.Controls.Add(this.btnCopyWeb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.magnifyingGlass1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "GUI";
            this.ShowIcon = false;
            this.Text = "Desktop Color Picker";
            this.Deactivate += new System.EventHandler(this.GUI_Deactivate);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MagnifyingGlass magnifyingGlass1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pPickColor;
        private System.Windows.Forms.Button btnCopyWeb;
        private System.Windows.Forms.Button btnCopyRgb;
        private System.Windows.Forms.Button btnPickDone;
    }
}

