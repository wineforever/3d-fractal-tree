using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wineforever.Coordinate;
namespace text_segmentation
{
    public partial class mainFrm : Form
    {
        //---- hyper-parameters ----
        public double __segmentation_threshold__ = 255;
        public int __border_interval__ = 1;
        public int __top__ = 10;
        //---- ----
        public string file_path = System.AppDomain.CurrentDomain.BaseDirectory + "demo.jpg";
        public void Segmentation()
        {
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(file_path);
            var histogram = Wineforever.Coordinate.client.HandleHistogram(bitmap);
            var res = Wineforever.Coordinate.client.DrawHistogram(histogram, Brushes.Blue, 2, false, false, __segmentation_threshold__);
            Graphics g = Graphics.FromImage(bitmap);
            foreach (KeyValuePair<int, double> pair in res)
                if (res.Keys.Contains(pair.Key - __border_interval__) && !res.Keys.Contains(pair.Key + __border_interval__))
                    g.DrawLine(new Pen(Brushes.Blue), 0, pair.Key - __top__, bitmap.Width, pair.Key - __top__);
            resWin.Image = bitmap;
            //Uncomment it if you want to see the histogram distribution.
            //Wineforever.Coordinate.client.Render();
        }
        public mainFrm()
        {
            InitializeComponent();
        }
        private void mainFrm_Load(object sender, EventArgs e)
        {
            float[] __custom__ = new float[4] { 0, 0, resWin.Width, resWin.Height };
            Wineforever.Coordinate.client.SetOriginalPoint(0, __custom__[3]);
            Wineforever.Coordinate.client.SetDistance(0.125);
            Wineforever.Coordinate.client.Initialization("2d",__custom__);
            Segmentation();
        }
    }
}
