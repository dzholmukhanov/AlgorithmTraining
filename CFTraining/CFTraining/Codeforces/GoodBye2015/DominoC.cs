using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.GoodBye2015
{
    class DominoC
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int h = Convert.ToInt32(line[0]), w = Convert.ToInt32(line[1]);
            bool[,] isFree = new bool[h, w];
            int[,] dp = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                string t = Console.ReadLine();
                for (int j = 0; j < w; j++)
                {
                    isFree[i, j] = (t[j] == '.');
                }
            }
            int q = Convert.ToInt32(Console.ReadLine());
            for (int j = 1; j < w; j++)
            {
                if (!isFree[0, j] || !isFree[0, j - 1])
                    dp[0, j] = dp[0, j - 1];
                else
                    dp[0, j] = dp[0, j - 1] + 1;
            }
            for (int i = 1; i < h; i++)
            {
                if (!isFree[i, 0] || !isFree[i - 1, 0])
                    dp[i, 0] = dp[i - 1, 0];
                else
                    dp[i, 0] = dp[i - 1, 0] + 1;
            }
            for (int i = 1; i < h; i++)
            {
                for (int j = 1; j < w; j++)
                {
                    int temp = isFree[i, j] && (isFree[i - 1, j] || isFree[i, j - 1]) ? (isFree[i - 1, j] && isFree[i, j - 1] ? 2 : 1) : 0;
                    dp[i, j] = (dp[i - 1, j] - dp[i - 1, j - 1]) + dp[i, j - 1] + temp;
                }
            }
            while (q-- > 0)
            {
                line = Console.ReadLine().Split(' ');
                int r1 = Convert.ToInt32(line[0]) - 1,
                    c1 = Convert.ToInt32(line[1]) - 1,
                    r2 = Convert.ToInt32(line[2]) - 1,
                    c2 = Convert.ToInt32(line[3]) - 1;
                int count = 0;
                if (r1 > 0 && c1 > 0) count = dp[r2, c2] - (dp[r1 - 1, c2] - dp[r1 - 1, c1 - 1]) - dp[r2, c1 - 1];
                else if (r1 > 0) count = dp[r2, c2] - dp[r1 - 1, c2];
                else if (c1 > 0) count = dp[r2, c2] - dp[r2, c1 - 1];
                else count = dp[r2, c2];
                if (r1 > 0)
                {
                    for (int j = c1; j <= c2; j++)
                    {
                        if (isFree[r1, j] && isFree[r1 - 1, j]) count--;
                    }
                }
                if (c1 > 0)
                {
                    for (int i = r1; i <= r2; i++)
                    {
                        if (isFree[i, c1] && isFree[i, c1 - 1]) count--;
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}
