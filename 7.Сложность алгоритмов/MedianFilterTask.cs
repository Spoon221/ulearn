using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        public static double[,] MedianFilter(double[,] original)
        {
            var xAxis = original.GetLength(0);
            var yAxis = original.GetLength(1);
            var valuesMedian = new double[xAxis, yAxis];
            for (var x = 0; x < xAxis; x++)
            {
                for (var y = 0; y < yAxis; y++)
                    valuesMedian[x, y] = FindMedian(x, y, xAxis,
                        yAxis, original);
            }
            return valuesMedian;
        }

        public static double CalculationCentralValue(List<double> lateralValues)
        {
            var endValue = lateralValues.Count / 2;
            lateralValues.Sort();
            if (lateralValues.Count % 2 == 0)
                return (lateralValues[endValue] + lateralValues[(endValue) - 1]) / 2;
            return lateralValues[endValue];
        }

        public static double FindMedian(int xAxis, int yAxis, int width,
            int height, double[,] original)
        {
            var values = new List<double>();
            var maxX = Math.Max(0, xAxis - 1);
            var minX = Math.Min(xAxis + 1, width - 1);
            var maxY = Math.Max(0, yAxis - 1);
            var minY = Math.Min(yAxis + 1, height - 1);
            for (var i = maxX; i <= minX; i++)
            {
                for (var k = maxY; k <= minY; k++)
                    values.Add(original[i, k]);
            }
            return CalculationCentralValue(values);
        }
    }
}