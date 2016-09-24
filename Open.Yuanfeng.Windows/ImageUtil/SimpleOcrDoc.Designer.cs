namespace Open.Yuanfeng.Windows.ImageUtil
{
    partial class SimpleOcrDoc
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
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Default", System.Windows.Forms.HorizontalAlignment.Left);
            this.btnTest = new System.Windows.Forms.Button();
            this.TestCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.None = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Image = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VerfiCodeImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDirPath = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.TestCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerfiCodeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(373, 10);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Begin";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // TestCount
            // 
            this.TestCount.Location = new System.Drawing.Point(101, 11);
            this.TestCount.Name = "TestCount";
            this.TestCount.Size = new System.Drawing.Size(266, 21);
            this.TestCount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Test Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ocr Result List";
            // 
            // ResultListView
            // 
            this.ResultListView.CheckBoxes = true;
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.None,
            this.Index,
            this.Image,
            this.Result});
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.GridLines = true;
            listViewGroup2.Header = "Default";
            listViewGroup2.Name = "Default";
            this.ResultListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.ResultListView.Location = new System.Drawing.Point(101, 73);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(483, 267);
            this.ResultListView.TabIndex = 4;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
            this.ResultListView.SelectedIndexChanged += new System.EventHandler(this.ResultListView_SelectedIndexChanged);
            // 
            // None
            // 
            this.None.Text = "None";
            this.None.Width = 40;
            // 
            // Index
            // 
            this.Index.Text = "Index";
            // 
            // Image
            // 
            this.Image.Text = "CodeImagePath";
            this.Image.Width = 315;
            // 
            // Result
            // 
            this.Result.Text = "Result";
            // 
            // VerfiCodeImage
            // 
            this.VerfiCodeImage.Location = new System.Drawing.Point(590, 73);
            this.VerfiCodeImage.Name = "VerfiCodeImage";
            this.VerfiCodeImage.Size = new System.Drawing.Size(125, 59);
            this.VerfiCodeImage.TabIndex = 5;
            this.VerfiCodeImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Code Dir";
            // 
            // tbDirPath
            // 
            this.tbDirPath.Location = new System.Drawing.Point(101, 43);
            this.tbDirPath.Name = "tbDirPath";
            this.tbDirPath.Size = new System.Drawing.Size(266, 21);
            this.tbDirPath.TabIndex = 6;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(373, 42);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // SimpleOcrDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 421);
            this.Controls.Add(this.tbDirPath);
            this.Controls.Add(this.VerfiCodeImage);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TestCount);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnTest);
            this.Name = "SimpleOcrDoc";
            this.Text = "SimpleOcrDoc";
            ((System.ComponentModel.ISupportInitialize)(this.TestCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerfiCodeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.NumericUpDown TestCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.ColumnHeader Image;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.ColumnHeader None;
        private System.Windows.Forms.PictureBox VerfiCodeImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDirPath;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}