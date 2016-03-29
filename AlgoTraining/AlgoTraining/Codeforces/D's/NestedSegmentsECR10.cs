using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class NestedSegmentsECR10 // Incomplete
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                Point[] points = new Point[2 * n];
                int[] beg = new int[n];
                int j = 0;
                for (int i = 0; i < n; i++)
                {
                    beg[i] = fs.NextInt();
                    points[j++] = new Point { SegmentId = i, X = beg[i], IsEnd = false };
                    points[j++] = new Point { SegmentId = i, X = fs.NextInt(), IsEnd = true };
                }
                points = points.OrderBy(s => s.X).ToArray();

                List<int> openSegms = new List<int>();
                int[] ans = new int[n];
                foreach (Point p in points)
                {
                    if (!p.IsEnd)
                    {
                        openSegms.Add(p.X);
                    }
                    else
                    {
                        int index = findItem(openSegms, 0, openSegms.Count - 1, beg[p.SegmentId]);
                        for (int i = index - 1; i >= 0; i--)
                        {
                            ans[openSegms[index - 1]] += ans[p.SegmentId] + 1;
                            if (i > 0 && )
                        }
                        openSegms.RemoveAt(index);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    writer.WriteLine(ans[i]);
                }
            }
        }

        private static int findItem(List<int> a, int l, int r, int p)
        {
            if (l > r) return -1;
            int mid = (r + l) / 2;
            if (a[mid] < p) return findItem(a, mid + 1, r, p);
            else if (a[mid] > p) return findItem(a, 0, mid - 1, p);
            else return mid;
        }
    }
    class Point
    {
        public int SegmentId, X;
        public bool IsEnd;
    }
}
