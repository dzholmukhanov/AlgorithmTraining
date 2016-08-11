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
                    int ind = Find(b, 0, m - 1, a[i]);
                    int min;
                    if (ind != -1)
                    {
                        min = 0;
                    }
                    else
                    {
                        int l = LowerBound(b, a[i]);
                        int u = UpperBound(b, a[i]);
                        min = Math.Min(l != -1 ? a[i] - l : int.MaxValue, u != -1 ? u - a[i] : int.MaxValue);
                    }
                    max = Math.Max(max, min);
                }
                writer.WriteLine(max);
            }
        }
        public static int Find(int[] a, int l, int r, int val)
        {
            if (l > r) return -1;
            else if (l == r)
            {
                if (a[l] == val) return l;
                else return -1;
            }
            int m = (l + r) / 2;
            if (val < a[m]) return Find(a, l, m - 1, val);
            else if (val > a[m]) return Find(a, m + 1, r, val);
            else return m;
        }
        public static int LowerBound(int[] a, int val)
        {
            if (a == null)
                throw new ArgumentNullException("list");
            int l = 0, r = a.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (a[mid] > val) r = mid - 1;
                else if (a[mid] <= val)
                {
                    if (a[mid + 1] > val) return a[mid];
                    else l = mid + 1;
                }
            }
            if (l >= 0 && l == r && a[l] <= val) return a[l];
            else return -1;
        }
        public static int UpperBound(int[] a, int val)
        {
            if (a == null)
                throw new ArgumentNullException("list");
            int l = 0, r = a.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (a[mid] <= val) l = mid + 1;
                else if (a[mid] > val)
                {
                    if (mid == 0 || a[mid - 1] <= val) return a[mid];
                    else r = mid - 1;
                }
            }
            if (l >= 0 && l == r && a[l] > val) return a[l];
            else return -1;
        }
    }
}
