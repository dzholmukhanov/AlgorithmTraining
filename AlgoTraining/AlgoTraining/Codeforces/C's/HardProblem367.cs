using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class HardProblem367
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] c = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                string[] s = new string[n];
                for (int i = 0; i < n; i++)
                {
                    s[i] = fs.ReadLine();
                }
                int vk = 2 * n + 2;
                LinkedList<Edge>[] adjList = new LinkedList<Edge>[vk];
                for (int i = 0; i < vk; i++)
                {
                    adjList[i] = new LinkedList<Edge>();
                }
                adjList[0].AddLast(new Edge { To = 1, W = 0 });
                adjList[0].AddLast(new Edge { To = n + 1, W = c[0] });
                for (int i = 0; i < n - 1; i++)
                {
                    string rev1 = Reverse(s[i]), rev2 = Reverse(s[i + 1]);
                    if (IsLess(s[i], s[i + 1]))
                    {
                        adjList[i + 1].AddLast(new Edge { To = i + 2, W = 0 });
                    }
                    if (IsLess(s[i], rev2))
                    {
                        adjList[i + 1].AddLast(new Edge { To = n + i + 2, W = c[i + 1] });
                    }
                    if (IsLess(rev1, s[i + 1]))
                    {
                        adjList[n + i + 1].AddLast(new Edge { To = i + 2, W = 0 });
                    }
                    if (IsLess(rev1, rev2))
                    {
                        adjList[n + i + 1].AddLast(new Edge { To = n + i + 2, W = c[i + 1] });
                    }
                }
                adjList[n].AddLast(new Edge { To = vk - 1, W = 0 });
                adjList[vk - 2].AddLast(new Edge { To = vk - 1, W = 0 });
                long[] dist = Enumerable.Repeat(long.MaxValue, vk).ToArray();
                RunDijkstra(adjList, dist);
                writer.WriteLine(dist[vk - 1] != long.MaxValue ? dist[vk - 1] : -1);
            }
        }

        private static void RunDijkstra(LinkedList<Edge>[] adjList, long[] dist)
        {
            MinHeap<int, long> heap = new MinHeap<int, long>();
            heap.Insert(0, 0);
            dist[0] = 0;
            while (heap.Count > 0)
            {
                int u = heap.ExtractMin().Key;
                foreach (Edge e in adjList[u])
                {
                    if (dist[e.To] > dist[u] + e.W)
                    {
                        dist[e.To] = dist[u] + e.W;
                        heap.Insert(e.To, dist[e.To]);
                    }
                }
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static bool IsLess(string a, string b)
        {
            return String.Compare(a, b) <= 0;
        }
        class Edge
        {
            public int To;
            public long W;
        }
    }
}
