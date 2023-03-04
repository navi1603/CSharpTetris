using System;
using System.Collections.Generic;
using System.Text;

namespace Titris
{
    internal interface iDrawer
    {
        void DrawPoint(int x, int y);
        void HidePoint(int x, int y);
    }
}
