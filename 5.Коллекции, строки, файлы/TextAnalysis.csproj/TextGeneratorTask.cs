using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords,
            string phraseBeginning, int wordsCount)
        {
            var builder = new StringBuilder();
            builder.Append(phraseBeginning);
            for (var i = 0; i < wordsCount; i++)
            {
                var phrase = builder.ToString();
                if (GetWordCount(phrase) >= 2 && nextWords.ContainsKey(GetKey(3, phrase)))
                    builder.Append(" " + nextWords[GetKey(3, phrase)]);
                else if (nextWords.ContainsKey(GetKey(1, phrase)))
                    builder.Append(" " + nextWords[GetKey(1, phrase)]);
                else
                    break;
            }
            return builder.ToString();
        }

        public static string GetKey(int index, string phrase)
        {
            var text = phrase.Split(' ');
            if (index == 3)
                return text[text.Length - 2] + " " + text[text.Length - 1];
            else 
                return text[text.Length - 1];
        }

        public static int GetWordCount(string phrase)
        {
            var words = phrase.Split(' ');
            return words.Length;
        }
    }
}