using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoWall
{
    class VideoWall
    {
        const int RowNum=3;
        const int ColNum = 3;
        private static List<WindowInfo> winColl;

        public static void Main()
        {
            Tray.OnReOrder += delegate
                                {
                                    ReorderWindows();
                                };
            Tray.OnDisReorder += delegate
                                     {
                                         DisorderWindows();
                                     };
            Tray.OnExit += delegate
                               {
                                   Application.Exit();
                               };
            Tray.Register();
            ReorderWindows();
            Application.Run();
        }

        public static void ReorderWindows()
        {
            int cellWidth = WindowInfo.GetScreenResolution().Right / ColNum;
            int cellHeight = WindowInfo.GetScreenResolution().Bottom / RowNum;

            winColl = WindowInfo.GetCollection();
            //coll.ForEach(s=>s.Minmize());
            //coll[3].SetSize(500, 500);

            int i = 0, j = 0;
            foreach (var windowInfo in winColl)
            {
                windowInfo.SetPos(i * cellWidth, j * cellHeight, cellWidth, cellHeight);
                if (++i >= ColNum)
                {
                    i = 0;
                    j++;
                }
            }
        }

        public static void DisorderWindows()
        {
            winColl.ForEach(s => s.Maximize());
        }
    }
}
