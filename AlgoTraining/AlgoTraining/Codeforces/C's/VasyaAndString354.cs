using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class VasyaAndString354
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                string s = fs.ReadLine();
                int max = Solve(s, n, k, 'a');
                max = Math.Max(Solve(s, n, k, 'b'), max);
                writer.WriteLine(max);
            }
        }
        public static int Solve(string s, int n, int k, char c)
        {
            int l = 0, r = 0, count = 0, max = 0;
            if (s[0] != c) count++;
            if (count <= k) max = 1;
            while (r < n - 1)
            {
                while (count > k && r < n)
                {
                    if (l < r && s[l] != c) count--;
                    l++;
                    if (l > r)
                    {
                        if (s[r] != c) count--;
                        r = l;
                        if (r < n && s[r] != c) count++;
                    }
                }
                if (r >= n) break;
                max = Math.Max(max, r - l + 1);
                while (count <= k && r < n - 1)
                {
                    r++;
                    if (s[r] != c) count++;
                    if (count <= k) max = Math.Max(max, r - l + 1);
                }
            }
            return max;
        }
    }
}
