using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class Holidays350
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), a = n / 7, b = n % 7;
                int worst = a * 2 + (b < 6 ? 0 : 1);
                int best = a * 2 + (b == 1 ? 1 : b >= 2 ? 2 : 0);
                writer.WriteLine(worst + " " + best);
            }
        }
    }
}
