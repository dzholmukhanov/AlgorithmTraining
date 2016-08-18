using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class EnduringExodusCROC2016
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                int[] a = fs.ReadLine().Select(x => x == '0' ? 1 : 0).ToArray();
                int[] sum = new int[n], left = new int[n], right = new int[n];
                sum[0] = a[0];
                left[0] = a[0] == 1 ? 0 : -1;
                for (int i = 1; i < n; i++)
                {
                    sum[i] = sum[i - 1] + a[i];
                    left[i] = a[i] == 1 ? i : left[i - 1];
                }
                right[n - 1] = a[n - 1] == 1 ? n - 1 : -1;
                for (int i = n - 2; i >= 0; i--)
                {
                    right[i] = a[i] == 1 ? i : right[i + 1];
                }

                int res = int.MaxValue;
                for (int l = 0; l < n; l++)
                {
                    if (a[l] == 1) 
                    {
                        int r = LowerBound(sum, sum[l] + k, l, n - 1) + 1;
                        if (r != n)
                        {
                            int m = (l + r) / 2;
                            int dist = Math.Min(Math.Max(r - right[m], right[m] - l), Math.Max(left[m] - l, r - left[m]));
                            res = Math.Min(dist, res);
                        }
                    }
                }
                writer.WriteLine(res);
            }
        }

        public static int LowerBound<T>(T[] a, T val, int l, int r) where T : IComparable
        {
            if (a == null || a.Length == 0) return -1;

            while (l < r)
            {
                int m = (l + r) / 2;
                if (a[m].CompareTo(val) >= 0) r = m - 1;
                else
                {
                    l = m;
                    if (r == l + 1)
                    {
                        if (a[r].CompareTo(val) >= 0) return l;
                        else return r;
                    }
                }
            }
            if (l == r && a[l].CompareTo(val) < 0) return l;
            else return -1;
        }
    }
}
