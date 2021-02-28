using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public enum HandShape {
        UNKNOWN,
        FIST,
        OPEN,
        GUN,
        V,
        W,
        FOUR,
        POINT
    }

    public enum HandGesture {
        UNKNOWN,
        CUTTING,
        WAVING
    }
    class Hand
    {
        public int numOfFingers { get; set; }
        public List<FingerTip> fingers { get; set; }

        public Point handCenter { get; set; }

        public HandShape GetHandShape()
        {
            if (numOfFingers == 4)
            {
                return HandShape.FOUR;
            } else if (numOfFingers == 2)
            {
                FingerTip tip2 = fingers[0].previousFinger != null ? fingers[0] : fingers[1];
                FingerTip tip1 = tip2.previousFinger;
                Point farPoint = tip1.farPoints[0];
                double l1 = distanceBetween(farPoint, tip1.position);
                double l2 = distanceBetween(farPoint, tip2.position);
                double dot = (tip1.position.X - farPoint.X) * (tip2.position.X - farPoint.X) + (tip1.position.Y - farPoint.Y) * (tip2.position.Y - farPoint.Y);
                double angle = Math.Acos(dot / (l1 * l2));
                angle = angle * 180 / Math.PI;
                if (angle > 75)
                {
                    return HandShape.GUN;
                } else if (distanceBetween(fingers[0].position, fingers[1].position) < 40)
                {
                    return HandShape.V;
                }
            } else if (numOfFingers == 3 && DistanceBetweenAllFingersLessThan(40))
            {
                return HandShape.W;
            } else if (numOfFingers == 0)
            {
                return HandShape.FIST;
            } else if (numOfFingers == 5)
            {
                return HandShape.OPEN;
            }
            else if (numOfFingers == 1)
            {
                return HandShape.POINT;
            }
            return HandShape.UNKNOWN;
        }

        private double distanceBetween(Point pt1, Point pt2)
        {
            return Math.Sqrt(Math.Pow(pt2.X - pt1.X, 2) + Math.Pow(pt2.Y - pt1.Y, 2));
        }

        private bool DistanceBetweenAllFingersLessThan(int amount)
        {
            for (int i = 0; i < fingers.Count - 1; i++)
            {
                FingerTip tip = fingers[i];
                FingerTip tip2 = fingers[i + 1];
                if(distanceBetween(tip.position, tip2.position) > amount)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
