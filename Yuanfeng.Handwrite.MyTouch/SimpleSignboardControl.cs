using System.Drawing;
using System.Windows.Forms;
using Yuanfeng.Smarty;

namespace Yuanfeng.Handwrite.MyTouch
{
    public partial class SimpleSignboardControl : UserControl
    {
        public SimpleSignboardControl()
        {
            InitializeComponent();
        }
        public void Init()
        {
            this.axActiveHandWrite1.InitHandWrite((int)this.pbSignboard.Handle);
            this.axActiveHandWrite1.MutilWord = false;
            this.axActiveHandWrite1.PenWidth = 200;
            this.axActiveHandWrite1.PenColor = Color.Black;
        }
        public void Clear()
        {
            this.axActiveHandWrite1.ClearInk();
        }
        public Image GetSignImage()
        {
            Image tmpBg = this.BackgroundImage;
            this.BackgroundImage = null;
            this.Refresh();
            this.Invalidate();
            System.Threading.Thread.Sleep(100);
            this.Refresh();
            this.Invalidate();
            var point = this.PointToScreen(this.pbSignboard.Location);
            Bitmap image = new Bitmap(this.pbSignboard.Size.Width, this.pbSignboard.Height);
            Bitmap source = WinapiUtil.GetDesktopImage();
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(source, new Rectangle(new Point(0, 0), pbSignboard.Size), new Rectangle(point, this.pbSignboard.Size), GraphicsUnit.Pixel);
            g.Dispose();
            this.BackgroundImage = tmpBg;
            return image;
        }
    }
}
