using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTest3
{
    class Parallelogram
    {
        public static void HinhBinhHanh(Point a, Point b, Point c, Point d, Graphics grfx, doitoado s)
        {
            if ((a.X == 715 && a.Y == 390) || (b.X == 715 && b.Y == 390)) Line.DDA_Line_Muted(a, b, Color.Red, grfx, s);
            else
                Line.DDA_Line(a, b, Color.Red, grfx, s);
            if ((b.X == 715 && b.Y == 390) || (c.X == 715 && c.Y == 390)) Line.DDA_Line_Muted(b, c, Color.Red, grfx, s);
            else
                Line.DDA_Line(b, c, Color.Red, grfx, s);
            if ((d.X == 715 && d.Y == 390) || (c.X == 715 && c.Y == 390)) Line.DDA_Line_Muted(c, d, Color.Red, grfx, s);
            else
                Line.DDA_Line(c, d, Color.Red, grfx, s);
            if ((d.X == 715 && d.Y == 390) || (a.X == 715 && a.Y == 390)) Line.DDA_Line_Muted(d, a, Color.Red, grfx, s);
            else
                Line.DDA_Line(d, a, Color.Red, grfx, s);
        }
    }
}
