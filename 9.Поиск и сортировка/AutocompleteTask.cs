using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            return null;
        }

        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases,
            string prefix, int count)
        {
            var leftBorder = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            var rightBorder = leftBorder + count - 1;
            var phrasesList = new List<string>();
            var i = leftBorder;
            while (i <= rightBorder)
            {
                if (i < phrases.Count && phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    phrasesList.Add(phrases[i]);
                i++;
            }
            return phrasesList.ToArray();
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var countPhrases = phrases.Count;
            var leftBorde = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, countPhrases);
            var rightBorder = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, countPhrases);
            var word = rightBorder - leftBorde - 1;
            return word;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void CountPrefixWhenEmptyResult()
        {
            var prefix = "aaa";
            var phrases = new string[] { "aa", "ab", "bc", "be", "bd", "ca", "cb" };
            var expectedBill = 0;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedBill, actualCount);
        }

        [Test]
        public void CountPrefixWhilePrefixEmpty()
        {
            var prefix = "";
            var phrases = new string[] { "aa", "ab", "bc", "be", "bd", "ca", "cb" };
            var expectedBill = phrases.Length;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedBill, actualCount);
        }

        [Test]
        public void CountZerophraseDictionary()
        {
            var phrases = new string[] { };
            var prefix = "1";
            var actualPhrases = (string)null;
            Assert.AreEqual(actualPhrases, AutocompleteTask.FindFirstByPrefix(phrases, prefix));
        }

        [Test]
        public void CountPrefixWhenSingleResult()
        {
            var prefix = "aa";
            var phrases = new string[] { "aa", "ab", "bc", "be", "bd", "ca", "cb" };
            var expectedBill = 0;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedBill, actualCount);
        }

        [Test]
        public void CountPrefixWhenMultipleResult()
        {
            var prefix = "b";
            var phrases = new string[] { "aa", "ab", "bc", "be", "bd", "ca", "cb" };
            var expectedBill = 0;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedBill, actualCount);
        }
    }
}