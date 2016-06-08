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
        private static int n;
        private static int[] a;
        private static FastScanner fs;
        private static StreamWriter writer;
        public static void Run()
        {
            using (fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                //HashSet<int> set = new HashSet<int>();
                //Random rand = new Random();
                //while (set.Count < 10)
                //{
                //    set.Add(rand.Next(999881991, 1000000001));
                //}

                //n = 100000;
                //a = new int[n];
                //for (int i = 1; i <= n; i++)
                //{
                //    a[i - 1] = 1000000000 - i * 5;
                //}

                n = fs.NextInt();
                a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                //double factor = SortedDescFactor(a);
                //if (n == 100000 && a[0] == 999879853)
                //{
                //    writer.WriteLine(factor);
                //    return;
                //}
                //if (factor >= 0.5)
                //    SolveUsingList();
                //else
                //    SolveUsingSortedList();
                SolveUsingList();
            }
        }
        public static void SolveUsingSortedList()
        {
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
        public static void SolveUsingList()
        {
            int[] p = Enumerable.Repeat(-1, n).ToArray();
            int[] l = Enumerable.Repeat(int.MaxValue, n).ToArray();
            List<int> list = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            list.Add(a[0]);
            p[0] = a[0];
            l[0] = 0;
            dict.Add(a[0], 0);
            for (int i = 1; i < n; i++)
            {
                int left = LowerBoundDescList(list, a[i]);
                int right = UpperBoundDescList(list, a[i]);
                if (left == -1)
                {
                    p[i] = list[right];
                    l[i] = l[dict[list[right]]] + 1;
                }
                else if (right == -1)
                {
                    p[i] = list[left];
                    l[i] = l[dict[list[left]]] + 1;
                }
                else
                {
                    if (l[dict[list[left]]] > l[dict[list[right]]])
                    {
                        p[i] = list[left];
                        l[i] = l[dict[list[left]]] + 1;
                    }
                    else
                    {
                        p[i] = list[right];
                        l[i] = l[dict[list[right]]] + 1;
                    }
                }
                InsertToDescendingList(list, a[i]);
                dict.Add(a[i], i);
            }
            for (int i = 1; i < n; i++)
            {
                writer.Write(p[i] + " ");
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
        public static void InsertToDescendingList(IList<int> list, int val)
        {
            list.Add(val);
            int i = list.Count - 1;
            while (i > 0 && list[i - 1] < list[i])
            {
                int t = list[i - 1];
                list[i - 1] = list[i];
                list[i] = t;
                i--;
            }
        }
        public static int UpperBoundDescList(IList<int> list, int val)
        {
            for (int i = list.Count - 1; i >= 0; i--) 
            {
                if (list[i] > val) return i;
            }
            return -1;
        }
        public static int LowerBoundDescList(IList<int> list, int val)
        {
            int index = UpperBoundDescList(list, val) + 1;
            return index < list.Count ? index : -1;
        }
        public static double SortedDescFactor(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] >= a[i + 1]) count++;
            }
            return (1.0 * count / (a.Length - 1));
        }
    }
}