using System;
using System.Collections.Generic;
using System.Linq;

namespace HerdingFrost
{
    class Program
    {
        private enum Turn { CLOCKWISE, COUNTER_CLOCKWISE, COLLINEAR };

        public class Answer
        {
            public int Case_Num { get; set; }
            public Stack<Point> Hull_Points { get; set; }
            public double Distance { get; set; }

            public Answer(int case_num, Stack<Point> hull_point, double distance)
            {
                this.Case_Num = case_num;
                this.Hull_Points = hull_point;
                this.Distance = distance;
            }

        }
        static void Main(string[] args)
        {


            List<Point> points;

            List<Answer> answer_list = new List<Answer>();
            int case_num = Convert.ToInt32(Console.ReadLine());
        
            Stack<Point> hull ;
            while ((case_num--) != 0)
            {
                //string skip = Console.ReadLine();
                points = new List<Point>();

                double extra_distance = 0;
                hull = new Stack<Point>();
               


                int point_number = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < point_number; i++)
                {
                    string[] x_y = Console.ReadLine().Split(" ");
                    double x = Convert.ToDouble(x_y[0]);
                    double y = Convert.ToDouble(x_y[1]);
                    Point p = new Point(x, y);
                    points.Add(p);
                }
              
                hull = ConvexHull(points);
                Point zero = new Point(0, 0);
                Point first = hull.ElementAt(0);
                extra_distance = Euclidean_Distance(zero, first);
                Answer answer = new Answer(case_num, hull, extra_distance*2);
                answer_list.Add(answer);
              
            }
            foreach (Answer ans in answer_list)
            {
                double total = 0;
                for (int i = 0; i < ans.Hull_Points.Count - 1; i++)
                {
                    Point first_point = ans.Hull_Points.ElementAt(i);
                    Point second_point = ans.Hull_Points.ElementAt(i + 1);
                    total += Euclidean_Distance(first_point, second_point);
                    //Point zerozero = new Point(0, 0);
                    //Point comparing = hull.ElementAt(i);
                    //double value = Euclidean_Distance(zerozero, comparing);
                    //if (value < smallest)
                    //{
                    //    smallest = value;
                    //}

                }
                Console.WriteLine(Math.Round(total + 2 + ans.Distance, 2, MidpointRounding.AwayFromZero));

            }
         
          
        }

     

        private static double Euclidean_Distance(Point first_point, Point second_point)
        {
            return Math.Sqrt(Math.Pow(first_point.X - second_point.X, 2)+ Math.Pow(first_point.Y - second_point.Y,2));
        }

        private static Stack<Point> ConvexHull(List<Point> points)
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
                    case Turn.COUNTER_CLOCKWISE:
                        hull.Push(middle);
                        hull.Push(head);
                        break;
                    case Turn.CLOCKWISE:
                        i--;
                        break;
                    case Turn.COLLINEAR:
                        hull.Push(head);
                        break;


                }
            }

            hull.Push(pivot);
            return hull;
        }
        private static int CrossProduct(Point a, Point b, Point c)
        {
            double crossProduct = ((b.X - a.X) * (c.Y - a.Y)) -
                           ((b.Y - a.Y) * (c.X - a.X));
            if (crossProduct > 0)
            {
                //anticlockwise
                return -1;
            }
            else if (crossProduct < 0)
            {
                //clockwise
                return 1;
            }
            else {
                return 0;
            }

        }

        private static Turn GetTurn(Point a, Point b, Point c)
        {
            double crossProduct = CrossProduct( a,  b,  c);
            if (crossProduct < 0)
            {
                return Turn.COUNTER_CLOCKWISE;
            }
            else if (crossProduct > 0)
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
            private Point pivot;

            public PointComparator(Point origin)
            {
                this.pivot = origin;
            }

            public int Compare(Point p1, Point p2)
            {
                //if angle is negative then p1 is les sthan p2 from p0.
                //if positive p2 is less than p1 from p0
                //if 0 then colinear
                //if colinear, get the shortest one first 
                int result = CrossProduct(pivot, p1, p2);
                if (result < 0)
                {
                    return -1;
                }
                else if (result > 0)
                {
                    return 1;
                }
                else {
                    double distance_to_p1 = Math.Sqrt((((double)pivot.X - p1.X) * ((double)pivot.X - p1.X)) +
                                 (((double)pivot.Y - p1.Y) * ((double)pivot.Y - p1.Y)));
                    double distance_to_p2 = Math.Sqrt((((double)pivot.X - p2.X) * ((double)pivot.X - p2.X)) +
                                                (((double)pivot.Y - p2.Y) * ((double)pivot.Y - p2.Y)));
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
                //int y_compare_result = other.Y.CompareTo(other.Y);
                //if (y_compare_result == 0)
                //{
                //    return X.CompareTo(other.X);
                //}
                //return y_compare_result;

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
