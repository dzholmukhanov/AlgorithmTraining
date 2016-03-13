using CFTraining.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    // not solved
    class ReverseComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x < y ? 1 : x > y ? -1 : 0;
        }
    }
    class Report344
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                List<Manager> managers = new List<Manager>(m);
                for (int i = 0; i < m; i++)
                {
                    int t = fs.NextInt(), r = fs.NextInt();
                    managers.Add(new Manager { Id = i, R = r, T = t });
                }
                managers = managers.OrderByDescending(x => x.R).ToList();
                bool[] ignore = new bool[m];
                int lastId = managers[0].Id;
                int lastT = managers[0].T;
                for (int i = 1; i < m; i++)
                {
                    if (managers[i].Id > lastId)
                    {
                        lastId = managers[i].Id;
                        if (managers[i].T != lastT)
                        {
                            lastT = managers[i].T;
                        }
                        else ignore[managers[i].Id] = true;
                    }
                    else ignore[managers[i].Id] = true;
                }
                ReverseComparer revComparer = new ReverseComparer();

                if (managers[0].T == 1) Array.Sort(a, 0, managers[0].R);
                else Array.Sort(a, 0, managers[0].R, revComparer);
                int[] b = a.ToArray();

                int left = 0, right = managers[0].R - 1, pointer = right;
                bool fromLeft = false;
                for (int i = 1; i < m; i++)
                {
                    if (ignore[managers[i].Id]) continue;
                    for (int j = pointer; j >= managers[i].R; j--)
                    {
                        if (fromLeft) {
                            a[pointer--] = b[left++];
                        }
                        else
                        {
                            a[pointer--] = b[right--];
                        }
                    }
                    fromLeft = !fromLeft;
                }
                for (int j = pointer; j >= 0; j--)
                {
                    if (fromLeft)
                    {
                        a[j] = b[left++];
                    }
                    else
                    {
                        a[j] = b[right--];
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    writer.Write(a[i] + " ");
                }
            }
        }
    }
    class Manager
    {
        public int Id, T, R;
    }
}
