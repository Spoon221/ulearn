using System;
using System.Collections.Generic;
namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double whitePixels)
        {
            var weight = original.GetLength(0);
            var height = original.GetLength(1);
            var grayscale = new double[weight, height];
            var threshold = 0.0;
            var doorstep = GetThresholdFilterResult(original, whitePixels, threshold);
            for (var x = 0; x < weight; x++)
            {
                for (var y = 0; y < height; y++)
                    grayscale[x, y] = original[x, y] >= doorstep ? 1.0 : 0.0;
            }
            return grayscale;
        }

        public static double GetThresholdFilterResult(double[,] original, double whitePixels,
            double threshold)
        {
            var coloursPixels = new List<double>();
            threshold = (int)(whitePixels * original.Length);
            SortingColoursPixels(original, coloursPixels);
            return threshold == 0 ? 257 : coloursPixels[(int)(original.Length - threshold)];
        }

        public static List<double> SortingColoursPixels(double[,] original, List<double> coloursPixels)
        {
            foreach (var pixel in original)
                coloursPixels.Add(pixel);
            coloursPixels.Sort();
            return coloursPixels;
        }
    }
}