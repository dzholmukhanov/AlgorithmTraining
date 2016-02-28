using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.HackerRank
{
    class BricksGame
    {
        private static int[] a;
        private static long[] dp, sum;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                while (t-- > 0)
                {
                    int n = fs.NextInt();
                    dp = Enumerable.Repeat<long>(-1, n).ToArray();
                    a = new int[n];
                    sum = new long[n];
                    for (int i = 0; i < n; i++)
                    {
                        a[i] = fs.NextInt();
                    }
                    sum[n - 1] = a[n - 1];
                    for (int i = n - 2; i >= 0; i--) 
                    {
                        sum[i] = a[i] + sum[i + 1];
                    }
                    for (int i = Math.Max(n - 3, 0); i < n; i++)
                    {
                        for (int j = i; j < n; j++)
                        {
                            if (dp[j] == -1) dp[j] = 0;
                            dp[i] += a[j];
                        }
                    }
                    writer.WriteLine(Solve(0));
                }
            }
        }
        public static long Solve(int i)
        {
            if (dp[i] == -1)
            {
                dp[i] = Math.Max(a[i] + sum[i + 1] - Solve(i + 1), Math.Max(a[i] + a[i + 1] + sum[i + 2] - Solve(i + 2), a[i] + a[i + 1] + a[i + 2] + sum[i + 3] - Solve(i + 3)));
            }
            return dp[i];
        }
    }
}
