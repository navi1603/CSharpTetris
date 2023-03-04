using System;
using System.Collections.Generic;
using System.Text;

namespace Titris
{
    static class DrawerProvier
    {
        private static IIDrawer _drawer = new ConsoleDrawer();

        public static IIDrawer Drawer
        {
            get { return _drawer; }
            set
            {

            }
        }


    }
}
