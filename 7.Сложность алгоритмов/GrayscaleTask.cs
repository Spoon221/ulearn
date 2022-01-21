namespace Recognizer
{
    public static class GrayscaleTask
    {
        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var xAxis = original.GetLength(0);
            var yAxis = original.GetLength(1);
            var colourPixels = new double[xAxis, yAxis];
            for (var x = 0; x < xAxis; x++)
            {
                for (var y = 0; y < yAxis; y++)
                {
                    var pixel = original[x, y];
                    colourPixels[x, y] = (0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B) / 255;
                }
            }
            return colourPixels;
        }
    }
}