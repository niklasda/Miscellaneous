using System.Collections.Generic;

namespace RankWords.Parsing
{
    public abstract class BaseParser : IParser
    {
        public abstract FileParseResult Parse(string fileName);

        protected void AddOneOrTwoToRanks(int wordCount, ref FileParseResult result)
        {
            IDictionary<string, int> c2 = new Dictionary<string, int>();
            if (wordCount > 100)
            {
                foreach (var count in result.Ranks)
                {
                    c2.Add(count.Key, count.Value + 1);

                    if (wordCount > 1000 && this.HasDoubleLetters(count.Key))
                    {
                        c2[count.Key]++;
                    }
                }

                result.Ranks = c2;
            }
        }

        private bool HasDoubleLetters(string word)
        {
            string newWord = word.Replace("aa", string.Empty).Replace("bb", string.Empty).Replace("cc", string.Empty).Replace("dd", string.Empty)
                .Replace("ee", string.Empty).Replace("ff", string.Empty).Replace("gg", string.Empty).Replace("hh", string.Empty).Replace("ii", string.Empty)
                .Replace("jj", string.Empty).Replace("kk", string.Empty).Replace("ll", string.Empty).Replace("mm", string.Empty).Replace("nn", string.Empty)
                .Replace("oo", string.Empty).Replace("pp", string.Empty).Replace("qq", string.Empty).Replace("rr", string.Empty).Replace("ss", string.Empty)
                .Replace("tt", string.Empty).Replace("uu", string.Empty).Replace("vv", string.Empty).Replace("ww", string.Empty).Replace("xx", string.Empty)
                .Replace("yy", string.Empty).Replace("zz", string.Empty).Replace("åå", string.Empty).Replace("ää", string.Empty).Replace("öö", string.Empty);

            return word.Length != newWord.Length;
        }
    }
}