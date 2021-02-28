using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvexHullGui
{
    public partial class Form1 : Form
    {
        private List<Point> pointList;
        private List<Point> convexHullPoints;
        private Point lowestLeft;
        private bool complete=false;
     
        public Form1()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen purplePen = new Pen(Color.Purple, 5);
            if (complete == false)
            {
             
                Pen bluePen = new Pen(Color.Green, 3);
                Pen redPen = new Pen(Color.Red, 5);
                foreach (Point p in pointList)
                {
                    DrawPoint(g, bluePen, p);
                }
                DrawPoint(g, redPen, lowestLeft);
                for (int i = 0; i < pointList.Count - 1; i++)
                {

                    g.DrawLine(purplePen, lowestLeft, pointList[i]);
                }

            }
            else
            {
                for (int i = 0; i < convexHullPoints.Count-1; i++)
                {

                    g.DrawLine(purplePen, convexHullPoints[i], convexHullPoints[i +1]);
                }
            }
           
         
        }

        private void DrawPoint(Graphics g, Pen bluePen, Point p)
        {
            g.DrawLine(bluePen, p.X - 5, p.Y, p.X + 5, p.Y);
            g.DrawLine(bluePen, p.X, p.Y - 5, p.X, p.Y + 5);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            pointList.Add(point);
            lowestLeft = FindLowestLeftPoint(pointList);
            panel1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pointList = new List<Point>();
            lowestLeft = new Point();
      
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            convexHullPoints = ConvexHull(pointList);
            complete = true;
            panel1.Refresh();

        }

        private List<Point> ConvexHull(List<Point> pointList)
        {
            convexHullPoints = new List<Point>();
            Point pivot = lowestLeft;
            pointList.Remove(pivot);
            ///need to remove the lowest point
            pointList.Sort(new SortRadial(pivot));
            convexHullPoints.Add(pivot);
            convexHullPoints.Add(pointList[0]); pointList.RemoveAt(0);
            convexHullPoints.Add(pointList[0]); pointList.RemoveAt(0);
            while (pointList.Count> 0)
            {
                convexHullPoints.Add(pointList[0]); pointList.RemoveAt(0);
                while (!Validation(convexHullPoints))
                {
                    convexHullPoints.RemoveAt(convexHullPoints.Count-2);
                }
            }
            convexHullPoints.Add(pivot);
            return convexHullPoints;


        }

        private bool Validation(List<Point> convexHullPoints)
        {
            if (convexHullPoints.Count < 3)
            {
                return false;
            }
            else
            {
                double result = Lib.SignedArea(convexHullPoints[convexHullPoints.Count - 3], convexHullPoints[convexHullPoints.Count - 2], convexHullPoints[convexHullPoints.Count-1]);
                if (result > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }
       

        private Point FindLowestLeftPoint(List<Point> pointList)
        {
       
            Point lowestPoint = pointList.ElementAt(0);
            double pointX = lowestPoint.X;
            double pointY = lowestPoint.Y;
            for (int i = 1; i < pointList.Count; i++)
            {
                if (pointX > pointList.ElementAt(i).X)
                {
                   
                    lowestPoint = pointList.ElementAt(i);
                    pointX = lowestPoint.X;
                    pointY = lowestPoint.Y;

                }
                else if (pointX == pointList.ElementAt(i).X)
                {
                    if (pointY > pointList.ElementAt(i).Y)
                    {
                        lowestPoint = pointList.ElementAt(i);
                    } 
                }
            }
           
            return lowestPoint;
             
        }
    
    }
   //form class 
    public class SortRadial : IComparer<Point>
    {
        private Point pivot;

        public SortRadial(Point pivot)
        {
            this.pivot = pivot;
        }

        public int Compare(Point p1, Point p2)
        {
            double result = Lib.SignedArea(pivot, p1, p2);
      
            if (result == 0)
            {

                return Lib.GetDistance(pivot, p1).CompareTo(Lib.GetDistance(pivot, p2));
 
            }
            return (int)result;
        }
 
    }


    //sort class 
    public static class SortClass
    {
        private static  double MethodTest()
        {
            return 0;
        }

    }
}
