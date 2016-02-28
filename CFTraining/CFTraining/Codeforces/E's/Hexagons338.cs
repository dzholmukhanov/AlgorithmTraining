using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.E_s
{
    class Hexagons338
    {
        public static void Run()
        {
            long n = Convert.ToInt64(Console.ReadLine());
            int maxLoop = int.MaxValue / 3;

            if (n == 0)
            {
                Console.WriteLine(0 + " " + 0);
                return;
            }
            //577350269
            int currentLoop = LoopBinSearch(0, maxLoop, n) + 1;
            long localSteps = n - 3 * (long) currentLoop * (currentLoop - 1) - 1;

            long[] corners = new long[6];
            corners[1] = currentLoop - 1;
            for (int i = 2; i < 6; i++)
            {
                corners[i] = currentLoop + corners[i - 1];
            }
            int currentCorner = CornerBinSearch(corners, 0, 5, localSteps);
            long localCornerSteps = localSteps - corners[currentCorner];


            Tuple<long, long>[] points = new Tuple<long, long>[6] { 
                new Tuple<long, long>(2 * currentLoop, 0),
                new Tuple<long, long>(currentLoop, 2 * currentLoop),
                new Tuple<long, long>(-currentLoop, 2 * currentLoop),
                new Tuple<long, long>(-2 * currentLoop, 0),
                new Tuple<long, long>(-currentLoop, -2 * currentLoop),
                new Tuple<long, long>(currentLoop, -2 * currentLoop)
            };

            Tuple<long, long>[] vectors = new Tuple<long, long>[6] { 
                new Tuple<long, long>(-1, 2),
                new Tuple<long, long>(-2, 0),
                new Tuple<long, long>(-1, -2),
                new Tuple<long, long>(1, -2),
                new Tuple<long, long>(2, 0),
                new Tuple<long, long>(1, 2)
            };
            if (currentCorner == 0) localCornerSteps++;
            Tuple<long, long> result = new Tuple<long, long>(points[currentCorner].Item1 + vectors[currentCorner].Item1 * localCornerSteps, points[currentCorner].Item2 + vectors[currentCorner].Item2 * localCornerSteps);
            Console.WriteLine(result.Item1 + " " + result.Item2);
        }
        public static int LoopBinSearch(int l, int r, long val)
        {
            if (l > r) return -1;

            int n = l + (r - l) / 2;
            long left = 3 * (long)n * ((long)n + 1) + 1, right = 3 * ((long)n + 1) * ((long)n + 2) + 1;
            if (left == val) return n;
            else if (right == val) return n + 1;
            else if (left > val && right > val) return LoopBinSearch(l, n, val);
            else if (left < val && right < val) return LoopBinSearch(n + 1, r, val);
            else return n;
        }
        public static int CornerBinSearch(long[] a, int l, int r, long val)
        {
            if (a[r] < val) return r;
            else if (l >= r) return -1;

            int m = l + (r - l) / 2;
            if (a[m] == val) return m;
            else if (m + 1 <= r && a[m + 1] == val) return m + 1;
            if (a[m] < val && a[m + 1] < val) return CornerBinSearch(a, m + 1, r, val);
            else if (a[m] > val && a[m + 1] > val) return CornerBinSearch(a, l, m, val);
            else return m;
        }
    }
}
