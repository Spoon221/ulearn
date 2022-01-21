using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var sy = TransposeMatrix(sx);
            var shift = sx.GetLength(0) / 2;
            for (var x = shift; x < width - shift; x++)
                for (var y = shift; y < height - shift; y++)
                {
                    var gx = MultiplyPixelsMatrix(g, sx, x, y, shift);
                    var gy = MultiplyPixelsMatrix(g, sy, x, y, shift);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            var sideLength = matrix.GetLength(0);
            var transposedMatrix = new double[sideLength, sideLength];
            for (var x = 0; x < sideLength; x++)
                for (var y = 0; y < sideLength; y++)
                    transposedMatrix[x, y] = matrix[y, x];
            return transposedMatrix;
        }

        public static double MultiplyPixelsMatrix(double[,] pixels, double[,] matrix, int x, int y, int shift)
        {
            var result = 0.0;
            var sideLength = matrix.GetLength(0);
            for (var i = 0; i < sideLength; i++)
                for (var j = 0; j < sideLength; j++)
                    result += matrix[i, j] * pixels[x - shift + i, y - shift + j];
            return result;
        }
    }
}