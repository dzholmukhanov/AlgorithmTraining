using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.HackerRank
{
    class CoinChange
    {
        private static List<int> coins = new List<int>();
        private static long[,] GC;
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(line[0]), M = Convert.ToInt32(line[1]);
            GC = new long[M + 1, N + 1];
            line = Console.ReadLine().Split(' ');
            for (int i = 0; i <= M; i++)
            {
                if (i < M) coins.Add(Convert.ToInt32(line[i]));
                for (int j = 0; j <= N; j++)
                {
                    if (j == 0) GC[i, 0] = 1;
                    else if (i == M) GC[M, j] = 0;
                    else GC[i, j] = -1;
                }
            }
            coins.OrderByDescending(x => x);
            Console.WriteLine(GetChanges(0, N));
        }
        private static long GetChanges(int current, int remainingSum)
        {
            if (GC[current, remainingSum] == -1)
            {
                if (coins[current] <= remainingSum)
                {
                    long res = 0;
                    for (int i = 1; i <= remainingSum / coins[current]; i++)
                    {
                        res += GetChanges(current + 1, remainingSum - coins[current] * i);
                    }
                    GC[current, remainingSum] = res + GetChanges(current + 1, remainingSum);
                }
                else GC[current, remainingSum] = GetChanges(current + 1, remainingSum);
            }
            return GC[current, remainingSum];
        }
    }
}
