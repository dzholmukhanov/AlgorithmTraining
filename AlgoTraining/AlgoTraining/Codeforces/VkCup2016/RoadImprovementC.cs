using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class RoadImprovementC
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                LinkedList<Edge>[] adjList = new LinkedList<Edge>[n];
                for (int i = 0; i < n; i++)
                {
                    adjList[i] = new LinkedList<Edge>();
                }
                int days = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    int u = fs.NextInt() - 1;
                    int v = fs.NextInt() - 1;
                    adjList[u].AddLast(new Edge { Id = i + 1, U = u, V = v });
                    adjList[v].AddLast(new Edge { Id = i + 1, U = v, V = u });
                    days = Math.Max(adjList[u].Count, days);
                    days = Math.Max(adjList[v].Count, days);
                }
                LinkedList<int>[] ans = new LinkedList<int>[days];
                for (int i = 0; i < days; i++)
                {
                    ans[i] = new LinkedList<int>();
                }

                bool[] visited = new bool[n];
                int[] repaired = new int[n];
                Stack<int> stack = new Stack<int>();
                stack.Push(0);
                repaired[0] = -1;
                while (stack.Count > 0)
                {
                    int u = stack.Pop();
                    visited[u] = true;
                    int k = 0;
                    foreach (Edge e in adjList[u])
                    {
                        if (!visited[e.V])
                        {
                            if (k == repaired[u]) k++;
                            repaired[e.V] = k;
                            ans[k].AddLast(e.Id);
                            stack.Push(e.V);
                            k++;
                        }
                    }
                }
                writer.WriteLine(days);
                foreach (LinkedList<int> list in ans)
                {
                    writer.Write(list.Count + " ");
                    foreach (int u in list)
                    {
                        writer.Write(u + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
    class Edge
    {
        public int Id;
        public int U, V;
    }
}
