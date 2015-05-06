using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.PLinq
{
    public class PxStuff
    {
        public void MultiFor()
        {
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;

            Parallel.For(0, 10, i =>
                {
                    Debug.WriteLine("TID={0}, i={1}",
                        Thread.CurrentThread.ManagedThreadId,
                        i);

                    SimulateProcessing();
                });
        }



        public void MultiForEach()
        {
            IEnumerable<int> vals = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Parallel.ForEach(vals, i =>
            {
                Debug.WriteLine("TID={0}, i={1}",
                    Thread.CurrentThread.ManagedThreadId,
                    i);

                SimulateProcessing();
            });
        }

        private static void SimulateProcessing()
        {
            Thread.Sleep(2 * 1000);
            Thread.SpinWait(80 * 1000 * 1000);
        }



        public void ParallelTaskLibFactory()
        {
            FileStream fs = File.OpenRead(@"C:\Projects\MbUnitDemo\Vs2010Seminar\todo.txt");
            var buffer = new byte[fs.Length];

            Task<int> t = Task<int>.Factory.FromAsync(
                fs.BeginRead, fs.EndRead, buffer, 0, buffer.Length, null);

            t.Wait();
        }


        public void ParallelTaskLibStartNew()
        {
            Task<int> t = Task<int>.Factory.StartNew(() =>
            {
                Debug.WriteLine("Hello");
                return 0;
            });

            t.Wait();
        }
    }
}
