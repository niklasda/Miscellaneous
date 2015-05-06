using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankWords.Parsing
{
    public class FileParseResult
    {
        public FileParseResult(string fileName)
        {
            FileName = fileName;
            ErrorMessage = string.Empty;
            Ranks = new Dictionary<string, int>();
        }

        public FileParseResult(string fileName, string errorMessage)
        {
            FileName = fileName;
            ErrorMessage = errorMessage;
            Ranks = new Dictionary<string, int>();
        }

        public string FileName { get; private set; }

        public string ErrorMessage { get; private set; }

        public IDictionary<string, int> Ranks { get; set; }

        public string WriteResult()
        {
            var sb = new StringBuilder();
            foreach (var rank in Ranks.OrderByDescending(x => x.Value))
            {
                sb.Append(rank.Key);
                sb.Append(": ");
                sb.AppendLine(string.Format("{0}", rank.Value));
            }

            return sb.ToString();
        }
    }
}