using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTest3
{
    class Square
    {
        public static void HVuong(Point a, Point b,Graphics grfx, doitoado s)
        {  
            Point c = new Point();
            Point d = new Point();
            c.X = b.X;
            c.Y = a.Y;
            d.X = a.X;
            d.Y = b.Y;
            Line.DDA_Line(a, c, Color.Red, grfx,s);
            Line.DDA_Line(d, b, Color.Red, grfx,s);
            Line.DDA_Line(a, d, Color.Red, grfx,s);
            Line.DDA_Line(c, b, Color.Red, grfx,s);
        }
        public static void HVuong(Point a, int length, Graphics grfx,doitoado s)
        {
            Point b = new Point();
            Point c = new Point();
            Point d = new Point();
            b.Y = a.Y - length;
            b.X = a.X;
            c.X = a.X + length;
            c.Y = b.Y;
            d.X = c.X;
            d.Y = a.Y;


            Line.DDA_Line(a, b, Color.LightGreen, grfx, s);
            Line.DDA_Line(b, c, Color.LightGreen, grfx, s);
            Line.DDA_Line(c, d, Color.LightGreen, grfx, s);
            Line.DDA_Line(d, a, Color.LightGreen, grfx, s);
        }
    }
}
