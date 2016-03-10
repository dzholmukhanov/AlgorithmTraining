using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class Interview344
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                long[] a = new long[n], b = new long[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                for (int i = 0; i < n; i++)
                {
                    b[i] = fs.NextInt();
                }
                long maxVal = a[0] + b[0];
                for (int i = 0; i < n; i++)
                {
                    long aor = a[i], bor = b[i];
                    maxVal = Math.Max(aor + bor, maxVal);
                    for (int j = i + 1; j < n; j++)
                    {
                        aor |= a[j];
                        bor |= b[j];
                        maxVal = Math.Max(aor + bor, maxVal);
                    }
                }
                writer.WriteLine(maxVal);
            }
        }
    }
}
