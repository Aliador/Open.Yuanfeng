using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yuanfeng.Controls.Palette
{
    public partial class HSLPalette : Form
    {
        public HSLPalette()
        {
            InitializeComponent();
        }

        private Color pickColor = Color.Blue;
        public Color PickColor { get { return pickColor; } }
        private void paletteControl1_ColorChanged(object sender, Color e)
        {
            pickColor = e;
        }
    }
}
