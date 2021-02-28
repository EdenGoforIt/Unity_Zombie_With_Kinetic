using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class TextureExtenion
    {
        public static Texture2D Circle(this Texture2D tex, int cx, int cy, int r, UnityEngine.Color color)
        {
            var y = r;
            var d = 1 / 4 - r;
            var end = Mathf.Ceil(r / Mathf.Sqrt(2));

            for (int x = 0; x <= end; x++)
            {
                tex.SetPixel(cx + x, cy + y, color);
                tex.SetPixel(cx + x, cy - y, color);
                tex.SetPixel(cx - x, cy + y, color);
                tex.SetPixel(cx - x, cy - y, color);
                tex.SetPixel(cx + y, cy + x, color);
                tex.SetPixel(cx - y, cy + x, color);
                tex.SetPixel(cx + y, cy - x, color);
                tex.SetPixel(cx - y, cy - x, color);

                d += 2 * x + 1;
                if (d > 0)
                {
                    d += 2 - 2 * y--;
                }
            }

            return tex;
        }

        public static Texture2D Rect(this Texture2D tex, Rect rect, UnityEngine.Color color)
        {
            Point pt1 = new Point((int)rect.x, (int)rect.y);
            Point pt2 = new Point((int)(rect.x + rect.width), (int)rect.y);
            Point pt3 = new Point((int)rect.x, (int)(rect.y + rect.height));
            Point pt4 = new Point((int)(rect.x + rect.width), (int)(rect.y + rect.height));
            tex.Line(pt1, pt2, color);
            tex.Line(pt2, pt4, color);
            tex.Line(pt4, pt3, color);
            tex.Line(pt3, pt1, color);
            return tex;
        }

        public static Texture2D Rect(this Texture2D tex, Rectangle rect, UnityEngine.Color color)
        {
            Point pt1 = new Point((int)rect.X, (int)rect.Y);
            Point pt2 = new Point((int)(rect.X + rect.Width), (int)rect.Y);
            Point pt3 = new Point((int)rect.X, (int)(rect.Y + rect.Height));
            Point pt4 = new Point((int)(rect.X + rect.Width), (int)(rect.Y + rect.Height));
            tex.Line(pt1, pt2, color);
            tex.Line(pt2, pt4, color);
            tex.Line(pt4, pt3, color);
            tex.Line(pt3, pt1, color);
            return tex;
        }

        public static Texture2D Line(this Texture2D tex, Point pt1, Point pt2, UnityEngine.Color col)
        {
            int x0 = pt1.X;
            int y0 = pt1.Y;
            int x1 = pt2.X;
            int y1 = pt2.Y;
            int dy = y1 - y0;
            int dx = x1 - x0;
            int stepx, stepy;

            if (dy < 0) { dy = -dy; stepy = -1; }
            else { stepy = 1; }
            if (dx < 0) { dx = -dx; stepx = -1; }
            else { stepx = 1; }
            dy <<= 1;
            dx <<= 1;

            float fraction = 0;

            tex.SetPixel(x0, y0, col);
            if (dx > dy)
            {
                fraction = dy - (dx >> 1);
                while (Mathf.Abs(x0 - x1) > 1)
                {
                    if (fraction >= 0)
                    {
                        y0 += stepy;
                        fraction -= dx;
                    }
                    x0 += stepx;
                    fraction += dy;
                    tex.SetPixel(x0, y0, col);
                }
            }
            else
            {
                fraction = dx - (dy >> 1);
                while (Mathf.Abs(y0 - y1) > 1)
                {
                    if (fraction >= 0)
                    {
                        x0 += stepx;
                        fraction -= dy;
                    }
                    y0 += stepy;
                    fraction += dx;
                    tex.SetPixel(x0, y0, col);
                }
            }
            return tex;
        }

        public static Texture2D Line(this Texture2D tex, PointF pt1, PointF pt2, UnityEngine.Color col)
        {
            int x0 = (int)pt1.X;
            int y0 = (int)pt1.Y;
            int x1 = (int)pt2.X;
            int y1 = (int)pt2.Y;
            int dy = y1 - y0;
            int dx = x1 - x0;
            int stepx, stepy;

            if (dy < 0) { dy = -dy; stepy = -1; }
            else { stepy = 1; }
            if (dx < 0) { dx = -dx; stepx = -1; }
            else { stepx = 1; }
            dy <<= 1;
            dx <<= 1;

            float fraction = 0;

            tex.SetPixel(x0, y0, col);
            if (dx > dy)
            {
                fraction = dy - (dx >> 1);
                while (Mathf.Abs(x0 - x1) > 1)
                {
                    if (fraction >= 0)
                    {
                        y0 += stepy;
                        fraction -= dx;
                    }
                    x0 += stepx;
                    fraction += dy;
                    tex.SetPixel(x0, y0, col);
                }
            }
            else
            {
                fraction = dx - (dy >> 1);
                while (Mathf.Abs(y0 - y1) > 1)
                {
                    if (fraction >= 0)
                    {
                        x0 += stepx;
                        fraction -= dy;
                    }
                    y0 += stepy;
                    fraction += dx;
                    tex.SetPixel(x0, y0, col);
                }
            }
            return tex;
        }
    }
}
