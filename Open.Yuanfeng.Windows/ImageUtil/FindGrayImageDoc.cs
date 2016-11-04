using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.WinFormsUI.Docking;
using Yuanfeng.Unit.Gray;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class FindGrayImageDoc : DockContent
    {
        public FindGrayImageDoc()
        {
            InitializeComponent();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folder = folderBrowserDialog.SelectedPath;

                if (!System.IO.Directory.Exists(folder)) { SimpleConsole.WriteLine("Select folder is not exists."); return; }

                this.SourceImgFolder.Text = folder;

                string[] filenames = System.IO.Directory.GetFiles(folder);

                if(filenames.Length==0) { SimpleConsole.WriteLine("Select folder is empty."); return; }

                this.btnOpenFolder.Enabled = false;

                System.Threading.Thread thradFindGrayImg = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart((object o) =>
                {
                    string[] items = o as string[];

                    foreach (string item in items)
                    {
                        try
                        {
                            bool isGray = GrayImage.IsGray(item.Reader());
                            if (isGray) this.Invoke(new Action(() => { this.GrayImgList.Items.Add(item); }));
                        }
                        catch (Exception exception)
                        {
                            SimpleConsole.WriteLine(exception);
                        }
                    }

                    this.Invoke(new Action(() => { this.btnOpenFolder.Enabled = true; SimpleConsole.WriteLine("Find over."); }));
                }));

                thradFindGrayImg.Start(filenames);
            }
        }

        private void GrayImgList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ImgDisplayer.Image = this.GrayImgList.SelectedItem.ToString().Reader().ToBitmap();
        }
    }
}
