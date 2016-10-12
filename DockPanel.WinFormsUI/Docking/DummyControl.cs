using System;
using System.Windows.Forms;

namespace Yuanfeng.WinFormsUI.Docking
{
    internal class DummyControl : Control
    {
        public DummyControl()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
