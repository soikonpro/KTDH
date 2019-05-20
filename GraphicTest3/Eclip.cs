using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTest3
{
    class Eclip
    {
        public static void Midpoint_elip(int cx, int cy, int a, int b,Graphics grfx, doitoado s)
        {
            int x, y;


            Color m = Color.Red;
            x = 0; y = b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            botro.Put4Pixel(x, y, cx, cy, m, grfx);

            while (Dx < Dy)
            {
                x++;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y--;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }
                botro.PutColor1(s.round(x), s.round(y), cx, cy, m);
                if (x % 5 == 0) botro.Put4Pixel(x, s.round(y), cx, cy, m, grfx);


            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y > 0)
            {
                y--;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x++;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }
                botro.PutColor1(s.round(x), s.round(y), cx, cy, m);
                if (x % 5 == 0) botro.Put4Pixel(x, s.round(y), cx, cy, m,grfx);

            }

        }
    }
}
