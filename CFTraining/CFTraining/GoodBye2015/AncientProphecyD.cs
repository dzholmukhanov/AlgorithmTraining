using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.GoodBye2015
{
    class AncientProphecyD
    {
        private static int n;
        private static string number;
        private static long[,] dp;
        private static long[,] sums;
        private static int[,] nxt;
        public static void Run()
        {
            n = Convert.ToInt32(Console.ReadLine());
            number = Console.ReadLine();
            //number = "";
            //for (int i = 0; i < 5000; i++) number += 1;
            //n = number.Length;
            dp = new long[n, n];
            sums = new long[n, n];
            nxt = new int[n, n];
            DoItRightWay();
            Console.WriteLine(sums[n - 1, n - 1] % 1000000007);
        }
        public static int Compare(int l1, int r1, int l2, int r2)
        {
            // assuming that r1 - l1 = r2 - l2
            if (nxt[l1, l2] == -1) return 0;
            else
            {
                int t = nxt[l1, l2];
                if (l1 + t <= r1)
                {
                    if (number[l1 + t] > number[l2 + t]) return 1;
                    else return -1;
                }
                else return 0;
            }
        }
        public static void DoItRightWay()
        {
            for (int i = 0; i < n; i++) {
                dp[0, i] = 1;
                sums[0, i] = 1;
                int t = (number[n - 1] != number[i]) ? 0 : -1;
                nxt[i, n - 1] = t;
                nxt[n - 1, i] = t;
            }
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (number[i] != number[j])
                    {
                        nxt[i, j] = 0;
                        nxt[j, i] = 0;
                    }
                    else
                    {
                        int t = (nxt[i + 1, j + 1] == -1) ? -1 : nxt[i + 1, j + 1] + 1;
                        nxt[i, j] = t;
                        nxt[j, i] = t;
                    }
                }
            }
            for (int b = 1; b < n; b++)
            {
                for (int c = b; c < n; c++)
                {
                    if (number[b] == '0')
                    {
                        dp[b, c] = 0;
                    }
                    else
                    {
                        if (c > b) dp[b, c] = (sums[b - 1, b - 1] - (2 * b - c - 1 >= 0 ? sums[2 * b - c - 1, b - 1] : 0)) % 1000000007;
                        if (2 * b - c - 1 >= 0 && Compare(2 * b - c - 1, b - 1, b, c) == -1)
                            dp[b, c] = (dp[b, c] + dp[2 * b - c - 1, b - 1]) % 1000000007;
                    }
                    sums[b, c] = dp[b, c] + sums[b - 1, c];
                }
            }
        }
    }
}
