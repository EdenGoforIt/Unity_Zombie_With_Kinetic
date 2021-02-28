using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingJsonEden
{
    class ConvexHull
    {
        public static List<PlaceOfInterest> GrahmConvexHull(List<PlaceOfInterest> pointList)
        {
            List<PlaceOfInterest> hull = new List<PlaceOfInterest>();
           List<PlaceOfInterest> noDuplicates = RemoveDuplicate(pointList);
            noDuplicates.Sort();
            PlaceOfInterest pivot = noDuplicates[0];
            noDuplicates.RemoveAt(0);
            noDuplicates.Sort(new SortRadial(pivot));

            hull.Add(pivot);
            hull.Add(noDuplicates[0]); noDuplicates.RemoveAt(0);
            hull.Add(noDuplicates[0]); noDuplicates.RemoveAt(0);
            while (noDuplicates.Count > 0)
            {
                hull.Add(noDuplicates[0]); noDuplicates.RemoveAt(0);
                while (!Validate(hull))
                {
                    hull.RemoveAt(hull.Count - 2);
                }
            }
            hull.Add(pivot);
            return hull;
        }

        public static List<PlaceOfInterest> MonoStoneConvexHull(List<PlaceOfInterest> points)
        {
            points.Sort();
            if (points.Count <= 3)
            {
                return new List<PlaceOfInterest>(points);
            }
            List<PlaceOfInterest> upperHull = new List<PlaceOfInterest>();
            foreach (PlaceOfInterest point in points)
            {
                PlaceOfInterest p2 = point;
                while (upperHull.Count >= 2)
                {
                    PlaceOfInterest pivot = upperHull[upperHull.Count - 2];
                    PlaceOfInterest p1 = upperHull[upperHull.Count - 1];

                    if (Calculation.SignedArea(pivot, p1, p2) <= 0)
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
            List<PlaceOfInterest> lowerHull = new List<PlaceOfInterest>();
            for (int i = points.Count - 1; i >= 0; i--)
            {
                PlaceOfInterest p2 = points[i];
                while (lowerHull.Count >= 2)
                {
                    PlaceOfInterest pivot = lowerHull[lowerHull.Count - 2];
                    PlaceOfInterest p1 = lowerHull[lowerHull.Count - 1];
                    if (Calculation.SignedArea(pivot, p1, p2) <= 0)
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
        public static bool Validate(List<PlaceOfInterest> hull)
        {
            if (hull.Count < 3)
            {
                return false;
            }
            else
            {
                double SA = Calculation.SignedArea(hull[hull.Count - 3], hull[hull.Count - 2], hull[hull.Count - 1]);
                if (SA > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public static List<PlaceOfInterest> RemoveDuplicate(List<PlaceOfInterest> pointList)
        {
            List<PlaceOfInterest> noDuplicate = new List<PlaceOfInterest>();
         
            PlaceOfInterest compareValue = new PlaceOfInterest(0, 0, 0, "");
            foreach (PlaceOfInterest poi in pointList.ToList())
            {
                if (!poi.Equals(compareValue))
                {
                    noDuplicate.Add(poi);
                    compareValue = poi;
                }
            }
            return noDuplicate;
        }




    }
}
