using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTest
{
    public class Calculation
    {
        public static double SignedArea(Point a, Point b, Point c)
        {
            return (a.X*b.Y) - (b.X*a.Y) + (b.X*c.Y) - (c.X*b.Y) + (c.X*a.Y) - (a.X*c.Y);

         //   return ((b.X - a.X)*(c.Y - a.Y) - (b.Y-a.Y )*(c.X -a.X ));
        }
        public static double Distance(Point a, Point b)
        {
            double xDis = b.X - a.X;
            double yDis = b.Y - a.Y;
            //return Math.Sqrt(xDis*xDis+ yDis*yDis);
            return xDis*xDis + yDis*yDis;

        }

    }
}
