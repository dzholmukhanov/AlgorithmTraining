using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class MemoryAndScores370
    {
        private static int a, b, k, t;
        private static long[] comb, combSum;
        private static long mod;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                a = fs.NextInt();
                b = fs.NextInt();
                k = fs.NextInt();
                t = fs.NextInt();
                comb = new long[2 * k * t + 1];
                combSum = new long[2 * k * t + 1];
                mod = (int)1e9 + 7;
                for (int i = 0; i <= 2 * k; i++)
                {
                    comb[i] = 1;
                }
                for (int i = 1; i < t; i++)
                {
                    long sum = 0;
                    long[] tcomb = new long[2 * k * t + 1];
                    for (int j = 0; j < comb.Length; j++)
                    {
                        sum = (sum + comb[j]) % mod;
                        if (j > 2 * k)
                        {
                            sum = (mod + (sum - comb[j - 2 * k - 1]) % mod) % mod;
                        }
                        tcomb[j] = sum;
                    }
                    comb = tcomb;
                }
                combSum[0] = comb[0];
                for (int i = 1; i < comb.Length; i++)
                {
                    combSum[i] = (comb[i] + combSum[i - 1]) % mod;
                }

                long ans = 0;
                for (int i = 0; i < comb.Length; i++)
                {
                    int index = Math.Min(i + a - b - 1, combSum.Length - 1);
                    if (index >= 0) ans = (ans + (comb[i] * combSum[index]) % mod) % mod;
                }
                writer.WriteLine(ans);
            }
        }
    }
}
