using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'b'", 0, "b", 3)]
        [TestCase(@"""r 't' 'y' u""", 0, "r 't' 'y' u", 13)]
        [TestCase("'vbn ef", 0, "vbn ef", 7)]
        [TestCase(@"""\\""", 0, @"\", 4)]
        [TestCase("\'h\'\'j\'", 0, "h", 3)]
        [TestCase(@"'""1"" ""2"" ""3""'", 0, @"""1"" ""2"" ""3""", 13)]
        [TestCase(@"some_text ""QF \"""" other text", 10, @"QF """, 7)]

        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(actualToken, new Token(expectedValue, startIndex, expectedLength));
        }
    }

    class QuotedFieldTask
    {
        private static int ConditionCheck(int length,char[] charArray, bool cut,
            List<char> result,int nextStartIndex,
            char quote)
        {
            for (var i = nextStartIndex; i < charArray.Length; i++)
            {
                length++;
                var symbol = charArray[i];
                if (cut)
                {
                    cut = false;
                    continue;
                }
                if (symbol == quote)
                    break;
                if (symbol == '\\')
                {
                    cut = true;
                    result.Add(charArray[i + 1]);
                    continue;
                }
                if (symbol != quote)
                    result.Add(symbol);
            }
            return length;
        }

        private static int FindingLength(char quote, char[] charArray, bool isSlashed,
        List<char> result, int startIndex)
        {
            var nextStartIndex = startIndex + 1;
            var length = 1;
            return ConditionCheck(length, charArray,
                isSlashed, result, nextStartIndex, quote);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            var cuted = false;
            var result = new List<char>();
            var array = line.ToCharArray();
            var cite = line[startIndex];
            var length = FindingLength(cite, array, cuted, result, startIndex);
            return new Token(string.Join("", result), startIndex, length);
        }
    }
}