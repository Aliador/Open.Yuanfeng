using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Yuanfeng.ImageUnit.OCR;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows.ImageUtil
{
    public partial class SimpleOcrDoc : DockContent
    {
        public SimpleOcrDoc()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int testCount = (int)TestCount.Value;

            int index = 0;
            do
            {

                Bitmap bmp = Ocrx.TestCode();

                string filename = FileNameGenerator.Generator();
                string result = string.Empty;

                result = bmp.TryOcr();

                bmp.ToBuffer().Writer(filename);

                var item = new ListViewItem();
                item.Group = this.ResultListView.Groups["Default"];
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TypeHelper.ParseString(index) });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = filename });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = result });
                this.ResultListView.Items.Add(item);

                index += 1;
                testCount -= 1;
            } while (testCount >= 0);
        }

        private void ResultListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string filename = this.ResultListView.SelectedItems[0].SubItems[2].Text;
                this.VerfiCodeImage.Image = filename.Reader().ToBitmap();
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception);
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = folderBrowserDialog1.SelectedPath;
                this.tbDirPath.Text = dir;

                new System.Threading.Thread((object arg) =>
                {
                    string temp = arg.ToString();
                    if (Directory.Exists(temp))
                    {
                        string[] filenames = Directory.GetFiles(temp);

                        int index = 0;
                        foreach (var filename in filenames)
                        {
                            string result = filename.Reader().ToBitmap().TryOcr();
                            this.Invoke(new Action(() =>
                            {
                                var item = new ListViewItem();
                                item.Group = this.ResultListView.Groups["Default"];
                                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TypeHelper.ParseString(index) });
                                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = filename });
                                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = result });
                                this.ResultListView.Items.Add(item);
                            }));

                            index += 1;

                            GC.Collect();

                            if (index >= 100) break;
                        }
                    }
                }).Start(dir);
            }
        }
    }
}
