using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public enum fingerTipType
    {
        THUMB,
        INDEX,
        MIDDLE,
        RING,
        PINKY
    }
    class FingerTip
    {
        public int id { get; set; }

        public Point position { get; set; }
        public List<Point> farPoints { get; set; }

        public FingerTip previousFinger { get; set; }

        public fingerTipType fingerType { get; set; }

        public int distanceFromCenter { get; set; }
    }
}
