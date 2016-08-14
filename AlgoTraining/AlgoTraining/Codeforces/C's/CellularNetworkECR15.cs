using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class CellularNetworkECR15
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int[] a = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                int[] b = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                int max = -1;
                for (int i = 0; i < n; i++)
                {
                    int ind = Find(b, a[i]);
                    int min;
                    if (ind != -1)
                    {
                        min = 0;
                    }
                    else
                    {
                        int l = FindLowerBound(b, a[i]);
                        int u = FindUpperBound(b, a[i]);
                        min = Math.Min(l != -1 ? a[i] - b[l] : int.MaxValue, u != -1 ? b[u] - a[i] : int.MaxValue);
                    }
                    max = Math.Max(max, min);
                }
                writer.WriteLine(max);
            }
        }
        public static int Find<T>(T[] a, T val) where T : IComparable
        {
            if (a == null || a.Length == 0) return -1;

            int l = 0, r = a.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (a[m].CompareTo(val) < 0)
                {
                    l = m + 1;
                }
                else if (a[m].CompareTo(val) > 0)
                {
                    r = m - 1;
                }
                else return m;
            }
            if (l == r && a[l].CompareTo(val) == 0) return l;
            else return -1;
        }
        public static int FindLowerBound<T>(T[] a, T val) where T : IComparable
        {
            if (a == null || a.Length == 0) return -1;

            int l = 0, r = a.Length - 1;
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
        public static int FindUpperBound<T>(T[] a, T val) where T : IComparable
        {
            if (a == null || a.Length == 0) return -1;

            int l = 0, r = a.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (a[m].CompareTo(val) <= 0) l = m + 1;
                else
                {
                    r = m;
                    if (r == l + 1)
                    {
                        if (a[l].CompareTo(val) <= 0) return r;
                        else return l;
                    }
                }
            }
            if (l == r && a[r].CompareTo(val) > 0) return r;
            else return -1;
        }
    }
}
