using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {   public object Picture { get; private set; }
         public Form1()
        {
            InitializeComponent();
        }

        static void multiply (int [, ] mat1, int [,] mat2 , int [,]res)
        {
            int N = 3;
            int i, j, k;
            for (i=0;i<N;i++)
            {
                for (j=0; j<N; j++)
                {
                    res[i, j] = 0;
                    for (k = 0; k < N; k++)
                        res[i, j] += mat1[i, k] * mat2[k, j];
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DDA 
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox3.Text);
            int x2 = Convert.ToInt32(textBox2.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();
            lineDDA(x1, y1, x2, y2);


        }

        private void drawAxis ()
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            for (int i=0; i<235; i++)
            {
                g.FillRectangle(aBrush, i, 150, 1, 1);
            } // x axis drawinggg
            for (int j=0; j< 301; j++)
            {
                g.FillRectangle(aBrush, 117, j, 1, 1);
            }// y axis drawing

        }
        private void lineDDA (int x0, int y0, int xEnd, int yEnd)
        {
            int xInitial = x0, yInitial = y0, xFinal = xEnd, yFinal = yEnd;
            int dx = xFinal - xInitial, dy = yFinal - yInitial, steps, k, xf, yf;
            float xIncrement, yIncrement, x = xInitial, y = yInitial;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);
            else steps = Math.Abs(dy);
            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;

            for (k=0; k<steps; k++)
            {
                x += xIncrement;
                xf = (int)x;
                y += yIncrement;
                yf = (int)y;
                

                try
                {
                    ddaPlotPoints(x, y);
                }
                catch (InvalidOperationException)
                {
                    return;
                }
            }
        }

        private void ddaPlotPoints (float x, float y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 117 + x, 150 - y, 2, 2);

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Bresenhaaam
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox3.Text);
            int x2 = Convert.ToInt32(textBox2.Text);
            int y2 = Convert.ToInt32(textBox4.Text);

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            if (dx>dy)
            {
                bresenhamLine(x1, y1, x2, y2, dx, dy, 0);
            }
            else
            {
                bresenhamLine(y1, x1, y2, x2, dy, dx, 1);
            }
            panel1.Controls.Clear();
            drawAxis();
        }

        private void BLAPlotPoints (int x, int y)
        {
            var aBrush = Brushes.Yellow;
            var g = panel1.CreateGraphics();
            g.FillRectangle(aBrush, 117 + x, 150 - y, 2, 2);
        }

        private void bresenhamLine (int x1, int y1, int x2, int y2, int dx, int dy, int decide)
        {
            int pk = 2 * dy - dx;
            for (int i=0; i<= dx -1; i++)
            {
                if (x1 < x2) x1++;
                else x1--;
                
                if (pk<0)
                {  if (decide==0)
                    {
                        BLAPlotPoints(x1, y1);
                        pk = pk + 2 * dy;

                    }
                else
                    {
                        BLAPlotPoints(y1, x1);
                        pk = pk + 2 * dy;

                    }
                        
                 }
                else
                {
                    if (y1 < y2) y1++;
                    else y1--;
                    if (decide == 0)
                    {
                        BLAPlotPoints(x1, y1);
                    }
                    else
                    {
                        BLAPlotPoints(y1, x1);
                    }
                    pk = pk + 2 * dy - 2 * dx;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //to clear

            panel1.CreateGraphics().Clear(Color.AliceBlue);
        }

        void circlePlotPoints (int xCenter, int yCenter, int x , int y )
        {
            var aBrush = Brushes.Blue;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 117 +(xCenter + x), 150 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter - x), 150 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter + x), 150 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter - x), 150 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter + y), 150 - (yCenter +x), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter - y), 150 - (yCenter +x), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter + y), 150 - (yCenter -x), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter -y), 150 - (yCenter - x), 2, 2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox5.Text);
            int y = Convert.ToInt32(textBox6.Text);
            int r = Convert.ToInt32(textBox6.Text);

            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();
            circleMidPoint(x, y, r);

        }


        void circleMidPoint (int xCenter, int yCenter, int radius)
        {
            int x = 0;
            int y = radius;
            int p = 1 - radius;
            circlePlotPoints(xCenter, yCenter, x, y);
            while (x<y)
            {
                x++;
                if (p < 0)
                    p += 2 * x + 1;
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                circlePlotPoints(xCenter, yCenter, x, y);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int xcenter = Convert.ToInt32(textBox8.Text);
            int ycenter = Convert.ToInt32(textBox9.Text);
            int xRadius = Convert.ToInt32(textBox10.Text);
            int yRadius = Convert.ToInt32(textBox11.Text);

            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();
            ellipseMidpoint(xcenter, ycenter, xRadius, yRadius);
        }

        void ellipseMidpoint (int xCenter, int yCenter, int Rx, int Ry)
        {
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;
            // Plot the initial point in each quad


            ellipsePlotPoints(xCenter, yCenter, x, y);
            // reg 1

            p = Convert.ToInt32((Ry2 - (Rx2 * Ry)) + (0.25 * Rx2));
            while (px<py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                    p += Ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;

                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
            // reg2
            p = Convert.ToInt32((Ry2 * (x + 0.5) * (x + 0.5)) + (Rx2 * (y - 1) * (y - 1)) - (Rx2 * Ry2));
            while (y>0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                    p += Rx2 - py;
                else
                {
                    x++;
                    px += twoRx2;
                    p += Rx2 - py + px;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
        }

        void ellipsePlotPoints (int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Aqua;
            var g = panel1.CreateGraphics();
            g.FillRectangle(aBrush, 117 + (xCenter + x), 150 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter - x), 150 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter + x), 150 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 117 + (xCenter - x), 150 - (yCenter - y), 2, 2);

        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Draw Button

            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);


            Point p1 = new Point(117 + x1, 150 - y1);
            Point p2 = new Point(117 + x2, 150 - y2);
            Point p3 = new Point(117 + x3, 150 - y3);
            Point p4 = new Point(117 + x4, 150 - y4);


            Graphics draw = panel1.CreateGraphics();
            var aBrush = Brushes.Bisque;
            Pen BlackPrush = new Pen(aBrush, 2);

            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();

            draw.DrawLine(BlackPrush, p1, p2);
            draw.DrawLine(BlackPrush, p2, p3);
            draw.DrawLine(BlackPrush, p3, p4);
            draw.DrawLine(BlackPrush, p1, p4);

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) // draw over y axis
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);


            int x1dash = 0;
            int x2dash = 0;
            int x3dash = 0;
            int x4dash = 0;


            int[,] currentMat1 =
            {
                {1,0,x1 },
                {0,1 , y1 },
                {0,0,1 }
            };

            int[,] currentMat2 =
            {
                {1,0,x2 },
                {0,1 , y2 },
                {0,0,1 }
            };

            int[,] currentMat3 =
            {
                {1,0,x3 },
                {0,1 , y3 },
                {0,0,1 }
            };

            int[,] currentMat4 =
            {
                {1,0,x4 },
                {0,1 , y4 },
                {0,0,1 }
            };

            int[,] newMat1 =
            {
                {1,0,x1dash },
                {0,1 , y1 },
                {0,0,1 }
            };

            int[,] newMat2 =
            {
                {1,0,x2dash },
                {0,1 , y2 },
                {0,0,1 }
            };

            int[,] newMat3 =
         {
                {1,0,x3dash },
                {0,1 , y3 },
                {0,0,1 }
            };

            int[,] newMat4 =
         {
                {1,0,x4dash },
                {0,1 , y4 },
                {0,0,1 }
            };

            int[,] reflectMat=
         {
                { -1,0,0},
                {0,1,0 },
                {0,0,1 }
            };

            multiply(reflectMat, currentMat1, newMat1);
            multiply(reflectMat, currentMat2, newMat2);
            multiply(reflectMat, currentMat3, newMat3);
            multiply(reflectMat, currentMat4, newMat4);

            Graphics draw = panel1.CreateGraphics();

            var aBrush = Brushes.HotPink;
            Pen BlackBrush = new Pen(aBrush, 2);
            draw.DrawLine(BlackBrush, newMat1[0, 2] + 117, 150 - y1, newMat2[0, 2] + 117, 150 - y2);
            draw.DrawLine(BlackBrush, newMat2[0, 2] + 117, 150 - y2, newMat3[0, 2] + 117, 150 - y3);
            draw.DrawLine(BlackBrush, newMat3[0, 2] + 117, 150 - y3, newMat4[0, 2] + 117, 150 - y4);
            draw.DrawLine(BlackBrush, newMat1[0, 2] + 117, 150 - y1, newMat4[0, 2] + 117, 150 - y4);


            drawAxis();


        }

        private void button8_Click(object sender, EventArgs e) // over x
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int y1dash = 0;
            int y2dash = 0;
            int y3dash = 0;
            int y4dash = 0;

            int[,] currentMat1 =
            {
                {1,0,x1 },
                {0,1 , y1 },
                {0,0,1 }
            };

            int[,] currentMat2 =
            {
                {1,0,x2 },
                {0,1 , y2 },
                {0,0,1 }
            };

            int[,] currentMat3 =
            {
                {1,0,x3 },
                {0,1 , y3 },
                {0,0,1 }
            };

            int[,] currentMat4 =
            {
                {1,0,x4 },
                {0,1 , y4 },
                {0,0,1 }
            };

            int[,] newMat1 =
           {
                {1,0,x1 },
                {0,1 , y1dash },
                {0,0,1 }
            };

            int[,] newMat2 =
            {
                {1,0,x2 },
                {0,1 , y2dash },
                {0,0,1 }
            };

            int[,] newMat3 =
         {
                {1,0,x3 },
                {0,1 , y3dash },
                {0,0,1 }
            };

            int[,] newMat4 =
         {
                {1,0,x4 },
                {0,1 , y4dash },
                {0,0,1 }
            };

            int[,] reflectMat =
         {
                { 1,0,0},
                {0,-1,0 },
                {0,0,1 }
            };



            multiply(reflectMat, currentMat1, newMat1);
            multiply(reflectMat, currentMat2, newMat2);
            multiply(reflectMat, currentMat3, newMat3);
            multiply(reflectMat, currentMat4, newMat4);

            Graphics draw = panel1.CreateGraphics();

            var aBrush = Brushes.HotPink;
            Pen BlackBrush = new Pen(aBrush, 2);
            draw.DrawLine(BlackBrush, x1+117 , 150 - newMat1[1,2], x2 +117 , 150 - newMat2[1,2]);
            draw.DrawLine(BlackBrush, x2 + 117, 150 - newMat2[1, 2], x3 + 117, 150 - newMat3[1, 2]);
            draw.DrawLine(BlackBrush, x3+ 117, 150 - newMat3[1, 2], x4 + 117, 150 - newMat4[1, 2]);
            draw.DrawLine(BlackBrush, x1 + 117, 150 - newMat1[1, 2], x4 + 117, 150 - newMat4[1, 2]);
          //draw.Axis();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);


            int y1dash = 0;
            int y2dash = 0;
            int y3dash = 0;
            int y4dash = 0;
            int x1dash = 0;
            int x2dash = 0;
            int x3dash = 0;
            int x4dash = 0;



            int[,] currentMat1 =
            {
                {1,0,x1 },
                {0,1 , y1 },
                {0,0,1 }
            };

            int[,] currentMat2 =
            {
                {1,0,x2 },
                {0,1 , y2 },
                {0,0,1 }
            };

            int[,] currentMat3 =
            {
                {1,0,x3 },
                {0,1 , y3 },
                {0,0,1 }
            };

            int[,] currentMat4 =
            {
                {1,0,x4 },
                {0,1 , y4 },
                {0,0,1 }
            };

            int[,] newMat1 =
       {
                {1,0,x1dash },
                {0,1 , y1dash },
                {0,0,1 }
            };

            int[,] newMat2 =
            {
                {1,0,x2dash },
                {0,1 , y2dash },
                {0,0,1 }
            };

            int[,] newMat3 =
         {
                {1,0,x3dash },
                {0,1 , y3dash },
                {0,0,1 }
            };

            int[,] newMat4 =
         {
                {1,0,x4dash },
                {0,1 , y4dash },
                {0,0,1 }
            };

            int[,] reflectMat =
         {
                { -1,0,0},
                {0,-1,0 },
                {0,0,1 }
            };

            multiply(reflectMat, currentMat1, newMat1);
            multiply(reflectMat, currentMat2, newMat2);
            multiply(reflectMat, currentMat3, newMat3);
            multiply(reflectMat, currentMat4, newMat4);

            Graphics draw = panel1.CreateGraphics();
            var aBrush = Brushes.Pink;
            Pen BlackBrush = new Pen(aBrush, 2);
            draw.DrawLine(BlackBrush, newMat1[0, 2] + 117, 150 - newMat1[1, 2], newMat2[0, 2] + 117, 150 - newMat2[1, 2]);
            draw.DrawLine(BlackBrush, newMat2[0, 2] + 117, 150 - newMat2[1, 2], newMat3[0, 2] + 117, 150 - newMat3[1, 2]);
            draw.DrawLine(BlackBrush, newMat3[0, 2] + 117, 150 - newMat3[1, 2], newMat4[0, 2] + 117, 150 - newMat4[1, 2]);
            draw.DrawLine(BlackBrush, newMat1[0, 2] + 117, 150 - newMat1[1, 2], newMat4[0, 2] + 117, 150 - newMat4[1, 2]);

        }

        private void Translate (int xdash, int ydash, int xdash2, int ydash2, int xdash3, int ydash3, int xdash4, int ydash4)
        {

            Graphics draw = panel1.CreateGraphics();
            var aBrush = Brushes.Yellow;
            Pen BlackBrush = new Pen(aBrush, 2);
            Point p1 = new Point(xdash + 117, 150 - ydash);
            Point p2 = new Point(xdash2 + 117, 150 - ydash2);
            Point p3 = new Point(xdash3 + 117, 150 - ydash3);
            Point p4 = new Point(xdash4 + 117, 150 - ydash4);

            draw.DrawLine(BlackBrush, p1, p2);
            draw.DrawLine(BlackBrush, p2, p3);
            draw.DrawLine(BlackBrush, p3, p4);
            draw.DrawLine(BlackBrush, p1, p4);

            //draw.DrawRectangle (redBrush, xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4)
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int x = Convert.ToInt32(textBox20.Text);
            int y = Convert.ToInt32(textBox21.Text);


            int xdash = x1+ x ;
            int ydash = y1+y  ;
            int xdash2 = x2+x ;
            int ydash2 = y2 +y;
            int xdash3 = x3+x;
            int ydash3 = y3+y;
            int xdash4 = x4+x;
            int ydash4 = y4+y;



            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e) // SCAALEEE
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int x = Convert.ToInt32(textBox20.Text);
            int y = Convert.ToInt32(textBox21.Text);

            int xdash1 = x1 * x;
            int xdash2 = x2 * x;
            int xdash3 = x3 * x;
            int xdash4 = x4 * x;
            int ydash1 = y1 * y;
            int ydash2 = y2 * y;
            int ydash3 = y3 * y;
            int ydash4 = y4 * y;


            Translate(xdash1, ydash1, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);

        }

        private void button12_Click(object sender, EventArgs e) // shearing x
        {

            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int sx = Convert.ToInt32(textBox22.Text);

            int xdash1 = x1 + sx * y1;
            int xdash2 = x2 + sx * y2;
            int xdash3 = x3 +sx *y3;
            int xdash4 = x4 + sx * y4;


            int ydash1 = y1 ;
            int ydash2 = y2 ;
            int ydash3 = y3 ;
            int ydash4 = y4;

            Translate(xdash1, ydash1, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);

        }

        private void button13_Click(object sender, EventArgs e) // shear Y 
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int sy = Convert.ToInt32(textBox23.Text);

            int xdash1 = x1 ;
            int xdash2 = x2 ;
            int xdash3 = x3 ;
            int xdash4 = x4 ;


            int ydash1 = y1 + (sy * x1 );
            int ydash2 = y2 + (sy * x2);
            int ydash3 = y3 + (sy * x3) ;
            int ydash4 = y4 + (sy * x4);


            Translate(xdash1, ydash1, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);
        }

        private void button14_Click(object sender, EventArgs e) // rotation
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox17.Text);
            int x3 = Convert.ToInt32(textBox15.Text);
            int y3 = Convert.ToInt32(textBox18.Text);
            int x4 = Convert.ToInt32(textBox16.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int angle= Convert.ToInt32(textBox24.Text);


            int xdash1 = Convert.ToInt32((Math.Cos(angle) * x1) - (Math.Sin(angle) * y1));
            int ydash1 = Convert.ToInt32((Math.Sin(angle) * x1) + (Math.Cos(angle) * y1));
            int xdash2 = Convert.ToInt32((Math.Cos(angle) * x2) - (Math.Sin(angle) * y2));
            int ydash2= Convert.ToInt32((Math.Sin(angle) * x2) +(Math.Cos(angle) * y2));
            int xdash3 = Convert.ToInt32((Math.Cos(angle) * x3) - (Math.Sin(angle) * y3));
            int ydash3 = Convert.ToInt32((Math.Sin(angle) * x3) + (Math.Cos(angle) * y3));
            int xdash4 = Convert.ToInt32((Math.Cos(angle) * x4) - (Math.Sin(angle) * y4));
            int ydash4 = Convert.ToInt32((Math.Sin(angle) * x4) + (Math.Cos(angle) * y4));


            Translate(xdash1, ydash1, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);





        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
