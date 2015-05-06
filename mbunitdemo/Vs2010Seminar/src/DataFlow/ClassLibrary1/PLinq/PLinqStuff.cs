using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace ClassLibrary1.PLinq
{
    public class PLinqStuff
    {
        public void Plinq()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 1000);

            IEnumerable<int> results = from n in numbers.AsParallel()
                                       where IsDivisibleByFive(n)
                                       select n;

            Stopwatch sw = Stopwatch.StartNew();
            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
            sw.Stop();

            Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds);
        }

        static bool IsDivisibleByFive(int i)
        {
            Thread.SpinWait(2 * 1000 * 1000);

            return i % 5 == 0;
        }
    }
}
