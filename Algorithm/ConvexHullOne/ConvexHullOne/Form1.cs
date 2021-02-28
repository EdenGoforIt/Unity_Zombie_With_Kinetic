using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvexHullOne
{
    public partial class Form1 : Form
    {
        const int PTSIZE = 5;
        Point a;
        Point b;
        Point c;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen redColor = new Pen(Color.Red, 3);
            if (count >= 1)
            {
                DrawPoint(g, a, redColor);
            }
            if (count >= 2)
            {
                DrawPoint(g, b, redColor);
                g.DrawLine(redColor, a, b);
            }
            if (count == 3)
            {
                DrawPoint(g, c, redColor);
                g.DrawLine(redColor, b, c);
            }

        }

        private void DrawPoint(Graphics g, Point pt, Pen pen)
        {
            g.DrawLine(pen, pt.X - PTSIZE, pt.Y, pt.X + PTSIZE, pt.Y);
            g.DrawLine(pen, pt.X, pt.Y - PTSIZE, pt.X, pt.Y + PTSIZE);
        }


        private double crossProduct(Point a, Point b, Point c)
        {
            return ((a.X * b.Y) - (b.X * a.Y) + (b.X * c.Y) - (c.X * b.Y) + (c.X * a.Y) - (a.X * c.Y));
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (count == 0)
            {
                a = new Point(e.X, e.Y);
                count = 1;
            }
            else if (count == 1)
            {
                b = new Point(e.X, e.Y);
                count = 2;
            }
            else
            {
                c = new Point(e.X, e.Y);
                count = 3;
                double result = crossProduct(a, b, c);
                if (Math.Abs(result) < 1000)
                {   
                    label1.Text = "Linear";
                }
                else if (result > 0)
                {
                    label1.Text = "Clockwise";
                }
                else if (result < 0)
                {
                    label1.Text = "AntiClockwise";
                }
            }
            panel1.Refresh();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            count = 0;
            panel1.Refresh();
            label1.Text = "";
        }
    }
}
