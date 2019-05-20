using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTest3
{
    class botro
    {
        public static Color[,] arrcolor = new Color[1000,1000];// mang chua mau cua tat ca cac diem
        public static doitoado s = new doitoado();
        public static Point nhanMT2(double[,] matran, double[] mang)
        {
            double[] mangtam;
            mangtam = new double[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
        public static Point nhanMT2(int[,] matran, int[] mang)
        {
            int[] mangtam;
            mangtam = new int[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(mangtam[0], mangtam[1]);
            return pt;
        }

       

        public static Point nhanMT2(float[,] matran, float[] mang)//
        {
            float[] mangtam;

            mangtam = new float[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
        public static void PutColor(int x, int y, Color m)
        {
            if (x < 0 || x > 1426 || y < 0 || y > 780) return;
            arrcolor[s.round(y) / 5, s.round(x) / 5] = m;
        }
        public static void PutPixel(int x, int y, Color m, Graphics grfx)
        {
            if (x < 0 || x > 1426 || y < 0 || y > 780) return;

            //Graphics grfx = this.pictureBox1.CreateGraphics();
            Pen p = new Pen(m);
            SolidBrush b = new SolidBrush(m);
            grfx.FillRectangle(b, x, y, 5, 5);
            PutColor(x, y, m);
        }
        public static void Put4Pixel(int x, int y, int cx, int cy, Color m, Graphics grfx)
        {
            PutPixel(x + cx, y + cy, m, grfx);
            PutPixel(-x + cx, y + cy, m, grfx);
            PutPixel(x + cx, -y + cy, m, grfx);
            PutPixel(-x + cx, -y + cy, m, grfx);
        }
      
        public static void Put8Pixel(int x, int y, int cx, int cy, Color m, Graphics grfx)
        {
            PutPixel(cx + x, cy + y, m, grfx);
            PutPixel(cx + x, cy - y, m, grfx);
            PutPixel(cx - x, cy + y, m, grfx);
            PutPixel(cx - x, cy - y, m, grfx);
            PutPixel(cx + y, cy + x, m, grfx);
            PutPixel(cx + y, cy - x, m, grfx);
            PutPixel(cx - y, cy + x, m, grfx);
            PutPixel(cx - y, cy - x, m, grfx);
        }
        public static void PutColor1(int x, int y, int cx, int cy, Color m)
        {
            PutColor(x + cx, y + cy, m);
            PutColor(-x + cx, y + cy, m);
            PutColor(x + cx, -y + cy, m);
            PutColor(-x + cx, -y + cy, m);
        }

    }
}
