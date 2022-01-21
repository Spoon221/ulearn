using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (var i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }

        [TestCase("''", new[] { "" })]
        [TestCase("", new string[0])]
        [TestCase("text", new[] { "text" })]
        [TestCase("hello world", new[] { "hello", "world" })]
        [TestCase("hello  world", new[] { "hello", "world" })]
        [TestCase(@"'a\' b'", new[] { "a' b" })]
        [TestCase("b \"a'\"", new[] { "b", "a'" })]
        [TestCase("\"\\\\\"", new[] { "\\" })]
        [TestCase("\"\\\\'", new[] { "\\'" })]
        [TestCase("' a'b", new[] { " a", "b" })]
        [TestCase(" a", new[] { "a" })]
        [TestCase("d '2'", new[] { "d", "2" })]
        [TestCase(" a b ", new[] { "a", "b" })]
        [TestCase("'\"(◕‿◕)'", new[] { "\"(◕‿◕)" })]
        [TestCase(@"""\""(*¯︶¯*)""", new[] { @"""(*¯︶¯*)" })]
        [TestCase("'( ´ ω ` ) ", new[] { "( ´ ω ` ) " })]
        public static void RunTests(string input, string[] expectedOutput)
        {
            Test(input, expectedOutput);
        }
    }

    public class FieldsParserTask
    {
        public static List<Token> ParseLine(string line)
        {
            var charArray = line.ToCharArray();
            var stringToken = new List<Token>();
            return CheckingQuoteField(line, charArray, stringToken);
        }

        public static List<Token> CheckingQuoteField(string line, char[] charArray, List<Token> stringToken)
        {
            for (var i = 0; i < line.Length; i++)
            {
                var symbol = charArray[i];
                if (symbol == '\'' || symbol == '"')
                {
                    var token = QuotedFieldTask.ReadQuotedField(line, i);
                    i = token.GetIndexNextToToken() - 1;
                    stringToken.Add(token);
                    continue;
                }
                if (symbol != ' ')
                {
                    var token = ReadField(line, i);
                    i = token.GetIndexNextToToken() - 1;
                    stringToken.Add(token);
                    continue;
                }
            }
            return stringToken;
        }

        public static Token FindingLength(string line, int startIndex, int length, char[] charArray, List<char>result)
        {
            for (var i = startIndex; i < charArray.Length; i++)
            {
                var symbol = charArray[i];
                if (symbol != '\'' && symbol != ' ' && symbol != '"')
                {
                    result.Add(symbol);
                    length++;
                }
                else break;
            }
            return new Token(string.Join("", result), startIndex, length);
        }

        public static Token ReadField(string line, int startIndex)
        {
            var result = new List<char>();
            var length = 0;
            var charArray = line.ToCharArray();
            return FindingLength(line, startIndex, length, charArray, result);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}