using System.IO;

namespace RankWords.Parsing
{
    public static class ParserFactory
    {
        public static IParser GetParser(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            if (!string.IsNullOrEmpty(ext))
            {
                if (ext.Equals(".txt"))
                {
                    return new TextParser();
                }

                if (ext.Equals(".html"))
                {
                    return new HtmlParser();
                }

                return null;
            }

            return null;
        }
    }
}
