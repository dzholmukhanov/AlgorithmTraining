using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class PalindromeDegree7
    {
        private static long[] hashS, hashR, pows;
        private static int n, p = 67;

        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string s = fs.ReadLine(), r = new string(s.Reverse().ToArray());
                n = s.Length;
                hashS = new long[n];
                hashR = new long[n];
                pows = new long[n];
                hashS[0] = ToLong(s[0]);
                hashR[0] = ToLong(r[0]);
                pows[0] = 1;
                for (int i = 1; i < n; i++)
                {
                    pows[i] = pows[i - 1] * p;
                }
                for (int i = 1; i < n; i++)
                {
                    hashS[i] = hashS[i - 1] + ToLong(s[i]) * pows[i];
                    hashR[i] = hashR[i - 1] + ToLong(r[i]) * pows[i];
                }
                int[] dp = new int[n];
                dp[0] = 1;
                if (n > 1) dp[1] = s[0] == s[1] ? 2 : 0;
                if (n > 2) dp[2] = s[0] == s[2] ? 2 : 0;
                for (int i = 3; i < n; i++)
                {
                    int mid = i / 2;
                    if (i % 2 == 0)
                    {
                        if (IsPalindrome(0, mid - 1, mid + 1, i))
                        {
                            dp[i] = dp[mid - 1] + 1;
                        }
                    }
                    else
                    {
                        if (IsPalindrome(0, mid, mid + 1, i))
                        {
                            dp[i] = dp[mid] + 1;
                        }
                    }
                }
                writer.WriteLine(dp.Sum());
            }
        }

        private static bool IsPalindrome(int l1, int r1, int l2, int r2)
        {
            long hash1 = hashS[r1] - (l1 - 1 >= 0 ? hashS[l1 - 1] : 0);
            long hash2 = hashR[n - l2 - 1] - (n - r2 - 2 >= 0 ? hashR[n - r2 - 2] : 0);
            int pow = n - r2 - 1;
            hash1 *= pows[pow];
            return hash1 == hash2;
        }
        private static long ToLong(char ch)
        {
            if (ch >= 'a' && ch <= 'z') return ch - 'a' + 1; // 1 - 26
            else if (ch >= 'A' && ch <= 'Z') return ch - 'A' + 27; // 27 - 52
            else return ch - '0' + 53; // 53 - 62
        }
    }
}
