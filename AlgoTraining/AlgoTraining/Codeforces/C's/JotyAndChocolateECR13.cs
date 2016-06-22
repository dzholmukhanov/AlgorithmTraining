using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class JotyAndChocolateECR13
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long n = fs.NextInt();
                long a = fs.NextInt();
                long b = fs.NextInt();
                long p = fs.NextInt();
                long q = fs.NextInt();
                long lcm = LCM(a, b);
                long ans = n / a * p + n / b * q - n / lcm * Math.Min(p, q);
                writer.WriteLine(ans);
            }
        }
        public static long GCD(long a, long b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }
        public static long LCM(long a, long b)
        {
            long gcd = GCD(a, b);
            return a * b / gcd;
        }
    }
}
