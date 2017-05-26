using Yuanfeng.WinFormsUI.Docking;

namespace Yuanfeng.WinFormsUI.Docking.ThemeVS2012
{
    internal class VS2012AutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
    {
        public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
        {
            return new VS2012AutoHideWindowControl(panel);
        }
    }
}
