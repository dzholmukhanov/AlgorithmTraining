using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class FixaTree363
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                LinkedList<int>[] adjList = new LinkedList<int>[n];
                int[] p = new int[n];
                for (int i = 0; i < n; i++)
                {
                    adjList[i] = new LinkedList<int>();
                }
                for (int u = 0; u < n; u++)
                {
                    int v = fs.NextInt() - 1;
                    p[u] = v;
                    adjList[u].AddLast(v);
                    if (u != v) adjList[v].AddLast(u);
                }
                LinkedList<int> comps = new LinkedList<int>();
                bool[] visited = new bool[n];
                for (int u = 0; u < n; u++)
                {
                    if (!visited[u]) 
                    {
                        int r = -1;
                        DoDfs(u, adjList, visited, p, -1, ref r);
                        comps.AddLast(r);
                    }
                }
                int k = comps.Count - 1;
                int root = comps.Where(u => u == p[u]).DefaultIfEmpty(-1).First();
                if (root == -1) 
                {
                    root = comps.First();
                    p[root] = root;
                    k++;
                }
                foreach (int u in comps)
                {
                    if (u != root) p[u] = root;
                }
                writer.WriteLine(k);
                for (int i = 0; i < n; i++)
                {
                    writer.Write(p[i] + 1 + " ");
                }
            }
        }

        private static void DoDfs(int u, LinkedList<int>[] adjList, bool[] visited, int[] p, int prev, ref int root)
        {
            visited[u] = true;
            foreach (int v in adjList[u])
            {
                if (!visited[v])
                {
                    DoDfs(v, adjList, visited, p, u, ref root);
                }
                else if (v != prev)
                {
                    root = p[u] == v ? u : v;
                }
            }
        }
    }
}
