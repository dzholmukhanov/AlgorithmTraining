using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class RussianRoulette80
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long n = fs.NextLong(), k = fs.NextLong(), m = n - k;
                int p = fs.NextInt();
                while (p-- > 0)
                {
                    long x = fs.NextLong() - 1;
                    if (m == 0) writer.Write("X");
                    else if (k == 0) writer.Write(".");
                    else
                    {
                        if (n % 2 == 0)
                        {
                            if (x % 2 == 0 && x <= 2 * Math.Min(m, n / 2) - 2) writer.Write(".");
                            else if (x % 2 == 1 && x <= 2 * (m - n / 2) - 1) writer.Write(".");
                            else writer.Write("X");
                        }
                        else
                        {
                            if (x % 2 == 0 && x <= 2 * Math.Min(m, (n - 1) / 2) - 2) writer.Write(".");
                            else if (x % 2 == 1 && x <= 2 * (m - (n - 1) / 2) - 1) writer.Write(".");
                            else writer.Write("X");
                        }
                    }
                }
            }
        }
    }
}
