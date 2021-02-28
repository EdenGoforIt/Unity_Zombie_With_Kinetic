using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingJsonEden
{
    class SortRadial : IComparer<PlaceOfInterest>
    {
        PlaceOfInterest _pivot;

        public SortRadial(PlaceOfInterest pivot)
        {
            this._pivot = pivot;
        }
  
        public int Compare(PlaceOfInterest p1, PlaceOfInterest p2)
        {

            double SA = Calculation.SignedArea(_pivot, p1, p2);
            if (SA == 0)
            {
                return Calculation.PythagorasDistance(_pivot, p1).CompareTo(Calculation.PythagorasDistance(_pivot, p2));
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
