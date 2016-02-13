using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.HackerRank
{
    class LongestIncreasingSubsequence
    {
        public static void RunNlogN() // NlogN
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            int[] a = new int[n], tails = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = sc.NextInt();
            }
            tails[0] = a[0];
            int spot = 1;
            for (int i = 1; i < n; i++)
            {
                if (tails[0] >= a[i]) tails[0] = a[i];
                else if (tails[spot - 1] <= a[i])
                {
                    if (tails[spot - 1] < a[i]) tails[spot++] = a[i];
                }
                else tails[searchSpot(tails, 0, spot - 1, a[i])] = a[i];
            }
            Console.WriteLine(spot);
        }
        public static int searchSpot(int[] a, int l, int r, int val)
        {
            while (r - l > 1)
            {
                int mid = (l + r) / 2;
                if (a[mid] >= val) r = mid;
                else l = mid;
            }
            return r;
        }
        public static void RunDP() // N ^ 2
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            int[] a = new int[n];
            int[] dp = new int[n];
            dp[0] = 1;
            for (int i = 0; i < n; i++)
            {
                a[i] = sc.NextInt();
                if (i > 0)
                {
                    int ind = -1, len = 0;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (a[j] < a[i] && dp[j] > len)
                        {
                            len = dp[j];
                            ind = j;
                        }
                    }
                    dp[i] = (ind == -1) ? 1 : dp[ind] + 1;
                }
            }
            Console.WriteLine(dp.Max());
        }
    }
}
