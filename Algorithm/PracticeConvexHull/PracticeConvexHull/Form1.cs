using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeConvexHull
{
    public partial class Form1 : Form
    {
        private enum Turn { CLOCKWISE, COUNTER_CLOCKWISE, COLLINEAR };
        private List<Point> pointList;
        private Stack<Point> stackPoints;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pointList = new List<Point>();
            stackPoints = new Stack<Point>();
            pointList.Add(new Point(4, 9));
            pointList.Add(new Point(7, 9));
            pointList.Add(new Point(10, 6));
            pointList.Add(new Point(10, 3));
            pointList.Add(new Point(9, 2));
            pointList.Add(new Point(7, 1));
            pointList.Add(new Point(2, 1));
            pointList.Add(new Point(1, 2));
            pointList.Add(new Point(1, 5));

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            stackPoints= ConvexHull(pointList);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < stackPoints.Count; i++)
            {   
                Point a = stackPoints.ElementAt(i);
                Point b = stackPoints.ElementAt(i);

                System.Drawing.Point p1 = new System.Drawing.Point(a.X, a.Y);
                System.Drawing.Point p2 = new System.Drawing.Point(b.X, b.Y);

                g.DrawLine(new Pen(Color.Red, 3), p1, p2);
            }
        }
        public static int CCW(Point a, Point b, Point c)
        {
            //int difference = ((b.X - a.X) * (c.Y - a.Y)) - ((b.Y - a.Y) * (c.X - a.X));
            int value = ((b.X - a.X) * (c.Y - a.Y)) - ((c.X - a.X) * (b.Y - a.Y));
            return value;
            //if negative, clockwise, positive ccw, 0 linear
        }

        private  Stack<Point> ConvexHull(List<Point> points)
        {

            Stack<Point> hull = new Stack<Point>();
            //pick the large point having the large Y value
            //the sort will short according to the highest y value and lowest x value if they are equal. 
            //Array.Sort(points);
            points.Sort();
            hull.Push(points[0]);
            Point pivot = points[0];
            points.Sort(new PointComparator(pivot));
            //Array.Sort(points, new PointComparator(points[0]));
            hull.Push(points[1]);

            for (int i = 2; i < points.Count; i++)
            {
                Point head = points[i];
                Point middle = hull.Pop();
                Point tail = hull.Peek();
                Turn turn = GetTurn(tail, middle, head);
                switch (turn)
                {
                    case Turn.CLOCKWISE:
  
                        hull.Push(middle);
                        hull.Push(head);
                        break;
                    case Turn.COUNTER_CLOCKWISE:
                        i--;
                        break;
                    case Turn.COLLINEAR:
                        hull.Push(head);
                        break;


                }
            }



            panel1.Refresh();
            return hull;
        }



        private static Turn GetTurn(Point a, Point b, Point c)
        {
            double crossProduct = ((b.X - a.X) * (c.Y - a.Y)) -
                            ((b.Y - a.Y) * (c.X - a.X));
            if (crossProduct > 0)
            {
                return Turn.COUNTER_CLOCKWISE;
            }
            else if (crossProduct < 0)
            {
                return Turn.CLOCKWISE;
            }
            else
            {
                return Turn.COLLINEAR;
            }

        }
        public class PointComparator : IComparer<Point>
        {
            private Point origin;

            public PointComparator(Point origin)
            {
                this.origin = origin;
            }

            public int Compare(Point p1, Point p2)
            {
                //if angle is negative then p1 is les sthan p2 from p0.
                //if positive p2 is less than p1 from p0
                //if 0 then colinear
                double thetaA = Math.Atan2((long)p1.Y - origin.Y, (long)p1.X - origin.X);
                double thetaB = Math.Atan2((long)p2.Y - origin.Y, (long)p2.X - origin.X);
                if (thetaA > thetaB)
                {
                    return -1;
                }
                else if (thetaA < thetaB)
                {
                    return 1;
                }
                else
                {
                    //if colinear, get the shortest one first
                    double distance_to_p1 = Math.Sqrt((((long)origin.X - p1.X) * ((long)origin.X - p1.X)) +
                                   (((long)origin.Y - p1.Y) * ((long)origin.Y - p1.Y)));
                    double distance_to_p2 = Math.Sqrt((((long)origin.X - p2.X) * ((long)origin.X - p2.X)) +
                                                (((long)origin.Y - p2.Y) * ((long)origin.Y - p2.Y)));
                    if (distance_to_p1 < distance_to_p2)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }


            }
        }


        public class Point : IComparable<Point>
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int CompareTo(Point other)
            {
                int y_compare_result = other.Y.CompareTo(Y);
                if (y_compare_result == 0)
                {
                    return X.CompareTo(other.X);
                }
                return y_compare_result;
            }


            public override string ToString()
            {
                return string.Format("{0} {1}", this.X, this.Y);
            }
        }
    }
}