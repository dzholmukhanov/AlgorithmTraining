using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class NewReform346
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                LinkedList<Edge>[] adj = new LinkedList<Edge>[n];
                for (int i = 0; i < n; i++)
                {
                    adj[i] = new LinkedList<Edge>();
                }
                for (int i = 0; i < m; i++)
                {
                    int u = fs.NextInt() - 1, v = fs.NextInt() - 1;
                    adj[u].AddLast(new Edge { Id = i, V = v});
                    adj[v].AddLast(new Edge { Id = i, V = u });
                }
                bool[] visited = new bool[n], reached = new bool[n], used = new bool[m];
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i]) DFS(i, visited, reached, used, adj);
                }
                int ans = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!reached[i]) ans++;
                }
                writer.WriteLine(ans);
            }
        }

        private static void DFS(int i, bool[] visited, bool[] reached, bool[] used, LinkedList<Edge>[] adj)
        {
            visited[i] = true;
            foreach (Edge edge in adj[i])
            {
                if (!visited[edge.V])
                {
                    reached[edge.V] = true;
                    used[edge.Id] = true;
                    DFS(edge.V, visited, reached, used, adj);
                }
                else
                {
                    if (!used[edge.Id] && !reached[edge.V]) reached[edge.V] = true;
                }
            }
        }
    }
    class Edge
    {
        public int Id, V;
    }
}
