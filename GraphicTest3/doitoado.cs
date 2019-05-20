using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace GraphicTest3
{
    public class doitoado
    {

        public doitoado()
        {

        }

        public int round(double tds)
        {
            int tdm;
            double sodu = tds % 5;
            if (sodu != 0)
            {
                if (sodu >= 3) tdm = (int)(tds + 5 - sodu);
                else tdm = (int)(tds - sodu);
            }
            else tdm = (int)tds;
            if (tdm > 1400) tdm =1400;
            return tdm;
        }
        /*  public int round(double tds)
          {
              int tdm;
              float sodu = tds % 5;
              if (sodu != 0)
              {
                  if (sodu >= 3) tdm = (int)(tds + 5 - sodu);
                  else tdm = (int)(tds - sodu);
              }
              else tdm = (int)tds;
              return tdm;
          }*/
        public Point toado1(int x, int y)//lon ra nho
        {
            return (new Point(x / 5 - 140, 78 - y / 5));//voi x va y deu chia het cho 5
        }
        public Point toado2(int x, int y)//nho ra lon
        {

            return (new Point(x * 5 + 700, 390 - 5 * y));
        }
        public Point toado2(double x, double y)//nho ra lon
        {

            return (new Point(round(x * 5 + 700), round(390 - 5 * y)));
        }
    }
}
