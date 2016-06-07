using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class TreeConstruction353
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                //HashSet<int> set = new HashSet<int>();
                //Random rand = new Random();
                //while (set.Count < 10)
                //{
                //    set.Add(rand.Next(999881991, 1000000001));
                //}

                //int n = 10;
                //int[] a = set.ToArray();
                //writer.WriteLine("Danzo!: Count = " + set.Count);
                ////for (int i = 1; i <= n; i++)
                ////{
                ////    a[i - 1] = i * 5;
                ////}
                ////a = a.OrderBy(x => Guid.NewGuid()).ToArray();

                int n = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }

                int[] p = Enumerable.Repeat(-1, n).ToArray();
                int[] l = Enumerable.Repeat(int.MaxValue, n).ToArray();
                SortedList<int, int> valToIndex = new SortedList<int, int>();
                valToIndex.Add(a[0], 0);
                p[0] = a[0];
                l[0] = 0;
                for (int i = 1; i < n; i++)
                {
                    int left = LowerBound(valToIndex.Keys, a[i]);
                    int right = UpperBound(valToIndex.Keys, a[i]);
                    if (left == -1)
                    {
                        p[i] = right;
                        l[i] = l[valToIndex[right]] + 1;
                    }
                    else if (right == -1)
                    {
                        p[i] = left;
                        l[i] = l[valToIndex[left]] + 1;
                    }
                    else
                    {
                        if (l[valToIndex[left]] > l[valToIndex[right]])
                        {
                            p[i] = left;
                            l[i] = l[valToIndex[left]] + 1;
                        }
                        else
                        {
                            p[i] = right;
                            l[i] = l[valToIndex[right]] + 1;
                        }
                    }
                    valToIndex.Add(a[i], i);
                }
                for (int i = 1; i < n; i++)
                {
                    writer.Write(p[i] + " ");
                }
            }
        }
        public static int LowerBound(IList<int> list, int val)
        {
            if (list == null) 
                throw new ArgumentNullException("list");
            int l = 0, r = list.Count - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (list[mid] > val) r = mid - 1;
                else if (list[mid] <= val)
                {
                    if (list[mid + 1] > val) return list[mid];
                    else l = mid + 1;
                }
            }
            if (l >= 0 && l == r && list[l] <= val) return list[l];
            else return -1;
        }
        public static int UpperBound(IList<int> list, int val)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            int l = 0, r = list.Count - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (list[mid] <= val) l = mid + 1;
                else if (list[mid] > val)
                {
                    if (mid == 0 || list[mid - 1] <= val) return list[mid];
                    else r = mid - 1;
                }
            }
            if (l >= 0 && l == r && list[l] > val) return list[l];
            else return -1;
        }
    }
}
