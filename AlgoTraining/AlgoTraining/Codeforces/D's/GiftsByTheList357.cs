using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class GiftsByTheList357
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {   
                int n = fs.NextInt(), m = fs.NextInt();
                LinkedList<int>[] adjList = new LinkedList<int>[n];
                for (int i = 0; i < n; i++)
                {
                    adjList[i] = new LinkedList<int>();
                }
                int[] parents = Enumerable.Repeat(-1, n).ToArray();
                for (int i = 0; i < m; i++)
                {
                    int p = fs.NextInt() - 1, q = fs.NextInt() - 1;
                    parents[q] = p;
                    adjList[p].AddLast(q);
                }
                LinkedList<int> roots = new LinkedList<int>();
                int[] wishes = new int[n];
                bool[] isWished = new bool[n];
                bool[] visited = new bool[n];
                for (int i = 0; i < n; i++)
                {
                    wishes[i] = fs.NextInt() - 1;
                    isWished[wishes[i]] = true;
                    int parent = parents[i];
                    if (parent != -1 && !visited[parent])
                    {
                        while (parents[parent] != -1 && !visited[parent])
                        {
                            visited[parent] = true;
                            parent = parents[parent];
                        }
                        if (parents[parent] == -1 && !visited[parent])
                        {
                            visited[parent] = true;
                            roots.AddLast(parent);
                        }
                    }
                    else if (parent == -1 && !visited[i])
                    {
                        visited[i] = true;
                        roots.AddLast(i);
                    }
                }
                LinkedList<int> ans = new LinkedList<int>();
                foreach (int root in roots)
                {
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(root);
                    while (queue.Count > 0)
                    {
                        int u = queue.Dequeue();
                        if (isWished[u]) ans.AddFirst(u);
                        foreach (int v in adjList[u])
                        {
                            queue.Enqueue(v);
                            if (wishes[v] != v && wishes[u] != wishes[v])
                            {
                                writer.WriteLine(-1);
                                return;
                            }
                        }
                    }
                }
                writer.WriteLine(ans.Count);
                foreach (int x in ans)
                {
                    writer.WriteLine(x + 1);
                }
            }
        }
    }
}
