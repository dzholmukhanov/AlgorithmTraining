using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class MikeAndGeometryProblem361
    {
        private static long[] factMod;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt(), mod = (int)1e9 + 7;
                List<SegmentEnd> points = new List<SegmentEnd>(n << 1);
                for (int i = 0; i < n; i++)
                {
                    points.Add(new SegmentEnd { Id = i, X = fs.NextInt(), IsLeft = true });
                    points.Add(new SegmentEnd { Id = i, X = fs.NextInt() + 1, IsLeft = false });
                }
                points = points.OrderBy(p => p.X).ThenBy(p => p.IsLeft).ToList();

                factMod = new long[n + 1];
                factMod[0] = 1;
                factMod[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    factMod[i] = factMod[i - 1] * i % mod;
                }

                long[] crossCount = new long[n + 1];
                int cross = 0;
                SegmentEnd prev = null;
                foreach (SegmentEnd curr in points)
                {
                    if (curr.IsLeft)
                    {
                        if (prev != null)
                        {
                            crossCount[cross] += curr.X - prev.X;
                        }
                        cross++;
                    }
                    else
                    {
                        crossCount[cross] += curr.X - prev.X;
                        cross--;
                    }
                    prev = curr;
                }

                long ans = 0;
                for (int i = k; i <= n; i++)
                {
                    if (crossCount[i] == 0) continue;
                    ans = (ans + Combination(i, k, mod) * crossCount[i]) % mod;
                }
                writer.WriteLine(ans);
            }
        }

        private static long Combination(long n, long k, long mod)
        {
            if (k > n) return 0;
            else if (k == n) return 1;
            else return (factMod[n] * BinPowMod((factMod[k] * factMod[n - k]) % mod, mod - 2, mod)) % mod;
        }
        public static long BinPowMod(long a, long p, long mod)
        {
            if (p == 0) return 1;
            if ((p & 1) == 0)
            {
                long t = BinPowMod(a, p / 2, mod);
                return (t * t) % mod;
            }
            else
            {
                return (a % mod * BinPowMod(a, p - 1, mod)) % mod;
            }
        }
         
    }
    class SegmentEnd
    {
        public int Id, X;
        public bool IsLeft;
    }
}
