using CFTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class LeavingAuction388
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                LinkedList<int>[] bidsList = new LinkedList<int>[n];
                int[] max = new int[n];
                for (int i = 0; i < n; i++)
			    {
			        bidsList[i] = new LinkedList<int>();
			    }
                for (int i = 0; i < n; i++)
                {
                    int a = fs.NextInt() - 1, b = fs.NextInt();
                    bidsList[a].AddLast(b);
                    max[a] = b;
                }
                int[][] bids = new int[n][];
                MaxSegmentTreeWithIndices segTree = new MaxSegmentTreeWithIndices(max);
                for (int i = 0; i < n; i++)
                {
                    bids[i] = bidsList[i].ToArray();
                }
                int q = fs.NextInt();
                for (int i = 0; i < q; i++)
                {
                    int k = fs.NextInt();
                    int[] notComing = new int[k];
                    for (int j = 0; j < k; j++)
                    {
                        notComing[j] = fs.NextInt();
                        segTree.Update(notComing[j] - 1, notComing[j] - 1, 0);
                    }
                    int maxIndex = -1;
                    int maxBid = segTree.QueryMax(ref maxIndex);
                    if (maxBid == 0)
                    {
                        writer.WriteLine(0 + " " + 0);
                    }
                    else
                    {
                        segTree.Update(maxIndex, maxIndex, 0);
                        int max2Index = -1;
                        int max2Bid = segTree.QueryMax(ref max2Index);
                        if (max2Bid == 0)
                        {
                            writer.WriteLine((maxIndex + 1) + " " + bids[maxIndex][0]);
                        }
                        else
                        {
                            int index = BinarySearchUpperBoundInOrdered(bids[maxIndex], max2Bid);
                            writer.WriteLine((maxIndex + 1) + " " + bids[maxIndex][index]);
                        }
                        segTree.Update(maxIndex, maxIndex, maxBid);
                    }
                    for (int j = 0; j < k; j++)
                    {
                        segTree.Update(notComing[j] - 1, notComing[j] - 1, max[notComing[j] - 1]);
                    }
                }
            }
        }
        public static int BinarySearchUpperBoundInOrdered<T>(T[] a, T val) where T : IComparable
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
