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
using static Wineforever.Coordinate.client;

namespace _3d_fractal_tree
{
    public partial class mainFrm : Form
    {
        //---- hyper-parameters ----
        //Iteration times
        int T = 1;
        //Grammar
        string grammar = "FA[*+X][-/&X][/%X]B";
        //Initial length
        double len = 5;
        //Length attenuation factor
        double len_factor = 0.65;
        //Initial radius
        double r = 0.4;
        //Radius attenuation factor
        double r_factor = 0.65;
        //Rotate offset factor about X axis
        double dx = 0.28431130435127;
        //Rotate offset factor about Y axis
        double dy = 0.440391430548652;
        //Rotate offset factor about Z axis
        double dz = 0.147560172097861;
        //-------- --------
        //---- other-parameters ----
        Bitmap texture = (Bitmap)Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "texture");
        double rotation = 0;
        //-------- --------
        public mainFrm()
        {
            InitializeComponent();
        }
        //Specific instructions of grammar
        private void Render()
        {
            Point3D cur_Pos = new Point3D(0, 0, 0);
            Point3D cur_Dir = new Point3D(0, 0, 1);
            List<Point3D> stack = new List<Point3D>();
            for (int i = 0; i < grammar.Length; i++)
            {
                switch (grammar[i])
                {
                    case 'F':
                        {
                            var p0 = cur_Pos;
                            cur_Pos.X += len * cur_Dir.X;
                            cur_Pos.Y += len * cur_Dir.Y;
                            cur_Pos.Z += len * cur_Dir.Z;
                            var p1 = cur_Pos;
                            Wineforever.Coordinate.client.DrawFrustum(p0.X, p0.Y, p0.Z, p1.X, p1.Y, p1.Z, r, r * r_factor, texture, 2);
                        }
                        break;
                    case 'X':
                        {
                            var p0 = cur_Pos;
                            cur_Pos.X += len * cur_Dir.X * 0.25;
                            cur_Pos.Y += len * cur_Dir.Y * 0.25;
                            cur_Pos.Z += len * cur_Dir.Z * 0.25;
                            var p1 = cur_Pos;
                        }
                        break;
                    case 'A':
                        {
                            len = len * len_factor;
                            r = r * r_factor;
                        }
                        break;
                    case 'B':
                        {
                            len = len / len_factor;
                            r = r / r_factor;
                        }
                        break;
                    case '[':
                        {
                            stack.Add(cur_Dir);
                            stack.Add(cur_Pos);
                        }
                        break;
                    case ']':
                        {
                            cur_Dir = stack[stack.Count - 2];
                            cur_Pos = stack[stack.Count - 1];
                            stack.RemoveAt(stack.Count - 1);
                            stack.RemoveAt(stack.Count - 1);
                        }
                        break;
                    case '+':
                        {
                            cur_Dir.Y += dy;
                            cur_Dir.Z += dz;
                        }
                        break;
                    case '-':
                        {
                            cur_Dir.Y -= dy;
                            cur_Dir.Z -= dz;
                        }
                        break;
                    case '*':
                        {
                            cur_Dir.X += dx;
                            cur_Dir.Z += dz;
                        }
                        break;
                    case '/':
                        {
                            cur_Dir.X -= dx;
                            cur_Dir.Z -= dz;
                        }
                        break;
                    case '&':
                        {
                            cur_Dir.X += dx;
                            cur_Dir.Y += dy;
                        }
                        break;
                    case '%':
                        {
                            cur_Dir.X -= dx;
                            cur_Dir.Y -= dy;
                        }
                        break;
                }
            }
        }
        //Iteration of grammar
        private void Iteration()
        {
            string __rule__ = grammar;
            string rule = "";
            for (int i = 0; i < T; i++)
            {
                int len = __rule__.Length;
                for (int j = 0; j < len; j++)
                {
                    if (__rule__[j] == 'X')//Iteration
                    {
                        rule += grammar;
                    }
                    else//Reserved corner
                    {
                        rule += __rule__[j];
                    }
                }
                __rule__ = rule;
                rule = "";
            }
            grammar = __rule__;
        }
        private void mainFrm_Load(object sender, EventArgs e)
        {
            //Initialization
            float[] __custom_size__ = new float[4] { 0, 0, renderWin.Width, renderWin.Height };
            Wineforever.Coordinate.client.Initialization("3d", __custom_size__);
            //Iteration
            Iteration();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //Automatic rotation
            rotation++;
            Wineforever.Coordinate.client.SetRotation(0, 0, rotation, true);
            //Render
            Render();
            renderWin.Image = Wineforever.Coordinate.client.Render();
        }
    }
}
