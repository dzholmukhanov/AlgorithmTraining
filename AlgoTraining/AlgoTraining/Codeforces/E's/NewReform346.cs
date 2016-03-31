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
                LinkedList<int>[] adj = new LinkedList<int>[n];
                for (int i = 0; i < n; i++)
                {
                    adj[i] = new LinkedList<int>();
                }
                for (int i = 0; i < m; i++)
                {
                    int u = fs.NextInt() - 1, v = fs.NextInt() - 1;
                    adj[u].AddLast(v);
                    adj[v].AddLast(u);
                }
                bool[] visited = new bool[n];
                int ans = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i]) ans += DFS(i, visited, adj, -1);
                }
                writer.WriteLine(ans);
            }
        }
        private static int DFS(int i, bool[] visited, LinkedList<int>[] adj, int prev)
        {
            visited[i] = true;
            int ans = 1;
            foreach (int j in adj[i])
            {
                if (!visited[j])
                {
                    int t = DFS(j, visited, adj, i);
                    if (ans == 1 && t == 0) ans = 0;
                }
                else
                {
                    if (j != prev) ans = 0;
                }
            }
            return ans;
        }
    }
}
