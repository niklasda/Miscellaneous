using System.Collections.Generic;
using System.Text;

namespace RankWords.Parsing
{
    public class FileParseResultList : List<FileParseResult>
    {
        public FileParseResult ComulativeResults
        {
            get
            {
                var sum = new FileParseResult("Cumulative");
                foreach (var result in this)
                {
                    foreach (var rank in result.Ranks)
                    {
                        var lowerCaseWord = rank.Key;

                        if ((lowerCaseWord.Contains("-") && lowerCaseWord.Length > 4 && lowerCaseWord.Length <= 20)
                            || (lowerCaseWord.Length > 4 && lowerCaseWord.Length <= 10))
                        {
                            if (sum.Ranks.ContainsKey(rank.Key))
                            {
                                sum.Ranks[rank.Key] += rank.Value;
                            }
                            else
                            {
                                sum.Ranks.Add(rank.Key, rank.Value);
                            }
                        }
                    }
                }

                return sum;
            }
        }

        public string WriteResultPerFile()
        {
            var sb = new StringBuilder();
            foreach (var result in this)
            {
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    sb.AppendLine(result.ErrorMessage);
                    sb.AppendLine(result.FileName);
                }
                else
                {
                    sb.AppendLine(result.WriteResult());
                }
            }

            return sb.ToString();
        }

        public string WriteResult()
        {
            return ComulativeResults.WriteResult();
        }
    }
}