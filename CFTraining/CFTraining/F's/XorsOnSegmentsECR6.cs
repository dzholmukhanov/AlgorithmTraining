using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.F_s
{
    class XorsOnSegmentsECR6
    {
        // Not solved yet! Should throw OutOfMemoryException
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt(), m = sc.NextInt();
            int[] a = new int[n];
            int[] pref = new int[(int)3e6];
            for (int i = 0; i < n; i++)
            {
                a[i] = sc.NextInt();
            }
            for (int i = 1; i < pref.Length; i++)
            {
                pref[i] = i ^ pref[i - 1];
            }
            int[,] dp = new int[n, n];
            for (int r = 0; r < n; r++)
            {
                for (int l = r; l >= 0; l--)
                {
                    if (l == r) dp[l, r] = a[l];
                    else
                    {
                        int xor1 = 0;
                        if (a[l] <= a[r]) xor1 = pref[a[r]] ^ (a[l] > 0 ? pref[a[l] - 1] : 0);
                        int xor2 = 0;
                        if (a[r] < a[l]) xor2 = pref[a[l]] ^ (a[r] > 0 ? pref[a[r] - 1] : 0);
                        dp[l, r] = Math.Max(dp[l, r - 1], Math.Max(dp[l + 1, r], Math.Max(xor1, xor2)));
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            while (m-- > 0)
            {
                int l = sc.NextInt() - 1, r = sc.NextInt() - 1;
                sb.Append(dp[l, r] + "\n");
            }
            Console.WriteLine(sb);
        }
    }
}
