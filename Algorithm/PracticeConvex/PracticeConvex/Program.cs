using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeConvex
{
    class Program
    {
        private enum Turn { CLOCKWISE, COUNTER_CLOCKWISE, COLLINEAR };


        static void Main(string[] args)
        {


            List<Point> points;

            List<double> answer_list = new List<double>();
            int case_num = Convert.ToInt32(Console.ReadLine());

            List<Point> hull;
            while ((case_num--) != 0)
            {
                //string skip = Console.ReadLine();
                points = new List<Point>();
                hull = new List<Point>();
                int point_number = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < point_number; i++)
                {
                    string[] x_y = Console.ReadLine().Split(" ");
                    double x = Convert.ToDouble(x_y[0]);
                    double y = Convert.ToDouble(x_y[1]);
                    Point p = new Point(x, y);
                    points.Add(p);
                }

                answer_list = ConvexHull(points, answer_list);

            }
            foreach (double answer in answer_list)
            {
                Console.WriteLine(answer);
            }

        }

        private static double Euclidean_Distance(Point first_point, Point second_point)
        {
            return Math.Sqrt(Math.Pow(first_point.X - second_point.X, 2) + Math.Pow(first_point.Y - second_point.Y, 2));
        }

        private static List<double> ConvexHull(List<Point> points, List<double> answer_list)
        {

            List<Point> hull = new List<Point>();
            //pick the large point having the large Y value
            //the sort will short according to the highest y value and lowest x value if they are equal. 
            //Array.Sort(points);
            points.Sort();
            Point pivot = points[0];

            hull.Add(pivot);
            points.RemoveAt(0);

            points.Sort(new PointComparator(pivot));
            //Array.Sort(points, new PointComparator(points[0]));
            hull.Add(points[0]);
            points.RemoveAt(0);

            hull.Add(points[0]);
            points.RemoveAt(0);

            while (points.Count > 0)
            {
                hull.Add(points[0]);
                points.RemoveAt(0);
                while (!Validate(hull))
                {
                    hull.RemoveAt(1);

                }
            }
            hull.Add(pivot);
            double total = 0;
            
                for (int i = 0; i < hull.Count - 1; i++)
                {
                    Point first_point = hull[i];
                    Point second_point = hull[i + 1];
                    total += Euclidean_Distance(first_point, second_point);
                }
            


            Point zero = new Point(0, 0);
            Point first = hull.ElementAt(0);
            double extra_distance = Euclidean_Distance(zero, first)*2;
            total = Math.Round(total + 2 + extra_distance, 2, MidpointRounding.AwayFromZero);
         

            answer_list.Add(total);
            return answer_list;

        }

        private static bool Validate(List<Point> hull)
        {
            if (hull.Count > 3 && CrossProduct(hull[0], hull[1], hull[2]) == Turn.COUNTER_CLOCKWISE)
            {
                return true;
            }
            return false;
        }

        private static Turn CrossProduct(Point a, Point b, Point c)
        {
            double crossProduct = ((b.X - a.X) * (c.Y - a.Y)) -
                           ((b.Y - a.Y) * (c.X - a.X));
            if (crossProduct > 0)
            {

                return Turn.COUNTER_CLOCKWISE;
            }
            else if (crossProduct < 0)
            {
                //clockwise
                return Turn.CLOCKWISE;
            }
            else
            {
                return Turn.COLLINEAR;
            }

        }

        public class PointComparator : IComparer<Point>
        {
            private Point pivot;

            public PointComparator(Point origin)
            {
                this.pivot = origin;
            }

            public int Compare(Point p1, Point p2)
            {
                Turn result = CrossProduct(pivot, p1, p2);
                if (result == Turn.COUNTER_CLOCKWISE)
                {
                    return -1;
                }
                else if (result == Turn.CLOCKWISE)
                {
                    return 1;
                }
                else
                {
                    double distance_to_p1 = Euclidean_Distance(pivot, p1);
                    double distance_to_p2 = Euclidean_Distance(pivot, p2);

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
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public int CompareTo(Point other)
            {

                int x_compare_result = this.X.CompareTo(other.X);
                if (x_compare_result == 0)
                {
                    return this.Y.CompareTo(other.Y);
                }
                return x_compare_result;
            }


            public override string ToString()
            {
                return string.Format("{0} {1}", this.X, this.Y);
            }
        }
    }
}


