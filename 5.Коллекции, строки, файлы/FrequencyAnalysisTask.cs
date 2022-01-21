using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    class CompareString : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.CompareOrdinal(x, y);
        }
    }

    static class FrequencyAnalysisTask
    {
        private static Dictionary<string, Dictionary<string, int>> CreateDictionary(List<List<string>> text)
        {
            var dictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var words in text)
            {
                for (var i = 0; i < words.Count - 1; i++)
                {
                    var firstWord = words[i];
                    var secondWord = words[i + 1];
                    string thirdWord = null;
                    if (i != words.Count - 2)
                        thirdWord = words[i + 2];
                    CreateBigram(dictionary, firstWord, secondWord);
                    if (thirdWord != null)
                        CreateTrigram(dictionary, firstWord, secondWord, thirdWord);
                }
            }
            return dictionary;
        }

        public static void CreateBigram(Dictionary<string, Dictionary<string, int>> dictionary,
        string firstWord, string secondWord)
        {
            if (!dictionary.ContainsKey(firstWord))
                dictionary.Add(firstWord, new Dictionary<string, int> {{secondWord, 1}});
            else if (dictionary.ContainsKey(firstWord) && !dictionary[firstWord].ContainsKey(secondWord))
                dictionary[firstWord].Add(secondWord, 1);
            else if (dictionary.ContainsKey(firstWord) && dictionary[firstWord].ContainsKey(secondWord))
                dictionary[firstWord][secondWord]++;
        }

        public static void CreateTrigram(Dictionary<string, Dictionary<string, int>> dictionary,
        string firstWord, string secondWord, string thirdWord)
        {
            firstWord = firstWord + " " + secondWord;
            secondWord = thirdWord;
            if (!dictionary.ContainsKey(firstWord))
                dictionary.Add(firstWord, new Dictionary<string, int> {{secondWord, 1}});
            else if (dictionary.ContainsKey(firstWord) && !dictionary[firstWord].ContainsKey(secondWord))
                dictionary[firstWord].Add(secondWord, 1);
            else if (dictionary.ContainsKey(firstWord) && dictionary[firstWord].ContainsKey(secondWord))
                dictionary[firstWord][secondWord]++;
        }

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var dictionary = CreateDictionary(text);
            var ending = new List<string>();
            foreach (var start in dictionary)
            {
                var max = 0;
                foreach (var pair in start.Value.OrderByDescending(pair => pair.Value))
                {
                    if (ending.Count == 0)
                    {
                        ending.Add(pair.Key);
                        max = pair.Value;
                    }
                    else if (pair.Value == max)
                        ending.Add(pair.Key);
                }
                var compareString = new CompareString();
                ending.Sort(compareString);
                result.Add(start.Key, ending[0]);
                ending.Clear();
            }
            return result;
        }
    }
}