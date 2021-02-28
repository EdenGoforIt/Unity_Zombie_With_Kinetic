using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingJsonEden
{
    public class Calculation
    {
        public static double SignedArea(PlaceOfInterest a, PlaceOfInterest b, PlaceOfInterest c)
        {
            return ((a.Latitude * b.Longitude) - (b.Latitude * a.Longitude) + (b.Latitude * c.Longitude) - (c.Latitude * b.Longitude) + (c.Latitude * a.Longitude) - (a.Latitude * c.Longitude));
        }
        public static double PythagorasDistance(PlaceOfInterest p1, PlaceOfInterest p2)
        {
            return Math.Sqrt(Math.Pow(p2.Latitude - p1.Latitude, 2) + Math.Pow(p2.Longitude - p1.Longitude, 2));
        }
        public static double CalculateAngle(PlaceOfInterest a, PlaceOfInterest b, PlaceOfInterest c)
        {
            double bc = PythagorasDistance(b, c);
            double ac = PythagorasDistance(a, c);
            double ab = PythagorasDistance(b, a);

            return Math.Acos((Math.Pow(bc, 2) - Math.Pow(ac, 2) + Math.Pow(ab, 2)) / (2 * bc * ab)) * 180 / Math.PI;
            //double a = Math.Pow(p2.Latitude - p1.Latitude, 2) + Math.Pow(p2.Longitude - p1.Longitude, 2);
            //double b = Math.Pow(p2.Latitude - p3.Latitude, 2) + Math.Pow(p2.Longitude - p3.Longitude, 2);
            //double c = Math.Pow(p3.Latitude - p1.Latitude, 2) + Math.Pow(p3.Longitude - p1.Longitude, 2);
            //return Math.Acos((a + b - c) / Math.Sqrt(4 * a * b));
        }




     

        public static PlaceOfInterest FindTheCenterPoint(PlaceOfInterest pt1, PlaceOfInterest pt2, PlaceOfInterest pt3)
        {
            double A1, A2, B1, B2, C1, C2, temp;
            A1 = pt1.Longitude - pt2.Longitude;
            B1 = pt1.Latitude - pt2.Latitude;
            C1 = (Math.Pow(pt1.Longitude, 2) - Math.Pow(pt2.Longitude, 2) + Math.Pow(pt1.Latitude, 2) - Math.Pow(pt2.Latitude, 2)) / 2;
            A2 = pt3.Longitude - pt2.Longitude;
            B2 = pt3.Latitude - pt2.Latitude;
            C2 = (Math.Pow(pt3.Longitude, 2) - Math.Pow(pt2.Longitude, 2) + Math.Pow(pt3.Latitude, 2) - Math.Pow(pt2.Latitude, 2)) / 2;

            temp = A1 * B2 - A2 * B1;

            PlaceOfInterest PC;

            if (temp == 0)
            {
                PC = new PlaceOfInterest(0, pt1.Latitude, pt1.Longitude, "circle centre");
            }
            else
            {
                PC = new PlaceOfInterest(0, (A1 * C2 - A2 * C1) / temp, (C1 * B2 - C2 * B1) / temp, "circle centre");
            }
            return PC;

        }
    }
}
