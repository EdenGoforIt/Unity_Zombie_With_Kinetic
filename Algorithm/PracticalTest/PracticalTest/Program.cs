using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalTest
{
    class Program
    {

        static void Main(string[] args)
        {

            List<Point> pointlist = new List<Point>();
            List<Point> hullPoint;
            HashSet<Point> initialSet = new HashSet<Point>();
            int pointNum = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < pointNum; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                double x = Convert.ToInt32(line[0]);
                double y = Convert.ToInt32(line[1]);
                Point p = new Point(x, y);
                initialSet.Add(p);
            }
            pointlist = initialSet.ToList();
            hullPoint = ConvexHull(pointlist);
            foreach (Point p in hullPoint)
            {
                Console.WriteLine("({0},{1})", p.X, p.Y);
            }

        }

        private static List<Point> ConvexHull(List<Point> pointlist)
        {
            List<Point> hull = new List<Point>();
            pointlist.Sort();
            Point pivot = pointlist[0];
            pointlist.RemoveAt(0);
            pointlist.Sort(new SortRadial(pivot));
            hull.Add(pivot);
            hull.Add(pointlist[0]); pointlist.RemoveAt(0);

            while (pointlist.Count > 0)
            {
                hull.Add(pointlist[0]); pointlist.RemoveAt(0);
                while (!ValidateHull(hull))
                {
                    hull.RemoveAt(hull.Count - 2);
                }
            }
            hull.Add(pivot);
            return hull;

        }
        public static bool ValidateHull(List<Point> hull)
        {
            if (hull.Count < 3)
            {
                return true;
            }
            double SA = Calculation.SignedArea(hull[hull.Count - 3], hull[hull.Count - 2], hull[hull.Count - 1]);
            return (SA > 0);


        }
    }
}
