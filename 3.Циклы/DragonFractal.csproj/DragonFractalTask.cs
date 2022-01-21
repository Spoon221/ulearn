using System.Drawing;
using System;
namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static (double x, double y) GetFirstDegreeRadians(double x, double y, double angle, int bias)
        {
            var x1 = (x * Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2) + bias;
            var y1 = (x * Math.Sin(angle) + y * Math.Cos(angle)) / Math.Sqrt(2);
            return (x1, y1);
        }

        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            var x = 1.0;
            var y = 0.0;
            var angle45 = Math.PI / 4;
            var angle135 = 3 * Math.PI / 4;
            var random = new Random(seed);
            for (var i = 0; i < iterationsCount; i++)
            {
                if (random.Next(2) != 0)
                {
                    (x, y) = GetFirstDegreeRadians(x, y, angle45,0);
                }
                else
                {
                    (x, y) = GetFirstDegreeRadians(x, y, angle135,1);
                }

                pixels.SetPixel(x, y);
            }
        }
    }
}