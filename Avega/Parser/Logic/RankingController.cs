using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using RankWords.Parsing;

namespace RankWords.Logic
{
    public static class RankingController
    {
        public static FileParseResultList Start(IList<string> fileNames)
        {
            var q = new ConcurrentQueue<FileParseResult>();

            var loopResult = Parallel.ForEach(
                fileNames,
                fileName =>
                {
                    try
                    {
                        if (File.Exists(fileName) && Path.HasExtension(fileName))
                        {
                            IParser parser = ParserFactory.GetParser(fileName.ToLower());
                            if (parser != null)
                            {
                                FileParseResult result = parser.Parse(fileName);
                                q.Enqueue(result);
                            }
                        }
                        else
                        {
                            var result = new FileParseResult(fileName, "File not found: ");
                            q.Enqueue(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                });

            var ranks = new FileParseResultList();
            ranks.AddRange(q.ToArray());

            return ranks;
        }
    }
}