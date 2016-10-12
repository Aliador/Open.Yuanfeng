using System;
using System.Drawing;
using System.Windows.Forms;

namespace Yuanfeng.WinFormsUI.Docking
{
    public interface IDockContent
    {
        DockContentHandler DockHandler	{	get;	}
        void OnActivated(EventArgs e);
        void OnDeactivate(EventArgs e);
    }

    public interface INestedPanesContainer
    {
        DockState DockState	{	get;	}
        Rectangle DisplayingRectangle	{	get;	}
        NestedPaneCollection NestedPanes	{	get;	}
        VisibleNestedPaneCollection VisibleNestedPanes	{	get;	}
        bool IsFloat	{	get;	}
    }

    public interface IDragSource
    {
        Control DragControl { get; }
    }

    internal interface IDockDragSource : IDragSource
    {
        Rectangle BeginDrag(Point ptMouse);
        void EndDrag();
        bool IsDockStateValid(DockState dockState);
        bool CanDockTo(DockPane pane);
        void FloatAt(Rectangle floatWindowBounds);
        void DockTo(DockPane pane, DockStyle dockStyle, int contentIndex);
        void DockTo(DockPanel panel, DockStyle dockStyle);
    }

    public interface ISplitterDragSource : IDragSource
    {
        void BeginDrag(Rectangle rectSplitter);
        void EndDrag();
        bool IsVertical { get; }
        Rectangle DragLimitBounds { get; }
        void MoveSplitter(int offset);
    }
}
