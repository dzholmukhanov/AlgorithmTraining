using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class NpHardProblem360
    {
        private static LinkedList<int>[] adjList;
        private static LinkedList<int> a, b;
        private static int n, m;
        private static int[] color;
        private static bool ans;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                n = fs.NextInt();
                m = fs.NextInt();
                adjList = new LinkedList<int>[n];
                for (int i = 0; i < n; i++)
			    {
			        adjList[i] = new LinkedList<int>();
			    }
                for (int i = 0; i < m; i++)
                {
                    int u = fs.NextInt() - 1, v = fs.NextInt() - 1;
                    adjList[u].AddLast(v);
                    adjList[v].AddLast(u);
                }
                color = new int[n];
                a = new LinkedList<int>();
                b = new LinkedList<int>();
                ans = true;
                for (int i = 0; i < n && ans; i++)
                {
                    if (color[i] == 0) RunDFS(i, 1);
                }
                if (ans)
                {
                    writer.WriteLine(a.Count);
                    foreach (int i in a)
                    {
                        writer.Write((i + 1) + " ");
                    }
                    writer.WriteLine("\n" + b.Count);
                    foreach (int i in b)
                    {
                        writer.Write((i + 1) + " ");
                    }
                }
                else
                {
                    writer.WriteLine(-1);
                }
            }
        }
        public static void RunDFS(int u, int c)
        {
            color[u] = c;
            if (c == 1) a.AddLast(u);
            else b.AddLast(u);
            foreach (int v in adjList[u])
            {
                if (color[v] == 0)
                {
                    RunDFS(v, -c);
                }
                else if (color[v] == c)
                {
                    ans = false;
                    return;
                }
            }
        }
    }
}
