using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class RemaindersGame360
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                int[] c = new int[n];
                long lcm = 1;
                for (int i = 0; i < n; i++)
                {
                    c[i] = fs.NextInt();
                }
                for (int i = 0; i < n; i++)
                {
                    lcm = LCM(lcm, GCD(c[i], k));
                }
                writer.WriteLine(lcm == k ? "YES" : "NO");
            }
        }

        public static long GCD(long a, long b)
        {
            if (b == 0) return a >= 1 ? a : 1;
            return GCD(b, a % b);
        }
        public static long LCM(long a, long b)
        {
            long gcd = GCD(a, b);
            return (a * b) / gcd;
        }
    }
}