using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Controls.Simple
{
    public class OpaquePlayerController
    {
        private Control container;
        private string key = "D_LAY";
        private int timeout = 5;
        private System.Threading.Timer timer;
        private OpaqueLayer layer = new OpaqueLayer();
        private OpaquePlayerController()
        {
            layer.Name = key;
            layer.Dock = DockStyle.Fill;
            layer.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        private static OpaquePlayerController @this;
        public static OpaquePlayerController New()
        {
            if (@this == null) @this = new OpaquePlayerController(); return @this;
        }

        public void Show(Control container, int timeout = 5)
        {
            this.timeout = timeout; this.container = container;
            container.Controls.Add(layer); layer.BringToFront();
            timer = new System.Threading.Timer(new System.Threading.TimerCallback((object o) =>
            {
                lock (this.key)
                {
                    if (this.timeout < 0)
                    {
                        hideControl(container);
                    }
                    this.timeout -= 1;
                }
            }), null, 0, 1000);
        }

        private void hideControl(Control container)
        {
            this.container.Invoke(new Action(() => { container.Controls.RemoveByKey(key); })); timer.Dispose();
        }

        public void Hide()
        {
            hideControl(this.container);
        }
    }
}
