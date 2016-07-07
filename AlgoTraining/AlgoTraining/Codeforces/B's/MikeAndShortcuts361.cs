using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class MikeAndShortcuts361
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                LinkedList<int>[] adjList = new LinkedList<int>[n];
                for (int i = 0; i < n; i++)
                {
                    adjList[i] = new LinkedList<int>();
                }
                for (int i = 0; i < n; i++)
                {
                    int v = fs.NextInt() - 1;
                    if (v != i) adjList[i].AddLast(v);
                    if (i > 0)
                    {
                        adjList[i].AddLast(i - 1);
                        adjList[i - 1].AddLast(i);
                    }
                }
                int[] dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
                RunDijkstra(adjList, dist);
                foreach (int x in dist)
                {
                    writer.Write(x + " ");
                }
            }
        }

        private static void RunDijkstra(LinkedList<int>[] adjList, int[] dist)
        {
            MinHeap<int, int> heap = new MinHeap<int, int>();
            heap.Insert(0, 0);
            dist[0] = 0;
            while (heap.Count > 0)
            {
                int u = heap.ExtractMin().Key;
                foreach (int v in adjList[u])
                {
                    if (dist[v] > dist[u] + 1)
                    {
                        dist[v] = dist[u] + 1;
                        heap.Insert(v, dist[v]);
                    }
                }
            }
        }
    }
}
