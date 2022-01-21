using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var chooseDataBornName = new double[31];
            foreach (var nameDay in names)
            {
                if (nameDay.BirthDate.Day > 1 && nameDay.Name == name)
                {
                    chooseDataBornName[nameDay.BirthDate.Day - 1]++;
                }
            }

            return new HistogramData
                (string.Format("Рождаемость людей с именем '{0}'",
                name),
                BirthdayCounter(),
                chooseDataBornName);
        }

        public static string[] BirthdayCounter()
        {
            var signatureDays = new string[31];
            for (var i = 0; i < signatureDays.Length; i++)
            {
                signatureDays[i] = Convert.ToString(i + 1);
            }
            return signatureDays;
        }
    }
}