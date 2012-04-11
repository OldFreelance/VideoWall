using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoWall
{
    class Tray
    {
        private static NotifyIcon _trayIcon;
        private static ContextMenu _trayMenu;

        public static EventHandler OnReOrder;
        public static EventHandler OnDisReorder;
        public static EventHandler OnExit;

        public static void Register()
        {
            // Create a simple tray menu with only one item.
            _trayMenu = new ContextMenu();
            _trayMenu.MenuItems.Add("Упорядочить", OnReOrder);
            _trayMenu.MenuItems.Add("Максимализировать", OnDisReorder);
            _trayMenu.MenuItems.Add("Выход", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            _trayIcon = new NotifyIcon();
            _trayIcon.Text = "VideoWall";
            _trayIcon.Icon = new Icon(SystemIcons.Shield, 40, 40);

            // Add menu to tray icon and show it.
            _trayIcon.ContextMenu = _trayMenu;
            _trayIcon.Visible = true;
        }

        //private static void OnExit(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}
