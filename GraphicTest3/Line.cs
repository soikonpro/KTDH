using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTest3
{
    class Line
    {
        public static void DDA_Line(Point a, Point b, Color m, Graphics grfx, doitoado s) // Ve duong thang co dinh dang mau
        {
           
            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = b.X - a.X;
            Dy = b.Y - a.Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;
            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = a.X;
                y = a.Y;
                do
                {
                    temp_1 = s.round(x);
                    temp_2 = s.round(y);
                    botro.PutPixel(temp_1, temp_2, m, grfx);
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                } while (count != -1);

            }
        }
        public static void DDA_Line_Muted(Point a, Point b, Color m, Graphics grfx, doitoado s) // Ve duong thang co dinh dang mau
        {

            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = b.X - a.X;
            Dy = b.Y - a.Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;

            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = a.X;
                y = a.Y;
                int dem1 = 0;
                temp_1 = s.round(x);
                temp_2 = s.round(y);
                botro.PutPixel(temp_1, temp_2, m,grfx);
                do
                {
                    temp_1 = s.round(x);
                    temp_2 = s.round(y);
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;

                    if (dem1 == 9) { botro.PutPixel(temp_1, temp_2, m,grfx); dem1 = 0; } else dem1++;
                } while (count != -1);

            }
        }
    }
}
