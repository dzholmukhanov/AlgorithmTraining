using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class PineappleIncident362
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt(), s = fs.NextInt(), x = fs.NextInt();
                writer.WriteLine((x >= t && (x - t) % s == 0) || (x >= t + 1 && (x - t - 1) % s == 0 && (x - t - 1) / s >= 1) ? "YES" : "NO");
            }
        }
    }
}
