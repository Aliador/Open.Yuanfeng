using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yuanfeng.Smarty;

namespace Yuanfeng.Handwrite.MyTouch
{
    public partial class DriverlossSignboardControl : UserControl
    {
        public DriverlossSignboardControl()
        {
            InitializeComponent();
        }
        public void Init()
        {
            this.axActiveHandWrite1.InitHandWrite((int)this.pbSignboard.Handle);
        }
        public void Clear()
        {
            this.axActiveHandWrite1.ClearInk();
        }
        public Image GetSignImage()
        {
            var point = this.PointToScreen(this.pbSignboard.Location);
            Bitmap image = new Bitmap(this.pbSignboard.Size.Width, this.pbSignboard.Height);
            Bitmap source = WinapiUtil.GetDesktopImage();
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(source, new Rectangle(new Point(0, 0), pbSignboard.Size), new Rectangle(point, this.pbSignboard.Size), GraphicsUnit.Pixel);
            g.Dispose();
            return image;
        }
    }
}
