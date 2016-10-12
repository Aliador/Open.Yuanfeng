﻿using System;

namespace Yuanfeng.WinFormsUI.Docking
{
    using System.ComponentModel;

    public partial class DockPanel
    {
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockPanelSkin")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DockPanelSkin Skin
        {
            get { return m_dockPanelTheme.Skin;  }
        }

        private ThemeBase m_dockPanelTheme = new VS2005Theme();
        [LocalizedCategory("Category_Docking")]
        [LocalizedDescription("DockPanel_DockPanelTheme")]
        public ThemeBase Theme
        {
            get { return m_dockPanelTheme; }
            set
            {
                if (value == null)
                {
                    return;
                }

                if (m_dockPanelTheme.GetType() == value.GetType())
                {
                    return;
                }

                m_dockPanelTheme?.CleanUp(this);
                m_dockPanelTheme = value;
                m_dockPanelTheme.Apply(this);
            }
        }
    }
}
