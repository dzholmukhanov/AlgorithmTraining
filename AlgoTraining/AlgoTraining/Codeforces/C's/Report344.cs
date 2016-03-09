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
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(int x, int y)
        {
            return y - x;
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
                bool[] ig = new bool[m];
                int lastId = managers[0].Id;
                int lastT = managers[0].T;
                for (int i = 1; i < m; i++)
                {
                    if (managers[i].Id > lastId)
                    {
                        lastId = managers[i].Id;
                    }
                    else ig[i] = true;
                    if (managers[i].T != lastT)
                    {
                        lastT = managers[i].T;
                    }
                    else ig[i] = true;
                }
                ReverseComparer revComparer = new ReverseComparer();

                if (managers[0].T == 1) Array.Sort(a, 0, managers[0].R);
                else Array.Sort(a, 0, managers[0].R, revComparer);
                int[] b = a.ToArray();

                int left = 0, right = managers[0].R - 1;
                bool fromLeft = false;
                for (int i = 1; i < m; i++)
                {
                    if (ig[i]) continue;
                    for (int j = right; j >= managers[i].R; j--)
                    {
                        if (fromLeft) {
                            a[j] = b[left++];
                        }
                        else
                        {
                            a[j] = b[right--];
                        }
                    }
                    fromLeft = !fromLeft;
                }
                for (int j = right; j >= 0; j--)
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
