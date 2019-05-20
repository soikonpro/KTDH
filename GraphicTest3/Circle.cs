using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTest3
{
    class Circle
    {
        
        public static void Midpoint_htron(int cx, int cy, int bkinh, Color m,Graphics grfx, doitoado s)
        {
            int x, y, p, R;
            x = 0;
            y = R = bkinh;
            int maxX = s.round((float)(Math.Sqrt(2) / 2 * R));
            // int maxX = Math.Sqrt(2) / 2 * R;
            p = 1 - R;
            botro.Put8Pixel(x, y, cx, cy, m,grfx);
            while (x <= maxX)
            {
                if (p < 0) p += 2 * x + 3;
                else { p += 2 * (x - y) + 5; y -= 5; }
                x += 5;
            botro.Put8Pixel(x, y, cx, cy, m,grfx);
            }

        }
    }
}
