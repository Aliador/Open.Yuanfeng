namespace Open.Yuanfeng.Windows.ImageUtil
{
    partial class FindGrayImageDoc
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
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.SourceImgFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrayImgList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ImgDisplayer = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(513, 36);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "Open";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // SourceImgFolder
            // 
            this.SourceImgFolder.Location = new System.Drawing.Point(129, 37);
            this.SourceImgFolder.Name = "SourceImgFolder";
            this.SourceImgFolder.Size = new System.Drawing.Size(378, 21);
            this.SourceImgFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source Img Folder";
            // 
            // GrayImgList
            // 
            this.GrayImgList.FormattingEnabled = true;
            this.GrayImgList.ItemHeight = 12;
            this.GrayImgList.Location = new System.Drawing.Point(129, 85);
            this.GrayImgList.Name = "GrayImgList";
            this.GrayImgList.Size = new System.Drawing.Size(459, 292);
            this.GrayImgList.TabIndex = 3;
            this.GrayImgList.SelectedValueChanged += new System.EventHandler(this.GrayImgList_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gray Img List";
            // 
            // ImgDisplayer
            // 
            this.ImgDisplayer.Location = new System.Drawing.Point(596, 109);
            this.ImgDisplayer.Name = "ImgDisplayer";
            this.ImgDisplayer.Size = new System.Drawing.Size(114, 139);
            this.ImgDisplayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgDisplayer.TabIndex = 4;
            this.ImgDisplayer.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Match Image Display";
            // 
            // FindGrayImageDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 430);
            this.Controls.Add(this.ImgDisplayer);
            this.Controls.Add(this.GrayImgList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceImgFolder);
            this.Controls.Add(this.btnOpenFolder);
            this.Name = "FindGrayImageDoc";
            this.Text = "FindGrayImageDoc";
            ((System.ComponentModel.ISupportInitialize)(this.ImgDisplayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox SourceImgFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox GrayImgList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.PictureBox ImgDisplayer;
        private System.Windows.Forms.Label label3;
    }
}