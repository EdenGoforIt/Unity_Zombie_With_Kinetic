using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConvexHullOfLatticePoints
{
    class Program
    {
        private enum Turn { CLOCKWISE, COUNTER_CLOCKWISE, COLLINEAR };

        static List<int> GetNums(string line)
        {
            
            List<int> list = new List<int>();
            string[] tokens = line.Split(' ');
            foreach (string token in tokens)
            {
                list.Add(int.Parse(token));
            }
            return list;
        }

        public class Answer
        {
            public int Set_number { get; set; }
            public Stack<Point> Hull_Points { get; set; }

            public Answer(int set_number, Stack<Point> hull_point)
            {
                this.Set_number = set_number;
                this.Hull_Points = hull_point;
            }

        }
        static void Main(string[] args)
        {
            List<int> nums;

            List<Point> points;

            List<Answer> answer_list = new List<Answer>();
            int case_num = Convert.ToInt32(Console.ReadLine());
             
            while ((case_num--) != 0)
            {
                string[] first_line = Console.ReadLine().Split();
                int data_set_number = Convert.ToInt32(first_line[0]);
                int number_of_points = Convert.ToInt32(first_line[1]);
                points = new List<Point>();
                int count = 0;
                string second_line = Console.ReadLine();
                nums = GetNums(second_line);

                while (true)
                {
                    for (int i = 0; i <= nums.Count - 2; i += 2)
                    {
                        int x = i;
                        int y = i + 1;
                        Point p = new Point(nums[x], nums[y]);
                        points.Add(p);

                        count++;
                    }
                    if (count == number_of_points)
                    {
                        break;
                    }
                    second_line = Console.ReadLine();
                    if (second_line == "")
                    {
                        break;
                    }
                    else
                    {
                        nums = GetNums(second_line);
                    }
            
                }
                Stack<Point> hull = ConvexHull(points);
                Answer answer = new Answer(data_set_number, hull);
                answer_list.Add(answer);

            }
            foreach (Answer ans in answer_list)
            {
                Console.WriteLine("{0} {1}", ans.Set_number, ans.Hull_Points.Count);
                for (int i=ans.Hull_Points.Count-1; i >= 0; i--)
                {
                    Console.WriteLine("{0} {1}", ans.Hull_Points.ElementAt(i).X, ans.Hull_Points.ElementAt(i).Y);
                }
            }

        }

        public static int CCW(Point a, Point b, Point c)
        {
            //int difference = ((b.X - a.X) * (c.Y - a.Y)) - ((b.Y - a.Y) * (c.X - a.X));
            int value = ((b.X - a.X) * (c.Y - a.Y)) - ((c.X - a.X) * (b.Y - a.Y));
            return value;
            //if negative, clockwise, positive ccw, 0 linear
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
