using System;
using System.Collections.Generic;

namespace FIndtheLowestDraw
{
    class Program
    {

        class Point:IComparable<Point>
        {
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double X { get; set; }
            public double Y { get; set; }

            public int CompareTo(Point other)
            {
                int compare = this.X.CompareTo(other.X);
                if (compare > 0)
                {
                    return 1;
                }
                else if (compare < 0)
                {
                    return -1;
                }
                else
                {
                    return this.Y.CompareTo(other.Y);
                }
            }
        }
        static void Main(string[] args)
        {
            List<Point> pointList = new List<Point>();
            pointList.Add(new Point(3.5, 1.0));
            pointList.Add(new Point(2.0, 6.0));
            pointList.Add(new Point(5.0, 9.0));
            pointList.Add(new Point(5.0, 8.0));
            pointList.Add(new Point(5.0, 3.5));
            pointList.Add(new Point(4.0, 1.5));
            pointList.Sort();

            Point lowestLeft = pointList[0];
            pointList = RemoveDuplicateFindLowest(pointList);

        }

        private static List<Point> RemoveDuplicateFindLowest(List<Point> pointList)
        {
            Point comparingPoint = new Point(0, 0);
            List<Point> withoutDuplicates = new List<Point>();
            foreach (Point p in pointList)
            {
                if (!p.Equals(comparingPoint))
                {
                    withoutDuplicates.Add(p);
                    comparingPoint = p;
                }
            }
            return withoutDuplicates;
        }
    }
}
