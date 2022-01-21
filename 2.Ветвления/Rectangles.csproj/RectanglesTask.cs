using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            return r1.Right >= r2.Left && r2.Right >= r1.Left && r1.Bottom >= r2.Top && r2.Bottom >= r1.Top;
        }

        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            var width = Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left);
            var height = Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top);

            if ((width > 0) && (height > 0))
                return width * height;
            return 0;
        }

        public static bool GetInside(Rectangle a, Rectangle b)
        {
            return b.Left >= a.Left 
                && a.Right >= b.Right
                && a.Bottom >= b.Bottom 
                && b.Top >= a.Top;
        }

        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (GetInside(r1, r2))
                return 1;
            if (GetInside(r2, r1))
                return 0;
            return -1;
        }
    }
}