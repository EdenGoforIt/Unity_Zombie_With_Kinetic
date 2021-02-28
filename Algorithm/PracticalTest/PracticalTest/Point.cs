using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTest
{
    public class Point:IComparable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;

        }

        public int CompareTo(Point other)
        {
            double com = this.X.CompareTo(other.X);
            if (com == 0)
            {
                return this.Y.CompareTo(other.Y);
            }
            return (int)com;


        }
        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            Point cp = obj as Point;
            return cp.X == this.X && cp.Y == this.Y;
        }

        public override int GetHashCode()
        {
            return (X + Y).GetHashCode();
        }

    }
}
