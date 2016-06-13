using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class TrainsAndStatistic353
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n - 1; i++)
                {
                    a[i] = fs.NextInt() - 1;
                }
                long[] dp = new long[n];
                long sum = 1;
                dp[n - 2] = 1;
                for (int i = n - 3; i >= 0; i--)
                {
                    dp[i] = dp[a[i]] + n - 1 - i;
                    sum += dp[i];
                }
                writer.WriteLine(sum);
            } 
        }
    }
}
