using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class RidingALift274
    {
        public static int mod = (int)1e9 + 7;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int maxFloors = fs.NextInt() + 1;
                int initialFloor = fs.NextInt();
                int secretFloor = fs.NextInt();
                int trips = fs.NextInt() + 1;
                int[,] dp = new int[maxFloors, trips];
                int[] sum = new int[maxFloors];

                for (int i = 0; i < maxFloors; i++)
                {
                    if (i == secretFloor) dp[i, 0] = 0;
                    else dp[i, 0] = 1;
                    if (i == 0) sum[i] = 1;
                    else sum[i] = sum[i - 1] + dp[i, 0];
                }
                for (int j = 1; j < trips; j++)
                {
                    for (int i = 1; i < maxFloors; i++)
                    {

                        int delta = Math.Abs(i - secretFloor) - 1;
                        int min = Math.Max(1, i - delta), max = Math.Min(maxFloors - 1, i + delta);
                        dp[i, j] = SubtractMod(sum[max], sum[min - 1]);
                        dp[i, j] = SubtractMod(dp[i, j], dp[i, j - 1]);
                    }
                    for (int i = 0; i < maxFloors; i++)
                    {
                        if (i == 0) sum[i] = dp[i, j];
                        else sum[i] = (sum[i - 1] + dp[i, j]) % mod;
                    }
                }
                writer.WriteLine(dp[initialFloor, trips - 1]);
            }
        }
        public static int SubtractMod(int a, int b)
        {
            return a - b < 0 ? mod - ((b - a) % mod) : a - b;
        }
    }
}
