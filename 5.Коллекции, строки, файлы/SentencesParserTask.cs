using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var texts = text.ToCharArray();
            var punctuationMarks = new List<char>() { '.', '!', '?', ';', ':', '(', ')' };
            var sentencesList = new List<List<string>>();
            var builder = new StringBuilder();
            var sentences = new List<string>();
            return GetSentenceList(sentencesList, builder, sentences, punctuationMarks, texts);
        }

        public static List<List<string>> GetSentenceList(List<List<string>> sentencesList,
        StringBuilder builder, List<string> sentences, List<char> punctuationMarks, char[] texts)
        {
            for (var i = 0; i < texts.Length; i++)
            {
                var letter = texts[i];
                if (char.IsLetter(letter) || letter == '\'')
                    builder.Append(letter);
                else if (builder.Length != 0)
                {
                    sentences.Add(builder.ToString().ToLower());
                    builder.Clear();
                }
                if (i == texts.Length - 1 && (char.IsLetter(letter) || letter == '\''))
                {
                    sentences.Add(builder.ToString().ToLower());
                    builder.Clear();
                }
                if ((punctuationMarks.Contains(letter) || i == texts.Length - 1) && sentences.Count != 0)
                {
                    var newSentence = new List<string>(sentences);
                    sentencesList.Add(newSentence);
                    sentences.Clear();
                }
            }
            return sentencesList;
        }
    }
}