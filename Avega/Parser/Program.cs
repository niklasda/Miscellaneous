using System;
using System.Collections.Generic;

using RankWords.Logic;
using RankWords.Parsing;

namespace RankWords
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IList<string> fileNames = new List<string>();

            foreach (var arg in args)
            {
                Console.WriteLine("Commandline specified filename: {0}", arg);
                fileNames.Add(arg);
            }

            Console.WriteLine("Please specify files (blank line to finish):");

            string f;
            while ((f = Console.ReadLine()) != string.Empty)
            {
                fileNames.Add(f);
            }

            FileParseResultList ranks = RankingController.Start(fileNames);

            Console.WriteLine(ranks.WriteResult());
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
