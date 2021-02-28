using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingJsonEden
{
    public class SEC
    {
        public static PlaceOfInterest centerPoint;
        public static double radius;
        public static PlaceOfInterest pointOne;
        public static PlaceOfInterest pointTwo;
        public static PlaceOfInterest pointThree;
        public static void SmallestEnclosingCircle(List<PlaceOfInterest> hull)
        {

            FindSmallestAngle(hull[0], hull[1], hull);
            //PlaceOfInterest p = centerPoint;
            //double dia = diameter;
            //double a = 0;
        }
     

        private static void FindSmallestAngle(PlaceOfInterest p1, PlaceOfInterest p2, List<PlaceOfInterest> hullPoints)
        {
            PlaceOfInterest k = null;
            foreach (PlaceOfInterest p in hullPoints)
            {
                if (p != p1 && p != p2)
                {
                    k = p;
                    break;
                }
            }

            double angle =  Calculation.CalculateAngle(p1, k, p2);

            foreach (PlaceOfInterest h in hullPoints)
            {
                if (!h.Equals(p1) && !h.Equals(p2) && !h.Equals(k) && angle > Calculation.CalculateAngle(p1, h, p2))
                {
                    k = h;
                    angle = Calculation.CalculateAngle(p1, k, p2);
                }
            }

            if (angle >= 90)
            {

                centerPoint = new PlaceOfInterest(1, (p1.Latitude + p2.Latitude )/ 2, (p1.Longitude + p2.Longitude) / 2, "");
                radius = Calculation.PythagorasDistance(centerPoint, p1);
                pointOne = p1; pointTwo = k; pointThree = p2;
            }
   
            else if (angle < 90 && Calculation.CalculateAngle(p1, p2, k) < 90 && Calculation.CalculateAngle(p2, p1, k) < 90)
            {
                //define the circle
                centerPoint = Calculation.FindTheCenterPoint(p1, k, p2);
                radius = Calculation.PythagorasDistance(centerPoint, p2);
                pointOne = p1; pointTwo = k; pointThree = p2;
            }
            else if (Calculation.CalculateAngle(p1, p2, k) > 90)
            {
                FindSmallestAngle(p1, k, hullPoints);
            }
            else if (Calculation.CalculateAngle(p2, p1, k) > 90)
            {
                FindSmallestAngle(p2, k, hullPoints);
            }

        }
    }
}
