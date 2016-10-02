using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class Buses79
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int mod = (int)1e9 + 7;
                Dictionary<int, BusStop> dict = new Dictionary<int, BusStop>();
                for (int i = 0; i < m; i++)
                {
                    int s = fs.NextInt(), t = fs.NextInt();
                    if (!dict.ContainsKey(s)) dict[s] = new BusStop { X = s, BusesArriveFrom = new LinkedList<int>() };
                    if (!dict.ContainsKey(t)) dict[t] = new BusStop { X = t, BusesArriveFrom = new LinkedList<int>() };
                    dict[t].BusesArriveFrom.AddLast(s);
                }
                if (!dict.ContainsKey(0) || !dict.ContainsKey(n))
                {
                    writer.WriteLine(0);
                    return;
                }
                BusStop[] stops = dict.Select(x => x.Value).OrderBy(x => x.X).ToArray();
                n = stops.Length;
                long[] dp = new long[n];
                long[] sum = new long[n];
                dp[0] = 1;
                sum[0] = 1;
                for (int i = 1; i < n; i++)
                {
                    foreach (var start in stops[i].BusesArriveFrom)
                    {
                        int j = BinarySearchInOrdered(stops, new BusStop { X = start });
                        dp[i] = ModWithReverse(dp[i] + sum[i - 1] - (j - 1 >= 0 ? sum[j - 1] : 0), mod);
                    }
                    sum[i] = ModWithReverse(dp[i] + sum[i - 1], mod);
                }
                writer.WriteLine(dp[n - 1]);
            }
        }
        public static long ModWithReverse(long x, int mod)
        {
            if (x >= 0) return x % mod;
            else return mod + (x % mod);
        }
        public static int BinarySearchInOrdered<T>(T[] a, T val) where T : IComparable
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
    }
    class BusStop: IComparable
    {
        public int X;
        public LinkedList<int> BusesArriveFrom;
        public int CompareTo(object other)
        {
            return this.X.CompareTo(((BusStop)other).X);
        }
    }
}
