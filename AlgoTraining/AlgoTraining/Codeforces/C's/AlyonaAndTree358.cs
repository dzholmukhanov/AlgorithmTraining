using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class AlyonaAndTree358
    {
        private static LinkedList<Edge>[] adjList;
        private static int[] a, childNum;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                a = new int[n];
                adjList = new LinkedList<Edge>[n];
                for (int i = 0; i < n; i++)
                {
                    adjList[i] = new LinkedList<Edge>();
                    a[i] = fs.NextInt();
                }
                for (int i = 0; i < n - 1; i++)
                {
                    int p = fs.NextInt() - 1, c = fs.NextInt();
                    adjList[i + 1].AddLast(new Edge { v = p, w = c });
                    adjList[p].AddLast(new Edge { v = i + 1, w = c });
                }
                childNum = new int[n];
                GetChildNum(0, new bool[n]);
                long ans = VerticesToRemove(0, 0, new bool[n]);
                writer.WriteLine(ans);
            }
        }
        public static long VerticesToRemove(int u, long max, bool[] visited)
        {
            visited[u] = true;
            long res = 0;
            foreach (Edge edge in adjList[u])
            {
                if (!visited[edge.v])
                {
                    if (max + edge.w > a[edge.v]) res += childNum[edge.v] + 1;
                    else res += VerticesToRemove(edge.v, Math.Max(0, max + edge.w), visited);
                }
            }
            return res;
        }
        public static int GetChildNum(int u, bool[] visited)
        {
            visited[u] = true;
            foreach (Edge edge in adjList[u])
            {
                if (!visited[edge.v])
                {
                    childNum[u] += 1 + GetChildNum(edge.v, visited);
                }
            }
            return childNum[u];
        }
    }
    class Edge
    {
        public int v, w;
    }
}
