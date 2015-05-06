namespace RankWords.Parsing
{
    public interface IParser
    {
        FileParseResult Parse(string fileName);
    }
}