﻿using Yuanfeng.WinFormsUI.Docking;

namespace Yuanfeng.WinFormsUI.Docking.ThemeVS2012
{
    internal class VS2012DockWindowFactory : DockPanelExtender.IDockWindowFactory
    {
        public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
        {
            return new VS2012DockWindow(dockPanel, dockState);
        }
    }
}
