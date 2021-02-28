using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoStoneChain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point[] points = new Point[7];

            //points[0] =new Point(3.5, 1.0);
            //points[1] = new Point(2.0, 6.0);
            //points[2] = new Point(5.0, 9.0);
            //points[3] = new Point(5.0, 8.0);
            //points[4] = new Point(5.0, 3.5);
            //points[5] = new Point(4.0, 1.5);
            //points[6] = new Point(6.0, 10.0);

            List<Point> points = new List<Point>();
            points.Add(new Point(3.5, 1.0));
            points.Add(new Point(2.0, 6.0));
            points.Add(new Point(5.0, 9.0));
            points.Add(new Point(5.0, 8.0));
            points.Add(new Point(5.0, 3.5));
            points.Add(new Point(4.0, 1.5));
            points.Add(new Point(6.0, 10.0));


            List<Point> hull = MonoStoneConvexHull(points);

        }

        private static List<Point> MonoStoneConvexHull(List<Point> points)
        {
            points.Sort();

            if (points.Count <= 3)
            {
                return new List<Point>(points);
            }
            List<Point> upperHull = new List<Point>();
            foreach (Point point in points)
            {
                Point p2 = point;
                while (upperHull.Count >= 2 )
                {
                   
                    Point pivot = upperHull[upperHull.Count - 2];
                    Point p1 = upperHull[upperHull.Count - 1];

                    if (crossProduct(pivot, p1, p2) <= 0)
                    {
                        upperHull.RemoveAt(upperHull.Count - 1);
                    }
                    else
                    {
                        break;
                    }
                    
                  
                }
                upperHull.Add(p2);
            }
            upperHull.RemoveAt(upperHull.Count - 1);


            List<Point> lowerHull = new List<Point>();
            for (int i = points.Count - 1; i >= 0; i--)
            {
                Point p2 = points[i];
                while (lowerHull.Count >= 2)
                {
                    Point pivot = lowerHull[lowerHull.Count - 2];
                    Point p1 = lowerHull[lowerHull.Count - 1];
                  
               
                    if (crossProduct(pivot, p1, p2) <= 0)
                    {
                        lowerHull.RemoveAt(lowerHull.Count - 1);
                    }
                    else
                    {
                        break;
                    }


                }
                lowerHull.Add(p2);
            }
            lowerHull.RemoveAt(lowerHull.Count - 1);
            if (!(Enumerable.SequenceEqual(upperHull, lowerHull)))
            {
                upperHull.AddRange(lowerHull);

            }
            return upperHull;

             

        }

        private static double crossProduct(Point point1, Point point2, Point point3)
        {
            return (point2.X - point1.X) * (long)(point3.Y - point1.Y) - (point2.Y - point1.Y) * (long)(point3.X - point1.X);
        }
        class Point : IComparable<Point>
        {
            public double Y { get; set; }
            public double X { get; set; }
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public int CompareTo(Point other)
            {
                if (this.X < other.X)
                {
                    return -1;
                }
                else if (this.X > other.X)
                {
                    return 1;
                }
                else
                {
                    if (this.Y < other.Y)
                    {
                        return -1;
                    }
                    else if (this.Y > other.Y)
                    {
                        return 1;
                    }
                    return 0;
                }

            }
        }
    }


}
