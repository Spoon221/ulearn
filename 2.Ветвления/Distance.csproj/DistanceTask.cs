using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            if ((ax == x && ay == y) || (bx == x && by == y))
            {
                return 0;
            }
            var vectorAB = GetDistance(ax, ay, bx, by);
            var vectorAC = GetDistance(ax, ay, x, y);
            if (vectorAB == 0)
            {
                return vectorAC;
            }
            var vectorBC = GetDistance(bx, by, x, y);
            if (BlantAngle(vectorAC, vectorBC, vectorAB))
            {
                return vectorBC;
            }
            if (BlantAngle(vectorBC, vectorAC, vectorAB))
            {
                return vectorAC;
            }
            var semiPerimeter = (vectorAC + vectorBC + vectorAB) / 2;
            return 2 * Math.Sqrt(semiPerimeter * (semiPerimeter - vectorAB) 
                * (semiPerimeter - vectorBC) * (semiPerimeter - vectorAC)) / vectorAB;
        }

        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public static bool BlantAngle(double perpendicular, double x, double y)
        {
            return (x * x + y * y - perpendicular * perpendicular) / (2 * x * y) < 0;
        }
    }
}