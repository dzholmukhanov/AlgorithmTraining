using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class Please362
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int k = fs.NextInt(), mod = (int)1e9 + 7;
                long[] a = new long[k];
                bool isEven = false;
                for (int i = 0; i < k; i++)
                {
                    a[i] = fs.NextLong();
                    if (!isEven && a[i] % 2 == 0) isEven = true;
                }
                long Dn = 2;
                for (int i = 0; i < k; i++)
                {
                    Dn = BinPowMod(Dn, a[i], mod);
                }
                Dn = (Dn * BinPowMod(2, mod - 2, mod)) % mod;
                long Nm = Dn + (isEven ? 1 : -1);
                Nm = (Nm * BinPowMod(3, mod - 2, mod)) % mod;
                writer.WriteLine(Nm + "/" + Dn);
            }
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
