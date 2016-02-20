using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class InfiniteSequenceECR7
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long sn = fs.NextLong();
                long n = (long)Math.Ceiling((Math.Sqrt(8 * sn + 1) - 1) / 2);
                long number = sn - (n * (n - 1)) / 2;
                writer.WriteLine(number);
            }
        }
    }
}
