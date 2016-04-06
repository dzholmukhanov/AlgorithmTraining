using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class RoundHouse346
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), a = fs.NextInt() - 1, b = fs.NextInt();
                if (b != 0) b = b / Math.Abs(b) * (Math.Abs(b) % n);
                int ans = a + b;
                if (ans >= n) ans %= n;
                else if (ans < 0) ans = n + ans;
                writer.WriteLine(ans + 1);
            }
        }
    }
}
