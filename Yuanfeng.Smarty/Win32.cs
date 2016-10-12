using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Yuanfeng.Smarty
{
    public class Win32
    {
        public const int MOUSEEVENT_LEFTDOWN = 0x0002;
        public const int MOUSEEVENT_LEFTUP = 0x0004;
        public const int MOUSEEVENT_ABSOLUTE = 0x8000;
        public const int MOUSEECENT_MOVE = 0x0001;

        public const Int32 AW_HOR_POSITIVE = 0X00000001;
        public const Int32 AW_HOR_NEGATIVE = 0X00000002;
        public const Int32 AW_VER_POSITIVE = 0X00000004;
        public const Int32 AW_VER_NEGATIVE = 0X00000008;
        public const Int32 AW_CENTER = 0X00000010;
        public const Int32 AW_HIDE = 0X00010000;
        public const Int32 AW_ACTIVATE = 0X00020000;
        public const Int32 AW_SLIDE = 0X00040000;
        public const Int32 AW_BLEND = 0X00080000;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool AnimateWindow(int hwnd, int dwTime, int dwFlags);

        public const uint WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 61456;
        public const int HTCATION = 2;

        /// <summary>
        /// 隐藏鼠标-API
        /// </summary>
        /// <param name="bShow">是否显示鼠标</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ShowCursor(bool bShow);

        /// <summary>
        /// 设置光标的坐标-API
        /// </summary>
        /// <param name="x">x轴</param>
        /// <param name="y">y轴</param>
        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);

        /// <summary>
        /// 鼠标点击-API
        /// </summary>
        /// <param name="mouseEvent">鼠标消息</param>
        /// <param name="dx">0</param>
        /// <param name="dy">0</param>
        /// <param name="dwData">0</param>
        /// <param name="dwExtraInfo">0</param>
        [DllImport("User32")]
        public extern static void mouse_event(int mouseEvent, int dx, int dy, int dwData, int dwExtraInfo);

        /// <summary>
        /// 查找窗体-API
        /// </summary>
        /// <param name="parent">父窗体,0x0为桌面</param>
        /// <param name="childe">前一个兄弟窗体</param>
        /// <param name="strclass">窗体类名</param>
        /// <param name="FrmText">窗体标题</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int FindWindowEx(int parent, int childe, string strclass, string FrmText);

        /// <summary>
        /// 发送信息-等待响应-API
        /// </summary>
        /// <param name="hwad">窗体句柄</param>
        /// <param name="Msg">信息</param>
        /// <param name="wParam">参数</param>
        /// <param name="lParam">内容</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int SendMessage(int hwad, int Msg, int wParam, string lParam);

        /// <summary>
        /// 发送消息-直接返回-API
        /// </summary>
        /// <param name="hwad">窗体句柄</param>
        /// <param name="Msg">信息</param>
        /// <param name="wParam">参数</param>
        /// <param name="lParam">内容</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int PostMessage(int hwad, int Msg, int wParam, int lParam);

        /// <summary>
        /// 遍历窗体委托
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="lParam">参数</param>
        /// <returns>是否停止遍历</returns>
        public delegate bool EnumWindowsProc(int hwnd, int lParam);

        /// <summary>
        /// 遍历子窗体-API
        /// </summary>
        /// <param name="parent">父窗体</param>
        /// <param name="lpEnumFunc">遍历窗体委托</param>
        /// <param name="lParam">参数</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int EnumChildWindows(int parent, EnumWindowsProc lpEnumFunc, int lParam);

        /// <summary>
        /// 遍历指定线程的窗体-API
        /// </summary>
        /// <param name="theadId">线程ID</param>
        /// <param name="lpEnumFunc">遍历窗体委托</param>
        /// <param name="lParam">参数</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern long EnumThreadWindows(int theadId, EnumWindowsProc lpEnumFunc, int lParam);

        /// <summary>
        /// 根据句柄获取类名-API
        /// </summary>
        /// <param name="hwnd">句柄</param>
        /// <param name="sb">接收类名的字符串</param>
        /// <param name="stringLength">字符串长度</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int GetClassName(int hwnd, StringBuilder sb, int stringLength);

        /// <summary>
        /// 设置父窗体-API
        /// </summary>
        /// <param name="hChild">子窗体</param>
        /// <param name="hParent">父窗体</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int SetParent(int hChild, int hParent);

        /// <summary>
        /// 显示隐藏窗体-API
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="nCmdShow">样式</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        /// <summary>
        /// 设置默认打印机-API
        /// </summary>
        /// <param name="name">打印机名称</param>
        /// <returns></returns>
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(string name);

        [DllImport("user32")]
        public static extern int SendMessage(int hwnd, uint msg, int wparam, int lparam);

        [DllImport("user32")]
        public static extern bool ReleaseCapture();

        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string value, string fileName);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string fileName);


        [DllImport("user32")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("kernel32")]
        public static extern uint SetThreadExecutionState(SleepFlags state);

        public static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();

            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!GetLastInputInfo(ref vLastInputInfo)) return 0;

            return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }

        public static void CancelSystemSleepTimer()
        {
            SetThreadExecutionState(SleepFlags.Display | SleepFlags.System | SleepFlags.Continue);
        }
        [Flags]
        public enum SleepFlags : uint
        {
            System = 0x000000001,
            Display = 0x00000000,
            Continue = 0x80000000
        }
        

        [DllImport("user32")]
        public static extern int keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


        /// <summary>
        /// 获取窗体句柄
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int FindWindow(string IpClassName, string IpWindowName);
        /// <summary>
        /// 窗体是否存在
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindow(int hwnd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hwad"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(int hwad);
        /// <summary>
        /// 改变指定窗体的位置和尺寸
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="x">左边界</param>
        /// <param name="y">顶部边界</param>
        /// <param name="nWidth">新宽度</param>
        /// <param name="nHeight">新高度</param>
        /// <param name="BRePaint">是否被刷新</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(int hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        [DllImport("kernel32.dll")]
        public static extern int SetProcessWorkingSetSize(int process, int min, int max);

        public const int SRCCOPY = 13369376;

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct LASTINPUTINFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwTime;
    }
    public struct SIZE
    {
        public int cx;
        public int cy;
    }
}
