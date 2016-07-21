using AlgoTraining.DataStructures;
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
    class SwapsInPermutationECR14
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int[] p = new int[n];
                DisjointSet dsu = new DisjointSet();
                for (int i = 0; i < n; i++)
                {
                    p[i] = fs.NextInt() - 1;
                    dsu.MakeSet(i);
                }
                for (int i = 0; i < m; i++)
                {
                    int u = fs.NextInt() - 1, v = fs.NextInt() - 1;
                    dsu.Union(p[u], p[v]);
                }

                LinkedList<int>[] lists = new LinkedList<int>[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    int set = dsu.FindSet(i);
                    if (lists[set] == null) lists[set] = new LinkedList<int>();
                    lists[set].AddLast(i);
                }
                for (int i = 0; i < n; i++)
                {
                    int set = dsu.FindSet(p[i]);
                    writer.Write(lists[set].First() + 1 + " ");
                    lists[set].RemoveFirst();
                }
            }
        }
    }
}