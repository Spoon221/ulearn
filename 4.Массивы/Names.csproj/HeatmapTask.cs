using System;
namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var day = FillingOffSet(30, 2);
            var mounth = FillingOffSet(12, 1);
            var color = new double[day.Length, mounth.Length];
            foreach (var fertility in names)
            {
                if (fertility.BirthDate.Day != 1)
                {
                    color[fertility.BirthDate.Day - 2, fertility.BirthDate.Month - 1]++;
                }
            }
            return new HeatmapData("Карта интенсивности рождаемости",
                color, 
                day, 
                mounth);
        }

        public static string[] FillingOffSet(int lengthArray, int offset)
        {
            var array = new string[lengthArray];
            for (var i = 0; i < lengthArray; i++)
            { 
                array[i] = Convert.ToString(i + offset);
            }
            return array;
        }
    }
}