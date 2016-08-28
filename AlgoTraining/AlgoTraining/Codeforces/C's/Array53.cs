using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class Array53
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int mod = 1000000007;
                if (n == 1)
                {
                    writer.WriteLine(1);
                    return;
                }
                long ans = (FactorialMod(2 * n - 1, mod) * 1L * BinPowMod((FactorialMod(n - 1, mod) * 1L * FactorialMod(n, mod)) % mod, mod - 2, mod)) % mod;
                writer.WriteLine((ans * 2) % mod - n);
            }
        }

        public static int FactorialMod(int n, int mod)
        {
            long res = 1;
            while (n > 0)
            {
                for (int i = 2, m = n % mod; i <= m; i++)
                    res = (res * i) % mod;
                if ((n /= mod) % 2 > 0)
                    res = mod - res;
            }
            return (int)res;
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
}
