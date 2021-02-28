using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConvexHullGui
{
    class Lib
    {
        public static double SignedArea(Point a, Point b, Point c)
        {
            double result = ((a.X * b.Y) - (b.X * a.Y) + (b.X * c.Y) - (c.X * b.Y) + (c.X * a.Y) - (a.X * c.Y));

            return result;

        }
        public static double GetDistance(Point point1, Point point2)
        {
            double a = (double)(point2.X - point1.X);
            double b = (double)(point2.Y - point1.Y);

            return Math.Sqrt(Math.Pow(a,2)+Math.Pow(b, 2));
        }
    }
}
