using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class ChainReaction336
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int maxX = 1000000;
            int[] pos = new int[maxX + 1];
            int[] dp = new int[maxX + 1];
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(line[0]);
                int p = Convert.ToInt32(line[1]);
                pos[x] = p;
            }
            int maxSurvived = 0;
            for (int i = 0; i <= maxX; i++)
            {
                if (pos[i] != 0)
                {
                    if (i - pos[i] - 1 < 0) dp[i] = 1;
                    else dp[i] = dp[i - pos[i] - 1] + 1;
                    maxSurvived = Math.Max(maxSurvived, dp[i]);
                }
                else if (i > 0) dp[i] = dp[i - 1];
            }
            Console.WriteLine(n - maxSurvived);
        }

    }
}
