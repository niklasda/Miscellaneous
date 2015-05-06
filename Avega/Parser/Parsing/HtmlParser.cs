using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace RankWords.Parsing
{
    public class HtmlParser : BaseParser
    {
        public override FileParseResult Parse(string fileName)
        {
            var result = new FileParseResult(fileName);

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        CountsWords(line, ref result);
                    }

                    sr.Close();
                }

                fs.Close();
            }

            int totalWords = result.Ranks.Sum(x => x.Value);
            AddOneOrTwoToRanks(totalWords, ref result);
            
            return result;
        }

        private void CountsWords(string line, ref FileParseResult result)
        {
            line = Regex.Replace(line, @"<[^>]*>", string.Empty);

            line =
                line.Replace(".", string.Empty)
                    .Replace(",", string.Empty)
                    .Replace(":", string.Empty)
                    .Replace(";", string.Empty)
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty)
                    .Replace("{", string.Empty)
                    .Replace("}", string.Empty)
                    .Replace("'", string.Empty)
                    .Replace("(", string.Empty)
                    .Replace(")", string.Empty);

            var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                var lowerCaseWord = word.Trim().ToLower();
                if (result.Ranks.ContainsKey(lowerCaseWord))
                {
                    result.Ranks[lowerCaseWord]++;
                }
                else
                {
                    result.Ranks.Add(lowerCaseWord, 1);
                }
            }
        }
    }
}