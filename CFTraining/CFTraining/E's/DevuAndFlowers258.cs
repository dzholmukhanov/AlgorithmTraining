using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.E_s
{
    class DevuAndFlowers258
    {
        // Not passed
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            long n = Convert.ToInt64(line[0]) + 1,
                 s = Convert.ToInt64(line[1]) + 1;
            long[] f = new long[n];
            line = Console.ReadLine().Split(' ');
            for (int i = 1; i < n; i++)
            {
                f[i] = Convert.ToInt64(line[i - 1]);
            }
            long[,] dp = new long[s, n];
            for (int i = 0; i < n; i++)
                dp[0, i] = 1;
            for (int i = 1; i < s; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i, j - 1];
                    for (int k = 1; k <= Math.Min(f[j], i); k++)
                    {
                        dp[i, j] += dp[i - k, j - 1];
                    }
                }
            }
            /*
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(dp[i, j] + " ");
                }
                Console.WriteLine();
            }
             * */
            Console.WriteLine(dp[s - 1, n - 1]);
        }
    }
}
