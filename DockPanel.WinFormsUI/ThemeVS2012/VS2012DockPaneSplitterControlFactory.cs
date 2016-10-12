﻿using Yuanfeng.WinFormsUI.Docking;

namespace Yuanfeng.WinFormsUI.ThemeVS2012
{
    internal class VS2012DockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
    {
        public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new VS2012SplitterControl(pane);
        }
    }
}
