using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Algorithms.Emaxx
{
    public class Algebra
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                for (int i = 1; i <= 100; i++)
                {
                    long a = i * i;
                    long b = Algebra.BinMult(i, i);
                    if (a != b)
                    {
                        writer.WriteLine(i);
                        writer.WriteLine(a + " " + b);
                        return;
                    }
                }
                writer.WriteLine(0);
            }
        }
        public static int EulersTotient(int n)
        {
            int res = n;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    while (n % i == 0)
                    {
                        n /= i;
                    }
                    res -= res / i;
                }
            }
            if (n > 1) res -= res / n;
            return res;
        }
        public static long BinPow(long a, long pow)
        {
            long res = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                {
                    res *= a;
                }
                a *= a;
                pow >>= 1;
            }
            return res;
        }
        public static long BinMult(long a, long mult)
        {
            if (mult == 0) return 0;
            if ((mult & 1) == 1) return a + BinMult(a, mult - 1);
            else
            {
                long b = BinMult(a, mult >> 1);
                return b + b;
            }
        }
    }
}
