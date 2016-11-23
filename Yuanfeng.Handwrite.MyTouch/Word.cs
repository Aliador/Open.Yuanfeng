using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Handwrite.MyTouch
{
    public partial class Word : Label
    {
        public Word()
        {
            InitializeComponent();
        }

        public Word(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (!string.IsNullOrEmpty(this.Text)) SendKeys.Send(this.Text);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = System.Drawing.Color.Transparent;
            this.ForeColor = System.Drawing.Color.Black;
        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            this.BackColor = System.Drawing.Color.Orange;
            this.ForeColor = System.Drawing.Color.White;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.BackColor = System.Drawing.Color.Brown;
            this.ForeColor = System.Drawing.Color.White;
        }
    }
}
