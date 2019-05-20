using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTest3
{
    class Triangle
    {
        public static void TamGiac(Point a, Point b, Point c, Graphics grfx, doitoado s)
        {

            Line.DDA_Line(a, b, Color.Black,grfx,s);
            Line.DDA_Line(a, c, Color.Black, grfx, s);
            Line.DDA_Line(c, b, Color.Black, grfx, s);
        }
        public static void TamGiac(Point a, Point b, Point c, Graphics grfx, doitoado s,Color m)
        {

            Line.DDA_Line(a, b, m, grfx, s);
            Line.DDA_Line(a, c, m, grfx, s);
            Line.DDA_Line(c, b, m, grfx, s);
        }
    }
}
