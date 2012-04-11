using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoWall
{
    class WindowInfo
    {
        public static List<WindowInfo> GetCollection()
        {
            List<WindowInfo> coll = new List<WindowInfo>();
            WinAPI.EnumWindows((hWnd, lParam) =>
            {
                if (WinAPI.IsWindowVisible(hWnd) && WinAPI.GetWindowTextLength(hWnd) != 0)
                {
                    Rect rect;
                    WinAPI.GetWindowRect(hWnd, out rect);
                    coll.Add(new WindowInfo { Text = WinAPI.GetWindowText(hWnd), hWnd = hWnd, Rect = rect });
                }
                return true;
            }, IntPtr.Zero);
            return coll;
        }

        public static Rect GetScreenResolution()
        {
            Rect rect;
            WinAPI.GetWindowRect(WinAPI.GetDesktopWindow(), out rect);
            return rect;
        }

        public void Minmize()
        {
            WinAPI.SendMessage(hWnd, WinAPI.WM_SYSCOMMAND, WinAPI.SC_MINIMIZE, 0);
        }

        public void Maximize()
        {
            WinAPI.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, GetScreenResolution().Right, GetScreenResolution().Right, 0);
            WinAPI.SendMessage(hWnd, WinAPI.WM_SYSCOMMAND, WinAPI.SC_MAXIMIZE, 0);
        }

        public void SetPos(int x, int y, int width, int height)
        {
            WinAPI.SetWindowPos(hWnd, IntPtr.Zero, x, y, width, height, 0);
        }

        public void SetSize(int width, int height)
        {
            WinAPI.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, width, height, WinAPI.SWP_NOMOVE);
        }

        public void SetPos(int x, int y)
        {
            WinAPI.SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, WinAPI.SWP_NOSIZE);
        }

        public string Text;
        public IntPtr hWnd;
        public Rect Rect;
    }
}
