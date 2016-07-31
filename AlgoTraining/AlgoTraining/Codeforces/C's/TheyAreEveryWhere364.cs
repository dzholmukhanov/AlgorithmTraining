using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class TheyAreEveryWhere364
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                string s = fs.ReadLine();
                int[] count = new int[52];
                int total = 0;
                foreach (char c in s)
                {
                    if (count[Index(c)] == 0) total++;
                    count[Index(c)]++;
                }
                count = new int[52];
                int k = 0, ans = int.MaxValue;
                for (int l = 0, r = -1; l < n; l++)
                {
                    if (l > r)
                    {
                        r = l;
                        if (count[Index(s[l])] == 0) k++;
                        count[Index(s[l])]++;
                    }
                    while (k < total && r < n - 1)
                    {
                        r++;
                        if (count[Index(s[r])] == 0) k++;
                        count[Index(s[r])]++;
                    }
                    if (k == total) ans = Math.Min(ans, r - l + 1);
                    else break;
                    if (count[Index(s[l])] == 1) k--;
                    count[Index(s[l])]--;
                }
                writer.WriteLine(ans);
            }
        }
        public static int Index(char c) {
            if (c >= 'a' && c <= 'z') return c - 'a';
            else return c - 'A' + 26;
        }
    }
}
