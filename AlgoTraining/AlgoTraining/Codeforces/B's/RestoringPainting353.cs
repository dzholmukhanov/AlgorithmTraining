using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class RestoringPainting353
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), a = fs.NextInt(), b = fs.NextInt(), c = fs.NextInt(), d = fs.NextInt();
                long res = 0;
                for (int x1 = 1; x1 <= n; x1++)
                {
                    int s = x1 + a + b;
                    int x2 = s - a - c, x4 = s - b - d, x5 = s - c - d;
                    if (x2 >= 1 && x2 <= n && x4 >= 1 && x4 <= n && x5 >= 1 && x5 <= n) res += n;
                }
                writer.WriteLine(res);
            }
        }
    }
}
