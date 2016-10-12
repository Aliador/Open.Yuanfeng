using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yuanfeng.Smarty
{
    public class WinapiUtil
    {
        public static Bitmap GetDesktopImage()
        {
            //保存截屏的尺寸
            SIZE size;
            //指向bitmap的句柄
            IntPtr hBitmap;
            //通过GetDC函数获得指向桌面设备上下文的句柄
            IntPtr hDC = Win32.GetDC(Win32.GetDesktopWindow());
            //在内存中创建一个兼容的设备上下文
            IntPtr hMemDC = Win32.CreateCompatibleDC(hDC);
            //传递一个常数到GetSystemMetrics，并返回屏幕的x坐标
            size.cx = Win32.GetSystemMetrics(0);
            //传递一个常数到GetSystemMetrics，并返回屏幕的y坐标
            size.cy = Win32.GetSystemMetrics(1);
            //创建与指定的设备环境相关的设备兼容的位图。
            hBitmap = Win32.CreateCompatibleBitmap(hDC, size.cx, size.cy);
            //As hBitmap is IntPtr we can not check it against null. For this purspose IntPtr.Zero is used.
            if (hBitmap != IntPtr.Zero)
            {
                //Here we select the compatible bitmap in memeory device context and keeps the refrence to Old bitmap.
                IntPtr hOld = (IntPtr)Win32.SelectObject(hMemDC, hBitmap);
                //We copy the Bitmap to the memory device context.
                Win32.BitBlt(hMemDC, 0, 0, size.cx, size.cy, hDC, 0, 0, Win32.SRCCOPY);
                //We select the old bitmap back to the memory device context.
                Win32.SelectObject(hMemDC, hOld);
                //We delete the memory device context.
                Win32.DeleteDC(hMemDC);
                //We release the screen device context.
                Win32.ReleaseDC(Win32.GetDesktopWindow(), hDC);
                //Image is created by Image bitmap handle and stored in local variable.
                Bitmap bmp = System.Drawing.Image.FromHbitmap(hBitmap);
                //Release the memory for compatible bitmap.
                Win32.DeleteObject(hBitmap);
                //This statement runs the garbage collector manually.
                GC.Collect();
                //Return the bitmap
                return bmp;
            }
            //If hBitmap is null retunrn null.
            return null;
        }
    }
}
