using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicTest3
{
    public partial class Form1 : Form
    {
       
        Point[] points = new Point[1000];//cac diem de thao tac ve hinh
        int goc;
        doitoado s = new doitoado();
        public Form1()
        {
            InitializeComponent();
            heToaDo3D();
        }

        // TINH TIEN
        public static Point TinhTien(Point d1, int dx, int dy, doitoado s)
        {
            int x, y;
            x = d1.X; y = d1.Y;
            double[,] matran1;
            double[] mang;
            mang = new double[3];
            matran1 = new double[3, 3];

            //Ma tran cua phep tinh tien diem p theo vecter(dx,dy);
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = dx; matran1[2, 1] = dy; matran1[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt2 = botro.nhanMT2(matran1, mang);
            Point kq = new Point(s.round(pt2.X), s.round(pt2.Y));
            return kq;
        }
        // DOI XUNG 
        /////////////////////////////////////////////
        //DOI XUNG...
        public Point DoiXung(Point d1, Point d2)// ve diem doi xung cua (x1,y1)qua tam doi xung (x2,y2)
        {
            int x1, y1, x2, y2;
            x1 = d1.X; y1 = d1.Y; x2 = d2.X; y2 = d2.Y;
            int[,] matran1;
            int[,] matran2;
            int[] mang;
            int[] mangtam = { 0, 0, 0 };
            mangtam = new int[3];
            mang = new int[3];
            matran1 = new int[3, 3];
            matran2 = new int[3, 3];
            // putpixel(x1, x2, getcolor(x1, y1)); putpixel(pt2.X, pt2.Y, getcolor(x1, y1));
            // putPixel(x1, y1, x1, y1, 0, 0, 0);// diem P...
            // putPixel(x2, y2, x2, y2, 0, 0, 1);// Tam doi xung...
            //Ma tran tinh tien ve tam I rki sau do lay doi xung p' qua tam I
            matran1[0, 0] = -1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = -1; matran1[1, 2] = 0;
            matran1[2, 0] = x2; matran1[2, 1] = y2; matran1[2, 2] = 1;
            mang[0] = x1; mang[1] = y1; mang[2] = 1;
            Point pt1 = botro.nhanMT2(matran1, mang);
            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = 1; matran2[1, 2] = 0;
            matran2[2, 0] = x2; matran2[2, 1] = y2; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = botro.nhanMT2(matran2, mang);
            Point kq = new Point(s.round(pt2.X), s.round(pt2.Y));
            return kq;
        }

        //DOI XUNG QUA DUONG THANG BAT KI...
        public Point DoiXung(double m, int b, Point diem)
        {   // tim diem doi xung cua 1 diem (x,y) qua 1 duong thang y=mx+b
            Point dd = this.s.toado1(diem.X, diem.Y);
            float s = 0, c = 0;
            float[,] matran1;
            float[,] matran2;
            float[,] matran3;
            float[,] matran;
            float[] mang;
            int x, y;
            x = dd.X; y = dd.Y;
            mang = new float[3];
            matran1 = new float[3, 3];
            matran2 = new float[3, 3];
            matran3 = new float[3, 3];
            matran = new float[3, 3];
            mang = new float[3];
            float tam = Convert.ToSingle(Math.Pow(m, 2));
            float a = -1 * Convert.ToSingle(Math.Atan(m));
            c = Convert.ToSingle(Math.Cos(a));
            s = Convert.ToSingle(Math.Sin(a));

            // ma tran tinh tien duong thang ve thanh duong thang di qua goc t/d O...
            matran[0, 0] = 1; matran[0, 1] = 0; matran[0, 2] = 0;
            matran[1, 0] = 0; matran[1, 1] = 1; matran[1, 2] = 0;
            matran[2, 0] = 0; matran[2, 1] = -b; matran[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt = botro.nhanMT2(matran, mang);

            //ma tran quay duong thang ve trung truc Ox
            matran1[0, 0] = c; matran1[0, 1] = s; matran1[0, 2] = 0;
            matran1[1, 0] = -1 * s; matran1[1, 1] = c; matran1[1, 2] = 0;
            matran1[2, 0] = 0; matran1[2, 1] = 0; matran1[2, 2] = 1;
            mang[0] = pt.X; mang[1] = pt.Y; mang[2] = 1;
            Point pt1 = botro.nhanMT2(matran1, mang);

            //Ma tran cua phep lay doi xung qua truc 0x
            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = -1; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = botro.nhanMT2(matran2, mang);

            //Ma tran cua phep quay nguoc lai vi tri cu
            matran3[0, 0] = c; matran3[0, 1] = -s; matran3[0, 2] = 0;
            matran3[1, 0] = s; matran3[1, 1] = c; matran3[1, 2] = 0;
            matran3[2, 0] = 0; matran3[2, 1] = 0; matran3[2, 2] = 1;
            mang[0] = pt2.X; mang[1] = pt2.Y; mang[2] = 1;
            Point pt3 = botro.nhanMT2(matran3, mang);

            //Ma tran cua phep tinh tien diem do ve vi tri ban dau 
            matran[0, 0] = 1; matran[0, 1] = 0; matran[0, 2] = 0;
            matran[1, 0] = 0; matran[1, 1] = 1; matran[1, 2] = 0;
            matran[2, 0] = 0; matran[2, 1] = b; matran[2, 2] = 1;
            mang[0] = pt3.X; mang[1] = pt3.Y; mang[2] = 1;
            Point pt4 = botro.nhanMT2(matran, mang);
            Point kq = this.s.toado2(pt4.X, pt4.Y);
            return kq;
        }
        public Point dxungOy(Point diem, int x)
        {
            Point temp = new Point(0, 0);
            if (diem.X < x) temp.X = diem.X + 2 * (x - diem.X);
            else temp.X = diem.X - 2 * (diem.X - x);
            temp.Y = diem.Y;
            return temp;
        }
        //quay
        public Point Quay(Point d1, Point d2, int gocquay)// Quay 1 diem (x,y)quanh diem(xo,yo)1 goc a;
        {
            Point dd1, dd2;
            dd1 = this.s.toado1(d1.X, d1.Y);
            dd2 = this.s.toado1(d2.X, d2.Y);
            int x, y, xo, yo;
            int goc;
            x = dd1.X; y = dd1.Y; xo = dd2.X; yo = dd2.Y;
            int a = gocquay;
            double[,] matran1;
            double[,] matran2;
            double[,] matran3;
            double[] mang;
            double c, s;
            mang = new double[3];
            matran1 = new double[3, 3];
            matran2 = new double[3, 3];
            matran3 = new double[3, 3];
            // ma tran tinh tien (xo,yo)ve goc toa do
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = -xo; matran1[2, 1] = -yo; matran1[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt = botro.nhanMT2(matran1, mang);
            //Ma tran quay quanh goc toa do mot goc a;
            s = Math.Sin((Math.PI * a) / 180);
            c = Math.Cos((Math.PI * a) / 180);
            matran2[0, 0] = c; matran2[0, 1] = s; matran2[0, 2] = 0;
            matran2[1, 0] = -1 * s; matran2[1, 1] = c; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt.X; mang[1] = pt.Y; mang[2] = 1;
            Point pt1 = botro.nhanMT2(matran2, mang);
            // ma tran doi diem ve toa do cu
            matran3[0, 0] = 1; matran3[0, 1] = 0; matran3[0, 2] = 0;
            matran3[1, 0] = 0; matran3[1, 1] = 1; matran3[1, 2] = 0;
            matran3[2, 0] = xo; matran3[2, 1] = yo; matran3[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = botro.nhanMT2(matran3, mang);
            Point kq = this.s.toado2(pt2.X, pt2.Y);
            return kq;
        }
        public Point scale(Point d1, Point d2, int sx, int sy)
        {
            Point dd1, dd2;
            dd1 = this.s.toado1(d1.X, d1.Y);
            dd2 = this.s.toado1(d2.X, d2.Y);
            int x1, y1, xo, yo;
            x1 = dd1.X; y1 = dd1.Y; xo = dd2.X; yo = dd2.Y;
            int[,] matran1;
            int[,] matran2;
            int[,] matran3;

            int[] mang;
            int[] mangtam = { 0, 0, 0 };
            mangtam = new int[3];
            mang = new int[3];
            matran1 = new int[3, 3];
            matran2 = new int[3, 3];
            matran3 = new int[3, 3];
            //    putPixel(x1, y1, x1, y1, 0, 0, 0);// diem P...
            //    putPixel(xo, yo, xo, yo, 0, 0, 1);// Tam ty le ...
            //Ma tran tinh tien ve tam O ...
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = -xo; matran1[2, 1] = -yo; matran1[2, 2] = 1;
            mang[0] = x1; mang[1] = y1; mang[2] = 1;
            Point pt1 = botro.nhanMT2(matran1, mang);
            //Ma tran ty le ...
            matran2[0, 0] = sx; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = sy; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = botro.nhanMT2(matran2, mang);
            //Ma tran tinh tien nguoc ve vi tri cu...
            matran3[0, 0] = 1; matran3[0, 1] = 0; matran3[0, 2] = 0;
            matran3[1, 0] = 0; matran3[1, 1] = 1; matran3[1, 2] = 0;
            matran3[2, 0] = xo; matran3[2, 1] = yo; matran3[2, 2] = 1;
            mang[0] = pt2.X; mang[1] = pt2.Y; mang[2] = 1;
            Point pt3 = botro.nhanMT2(matran3, mang);
            Point kq = s.toado2(pt3.X, pt3.Y);
            return kq;
        }






        public void heToaDo()
        {
            
            Bitmap flag = new Bitmap(2000, 2000);
            Graphics flagGraphics = Graphics.FromImage(flag);

            for (int j = 0; j <= 782; j = j + 5)
            {

                Point pont3 = new Point();
                pont3.X = 0;
                pont3.Y = j;
                Point pont4 = new Point();
                pont4.X = 1426;
                pont4.Y = j;
                // flagGraphics.FillRectangle(Brushes.Black, i, j, 1, 1);
                // flagGraphics.FillRectangle(Brushes.Black,j,i, 1, 1);
                flagGraphics.DrawLine(new Pen(Color.Black), pont3, pont4);
            }
            for (int j = 0; j <= 1426; j = j + 5)
            {

                Point pont1 = new Point();
                pont1.X = j;
                pont1.Y = 0;
                Point pont2 = new Point();
                pont2.X = j;
                pont2.Y = 780;
                flagGraphics.DrawLine(new Pen(Color.Black), pont1, pont2);
            }
            flagGraphics.DrawLine(new Pen(Color.Red), 715, 0, 715, 1426);
            flagGraphics.DrawLine(new Pen(Color.Red), 0, 390, 1426, 390);
            pictureBox1.Image = flag;
        }
        public void heToaDo3D()
        {
         
           
            Bitmap flag = new Bitmap(2000, 2000);
            Graphics flagGraphics = Graphics.FromImage(flag);

            for (int j = 0; j <= 782; j = j + 5)
            {

                Point pont3 = new Point();
                pont3.X = 0;
                pont3.Y = j;
                Point pont4 = new Point();
                pont4.X = 1426;
                pont4.Y = j;
                // flagGraphics.FillRectangle(Brushes.Black, i, j, 1, 1);
                // flagGraphics.FillRectangle(Brushes.Black,j,i, 1, 1);
                flagGraphics.DrawLine(new Pen(Color.Black), pont3, pont4);
            }
            for (int j = 0; j <= 1426; j = j + 5)
            {

                Point pont1 = new Point();
                pont1.X = j;
                pont1.Y = 0;
                Point pont2 = new Point();
                pont2.X = j;
                pont2.Y = 780;
                flagGraphics.DrawLine(new Pen(Color.Black), pont1, pont2);
            }
            flagGraphics.DrawLine(new Pen(Color.Red), 715, 390, 715, 0);
            flagGraphics.DrawLine(new Pen(Color.Red), 715, 390, 1426, 390);
            flagGraphics.DrawLine(new Pen(Color.Red), 715, 390, 0, 780);
            pictureBox1.Image = flag;

        }

        private void rotate()
            {
            goc = 0;
            timer1.Start();
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //points[0].X = 50;
            //points[0].Y = 50;
            //points[1].X = 100;
            //points[1].Y = 100;
            //points[2].X = 50;
            //points[2].Y = 50;
            //points[3].X = 200;
            //points[3].Y = 200;
            //int dx = 10;
            //int dy = 50;
          
           // rotate();

           //   DDA_Line(points[0], points[1], Color.Black);
           //DDA_Line(TinhTien(points[0], dx, dy), TinhTien(points[1], dx, dy), Color.Black);
           //  DDA_Line(Quay(points[0], points[3],90), Quay(points[1], points[3], 90),Color.Black);
           //  hvuong(points[0], points[1]);
           //Midpoint_htron(100, 100, 60, Color.Black);
           //TamGiac(points[0], points[1], points[2]);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            //  Square.HVuong(Quay(points[0], points[3], goc), 30, g, s);
            //  Line.DDA_Line(Quay(points[0], points[3], goc), Quay(points[1], points[3], goc),Color.Red,g,s);
            Random rnd = new Random();
            int mau = rnd.Next(0, 255);
            int mau1 = rnd.Next(0, 255);
            int mau2 = rnd.Next(0, 255);
            Color m = Color.FromArgb(mau, mau1, mau2);
            Triangle.TamGiac(points[0], points[1], points[2], g, s);
            Triangle.TamGiac(Quay(points[3], points[3], goc), Quay(points[4], points[3], goc), Quay(points[5], points[3], goc), g, s, m);
            Triangle.TamGiac(DoiXung(Quay(points[3], points[3], goc), points[3]), DoiXung(Quay(points[4], points[3], goc), points[3]), DoiXung(Quay(points[5], points[3], goc), points[3]), g, s, m);
            Triangle.TamGiac(Quay(points[6], points[3], goc), Quay(points[7], points[3], goc), Quay(points[8], points[3], goc), g, s, m);
            Triangle.TamGiac(DoiXung(Quay(points[6], points[3], goc), points[3]), DoiXung(Quay(points[7], points[3], goc), points[3]), DoiXung(Quay(points[8], points[3], goc), points[3]), g, s, m);

            //Triangle.TamGiac(Quay(points[0], points[0], goc), Quay(points[1], points[0], goc), Quay(points[2], points[0], goc), g, s);
            //Triangle.TamGiac(DoiXung(Quay(points[0], points[0], goc),points[3]), DoiXung(Quay(points[1], points[0], goc), points[3]), DoiXung(Quay(points[2], points[0], goc), points[3]), g, s);
            Thread.Sleep(5);
            heToaDo3D();
            goc = goc + 10;
            if (goc >= 360) goc = 0;
        }

        public void HinhHopChuNhat1(Point a, Point b, Point c, Point d, int h, Graphics grfx, doitoado s)
        {
            GraphicTest3.Parallelogram.HinhBinhHanh(a, b, c, d, grfx, s);
            GraphicTest3.Parallelogram.HinhBinhHanh(TinhTien(a, 0, -h, s), Form1.TinhTien(b, 0, -h, s), TinhTien(c, 0, -h, s), TinhTien(d, 0, -h, s), grfx, s);
            GraphicTest3.Parallelogram.HinhBinhHanh(a, b, TinhTien(b, 0, -120, s), TinhTien(a, 0, -120, s), grfx, s);
            GraphicTest3.Parallelogram.HinhBinhHanh(c, d, TinhTien(d, 0, -120, s), TinhTien(c, 0, -120, s), grfx, s);
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {  //TOA DO CUA HINH 3D
            points[0].X = 715;
            points[0].Y = 390;
            points[1].X = 900;
            points[1].Y = 390;
            points[2].X = 510;
            points[2].Y = 600;
            points[3].X = 325;
            points[3].Y = 600;

            //  points[0].X = 200;
            //  points[0].Y = 200;
            //  points[1].X = 100;
            //  points[1].Y = 300;
            //  points[2].X = 100;
            //  points[2].Y = 400;
            //points[3].X = 350;
            //points[3].Y = 350;
            // ve coi xay gio
            //points[0].X = 110;
            //points[0].Y = 500;
            //points[1].X = 70;
            //points[1].Y = 700;
            //points[2].X = 150;
            //points[2].Y = 700;
            //// canh quat 1
            //points[3].X = 110;
            //points[3].Y = 500;
            //points[4].X = 0;
            //points[4].Y = 475;
            //points[5].X = 0;
            //points[5].Y = 525;
            //// canh quat 2
            //points[6].X = 110;
            //points[6].Y = 500;
            //points[7].X = 135;
            //points[7].Y = 610;
            //points[8].X = 85;
            //points[8].Y = 610;

            int dx = 10;
            int dy = 50;
         //   heToaDo3D();
            Graphics g = this.pictureBox1.CreateGraphics();
            HinhHopChuNhat1(points[0], points[1], points[2], points[3],120,g,s);
            // DDA_Line_Muted(points[0], points[1],Color.DarkRed);
            //  HVuong(scale(points[0], points[2], 2, 2), scale(points[1], points[2], 2, 2));
          // rotate();
          //  Midpoint_elip(200, 200, 150, 50);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Point a = new Point();
            a.X = 110; a.Y = 10;
            Point b = new Point();
            b.X = 200; b.Y = 100;
            Graphics g = this.pictureBox1.CreateGraphics();
            Square.HVuong(a, b, g, s);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Point a = new Point();
            a.X = 10;a.Y = 10;
            Point b = new Point();
            b.X = 100; b.Y = 100;
            Graphics g = this.pictureBox1.CreateGraphics();
            Line.DDA_Line(a,b, Color.DarkRed,g,s);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Point a = new Point();
            a.X = 1000; a.Y = 10;
            
            Graphics g = this.pictureBox1.CreateGraphics();
            Circle.Midpoint_htron(1300, 60, 50, Color.Red, g, s);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Point a = new Point();
            a.X = 10; a.Y = 10;

            Graphics g = this.pictureBox1.CreateGraphics();
            Eclip.Midpoint_elip(500, 300, 100,50, g, s);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            Point a = new Point();
            Point b = new Point();
            Point c = new Point();
            Point d = new Point();
            a.X = 200;
            a.Y = 200;
            b.X = 100;
            b.Y = 300;
            c.X = 300;
            c.Y = 300;
            d.X = 400;
            d.Y = 200;
           // Parallelogram.HinhBinhHanh(a,b,c,d,g,s);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            Point a = new Point();
            Point b = new Point();
            Point c = new Point();
            
            a.X = 400;
            a.Y = 400;
            b.X = 300;
            b.Y = 500;
            c.X = 300;
            c.Y = 600;

            Triangle.TamGiac(a, b, c,g,s);
        }
    }
}
