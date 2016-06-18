using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class BearAndTowerOfCubes356
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long m = fs.NextLong(), d = 0;
                long count = Solve(m, ref d);
                writer.WriteLine(count + " " + (m - d));
            }
        }
        public static long Solve(long m, ref long d)
        {
            if (m < 8) return m;
            long r2 = (long)Math.Pow((long)Math.Pow(m, 1.0 / 3.0), 3);
            long r1 = (long)Math.Pow((long)Math.Pow(m, 1.0 / 3.0) - 1, 3);
            long p2 = m - r2;
            long p1 = r2 - 1 - r1;

            long d1 = 0, d2 = 0;
            long a1 = 1 + Solve(p1, ref d1);
            long a2 = 1 + Solve(p2, ref d2);

            if (a2 >= a1)
            {
                d += d2;
                return a2;
            }
            else
            {
                d += m - r2 + 1;
                d += d1;
                return a1;
            }
        }
    }
}
