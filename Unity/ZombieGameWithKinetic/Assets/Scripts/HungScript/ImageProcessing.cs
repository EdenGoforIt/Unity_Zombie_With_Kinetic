using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using UnityEngine;

namespace Assets.Scripts
{
    class ImageProcessing
    {
        public VectorOfVectorOfPoint getContours(Image<Gray, byte> emguImage, int minContourSize, int maxContourSize)
        {
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(emguImage, contours, hierarchy, Emgu.CV.CvEnum.RetrType.Ccomp, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            VectorOfVectorOfPoint result = new VectorOfVectorOfPoint();
            int contCount = contours.Size;
            for (int i = 0; i < contCount; i++)
            {
                using (VectorOfPoint contour = contours[i])
                {
                    double contourSize = CvInvoke.ContourArea(contour);
                    if (contourSize >= minContourSize && contourSize <= maxContourSize)
                    {
                        result.Push(contour);
                    }
                }
            }
            return result;
        }

        public VectorOfPoint getConvexHulls(VectorOfPoint contour)
        {
            
            VectorOfPoint hulls = new VectorOfPoint();
            VectorOfPoint rhulls = new VectorOfPoint();
            CvInvoke.ConvexHull(contour, hulls, true);
            return hulls;
        }

        public VectorOfInt getConvexHullIns(VectorOfPoint contour)
        {
            VectorOfInt hullIns = new VectorOfInt();
            CvInvoke.ConvexHull(contour, hullIns, false, false);
            return hullIns;
        }

        public Mat getDefects(VectorOfPoint contour, VectorOfInt hullIns)
        {
            Mat defects = new Mat();
            if (hullIns.Size > 3)
            {
                CvInvoke.ConvexityDefects(contour, hullIns, defects);
            }
            return defects;
        }

        public List<FingerTip> getFingerTips(VectorOfPoint contour, Mat defects, Point handCenter)
        {
            List<FingerTip> result = new List<FingerTip>();
            if (!defects.IsEmpty)
            {
                Matrix<int> m = new Matrix<int>(defects.Rows, defects.Cols, defects.NumberOfChannels);
                defects.CopyTo(m);

                for (int i = 0; i < m.Rows; i++)
                {
                    int startIndex = m.Data[i, 0];
                    int endIndex = m.Data[i, 1];
                    int farIndex = m.Data[i, 2];
                    //int distance = m.Data[i, 3];
                    //bool distanceTooSmall = distance < 3000;

                    Point start = contour[startIndex];
                    Point end = contour[endIndex];
                    Point farPoint = contour[farIndex];

                    double l1 = distanceBetween(farPoint, start);
                    double l2 = distanceBetween(farPoint, end);
                    double dot = (start.X - farPoint.X) * (end.X - farPoint.X) + (start.Y - farPoint.Y) * (end.Y - farPoint.Y);
                    double angle = Math.Acos(dot / (l1 * l2));
                    angle = angle * 180 / Math.PI;
                    
                    if (angle < 90)
                    {
                        if (result.Count == 0)
                        {
                            int distanceFromCenter = (int)distanceBetween(start, handCenter);
                            result.Add(new FingerTip() { id = 0, position = start, farPoints = new List<Point>() { farPoint }, distanceFromCenter = distanceFromCenter });
                        }
                        for (int j = 0; j < result.Count; j++)
                        {
                            FingerTip ftip = result.Find(f => distanceBetween(f.position, end) < 20);
                            if (ftip == null)
                            {
                                int distanceFromCenter = (int)distanceBetween(start, handCenter);
                                result.Add(new FingerTip() { id = result.Count - 1, position = end, farPoints = new List<Point>() { farPoint }, distanceFromCenter = distanceFromCenter, previousFinger = result[result.Count - 1] });
                            }
                            else
                            {
                                if (ftip.farPoints.Count < 2)
                                {
                                    ftip.farPoints.Add(farPoint);
                                }
                            }
                        }
                    }
                }
            }

            if (result.Count == 0)
            {
                // find 1 finger case
                VectorOfPoint hull = getConvexHulls(contour);
                int maxThreshold = 60;
                for (int i = 0; i < hull.Size; i++)
                {
                    if (distanceBetween(hull[i], handCenter) > maxThreshold)
                    {
                        int distanceFromCenter = (int)distanceBetween(hull[i], handCenter);
                        result.Add(new FingerTip() { id = 0, position = hull[i], distanceFromCenter = distanceFromCenter });
                    }
                }
                if (result.Count > 1)
                {
                    result = new List<FingerTip>() { result[result.Count / 2] };
                }
                
            }

            return result.Take(5).ToList();
        }

        
        public double distanceBetween (Point pt1, Point pt2)
        {
            return Math.Sqrt(Math.Pow(pt2.X - pt1.X, 2) + Math.Pow(pt2.Y - pt1.Y, 2));
        }

        public Point centerBetween (Point pt1, Point pt2)
        {
            return new Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
        }
        
        public Point getHandCenter (VectorOfPoint contour)
        {
            Moments moment = CvInvoke.Moments(contour, true);
            return new Point((int)(moment.M10 / moment.M00), (int)(moment.M01 / moment.M00));
        }

        public List<Hand> getHands(Image<Gray, byte> image)
        {
            VectorOfVectorOfPoint contours = getContours(image, 3000, 9000);
            List<Hand> results = new List<Hand>();
            int contCount = contours.Size;
            for (int i = 0; i < contCount; i++)
            {
                using (VectorOfPoint contour = contours[i])
                {
                    VectorOfPoint hulls = getConvexHulls(contour);
                    VectorOfInt hullIns = getConvexHullIns(contour);
                    Mat defects = getDefects(contour, hullIns);
                    Point handCenter = getHandCenter(contour);
                    List<FingerTip> tipData = getFingerTips(contour, defects, handCenter);

                    Hand hand = new Hand() { numOfFingers=tipData.Count, fingers=tipData, handCenter=handCenter };
                    results.Add(hand);
                }
            }

            return results;
        }
    }
}
