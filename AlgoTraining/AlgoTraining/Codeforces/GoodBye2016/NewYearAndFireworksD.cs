using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.GoodBye2016
{
    class NewYearAndFireworksD
    {
        private static int n;
        private static int[] t;
        private static bool[, , ,] dp = new bool[301, 301, 8, 30];
        private static int[][] dir = new int[][] 
        {
            new int[] { 0, 1 },
            new int[] { -1, 1 },
            new int[] { -1, 0 },
            new int[] { -1, -1 },
            new int[] { 0, -1 },
            new int[] { 1, -1 },
            new int[] { 1, 0 },
            new int[] { 1, 1 }
        };
        private static bool[,] grid = new bool[301, 301];

        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                n = fs.NextInt();
                t = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                Fire(151, 150, 2, 0);
                int count = 0;
                for (int i = 0; i < 301; i++)
                {
                    for (int j = 0; j < 301; j++)
                    {
                        if (grid[i, j]) count++;
                    }
                }
                writer.WriteLine(count);
            }
        }
        public static void Fire(int i, int j, int direction, int iteration)
        {
            if (iteration == n || dp[i, j, direction, iteration]) return;
            dp[i, j, direction, iteration] = true;
            int di = dir[direction][0], dj = dir[direction][1];
            int lifeTime = t[iteration];
            while (lifeTime-- > 0)
            {
                i += di;
                j += dj;
                grid[i, j] = true;
            }
            Fire(i, j, direction == 0 ? 7 : direction - 1, iteration + 1);
            Fire(i, j, direction == 7 ? 0 : direction + 1, iteration + 1);
        }
    }
}
