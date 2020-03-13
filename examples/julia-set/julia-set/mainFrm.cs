using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wineforever.Coordinate;

namespace julia_set
{
    public partial class mainFrm : Form
    {
        //---- hyper-parameters ----
        //Maximum number of iterations
        //The larger the value, the richer the image detail.
        private static int N = 200;
        //Zoom size
        private static double scale = 3;
        //Constant: C = a + bi
        private static double a = 0;
        private static double b = -0.66;
        //Escape radius
        private static double r = 2;
        //---- ----
        public mainFrm()
        {
            InitializeComponent();
        }
        //Specify complex z = x + Yi
        private struct complex
        {
            public double x;
            public double y;
            public complex(double X, double Y) { this.x = X; this.y = Y; }
            public double m()
            {
                return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2));
            }
        };
        //Specified iteration formula: F (z) = Z ^ 2-C
        private static complex f_z(complex z, complex c)
        {
            return new complex() { x = Math.Pow(z.x, 2) - Math.Pow(z.y, 2) - c.x, y = 2 * z.x * z.y - c.y };
        }
        public static int iteration(Point point, Size size)
        {
            complex z = new complex() { x = (point.X - size.Width / 2) / (scale * 100), y = (point.Y - size.Height / 2) / (scale * 100) };
            complex c = new complex() { x = a, y = b };
            int t = 0;
            do
            {
                z = f_z(z, c);
                t++;
            }
            while (z.m() < r && t < N);
            return t;
        }
        public void Render()
        {
            Bitmap bgBitmap = new Bitmap(renderWin.Width, renderWin.Height);
            BitmapData data = bgBitmap.LockBits(new Rectangle(0, 0, bgBitmap.Width, bgBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Size size = new Size(bgBitmap.Width, bgBitmap.Height);
            int[] map = new int[size.Width * size.Height];
            var points = from x in Enumerable.Range(0, size.Width) from y in Enumerable.Range(0, size.Height) select new Point(x, y);
            points.AsParallel().ForAll(point => map[point.X * size.Height + point.Y] = iteration(point, size));
            unsafe
            {
                Parallel.For(0, data.Width, i =>
                {
                    Parallel.For(0, data.Height, j =>
                    {
                        byte* ptr = (byte*)data.Scan0 + i * 3 + j * data.Stride;
                        Color clr = Wineforever.Coordinate.client.ColorFade(Color.Black, Color.SkyBlue, map[i * size.Height + j] % N, N);
                        *ptr = clr.B;
                        *(ptr + 1) = clr.G;
                        *(ptr + 2) = clr.R;
                    });
                });
            }
            bgBitmap.UnlockBits(data);
            renderWin.Image = bgBitmap;
        }
        private void mainFrm_Load(object sender, EventArgs e)
        {
            Render();
        }
    }
}
