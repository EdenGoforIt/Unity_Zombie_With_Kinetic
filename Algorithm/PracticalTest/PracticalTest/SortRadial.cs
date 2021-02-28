using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTest
{
    public class SortRadial : IComparer<Point>
    {
        Point pivot;
        public SortRadial(Point p)
        {
            pivot = p;
        }
        public int Compare(Point a, Point b)
        {
            double SA = Calculation.SignedArea(pivot, a, b);
            if (SA == 0)
            {
                return Calculation.Distance(pivot, a).CompareTo(Calculation.Distance(pivot, b));
         

            }
            else if (SA > 0)
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
