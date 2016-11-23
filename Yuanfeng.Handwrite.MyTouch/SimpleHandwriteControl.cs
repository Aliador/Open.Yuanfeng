using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Handwrite.MyTouch
{
    public partial class SimpleHandwriteControl : UserControl
    {
        public SimpleHandwriteControl()
        {
            InitializeComponent();
        }

        private void AxActiveHandWrite1_OnRecognizer(object sender, AxACTIVEHANDWRITELib._DActiveHandWriteEvents_OnRecognizerEvent e)
        {
            this.panelWords.Controls.Clear();
            string[] words = e.stringList.Replace("\r\n", "\r").Split(new char[] { '\r' });
            int count = 0;
            int n = 49;
            foreach (var word in words)
            {
                Word item = new Word();
                item.Location = new Point(n * count, 0);
                item.Size = new Size(52, n);
                item.AutoSize = false;
                item.BackColor = Color.Transparent;
                item.TextAlign = ContentAlignment.MiddleCenter;
                item.Text = word;
                item.Font = new Font("Microsoft YaHei", 16, FontStyle.Bold);
                item.Click += Item_Click;
                this.panelWords.Controls.Add(item);
                count += 1;
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            this.axActiveHandWrite1.ClearInk();
        }

        private void pbClear_Click(object sender, EventArgs e)
        {
            this.panelWords.Controls.Clear(); axActiveHandWrite1.ClearInk();
        }

        public void Init()
        {
            this.axActiveHandWrite1.InitHandWrite((int)this.pbHandwrite.Handle);
            this.axActiveHandWrite1.SetRecognizerCount(12);
        }
        public void Clear()
        {
            this.axActiveHandWrite1.ClearInk();
        }
    }
}
