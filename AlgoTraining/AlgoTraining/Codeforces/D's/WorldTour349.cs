using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class WorldTour349
    {
        private static int n, m;
        private static int[,] dist, distRev;
        private static LinkedList<int>[] adjList, adjListRev;
        private static LinkedList<int>[] furthest, furthestRev;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                n = fs.NextInt();
                m = fs.NextInt();
                adjList = new LinkedList<int>[n];
                adjListRev = new LinkedList<int>[n];
                furthest = new LinkedList<int>[n];
                furthestRev = new LinkedList<int>[n];
                dist = new int[n, n];
                distRev = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    adjList[i] = new LinkedList<int>();
                    adjListRev[i] = new LinkedList<int>();
                    furthest[i] = new LinkedList<int>();
                    furthestRev[i] = new LinkedList<int>();
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dist[i, j] = int.MaxValue;
                        distRev[i, j] = int.MaxValue;
                    }
                }
                for (int i = 0; i < m; i++)
                {
                    int u = fs.NextInt() - 1, v = fs.NextInt() - 1;
                    if (u == v) continue;
                    if (dist[u, v] == int.MaxValue)
                    {
                        dist[u, v] = int.MaxValue - 1; //workaround
                        distRev[v, u] = int.MaxValue - 1;
                        adjList[u].AddLast(v);
                        adjListRev[v].AddLast(u);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    RunBFS(i, dist, adjList, furthest);
                }
                for (int i = 0; i < n; i++)
                {
                    RunBFS(i, distRev, adjListRev, furthestRev);
                }
                int maxDist = 0;
                int[] res = new int[4];
                for (int b = 0; b < n; b++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (b == c || dist[b, c] == int.MaxValue) continue;

                        bool leftCont = furthestRev[b].Contains(c);
                        bool rightCont = furthest[c].Contains(b);
                        int leftCount = furthestRev[b].Count() - (leftCont ? 1 : 0), rightCount = furthest[c].Count() - (rightCont ? 1 : 0);

                        if (leftCount == 0 || rightCount == 0) continue;

                        int a = GetFirstAndExclude(furthestRev[b], c);
                        int d = GetFirstAndExclude(furthest[c], b);
                        int leftLast = GetLastAndExclude(furthestRev[b], c);
                        int rightLast = GetLastAndExclude(furthest[c], b);
                        if (a == d)
                        {
                            if (leftCount == 1 && rightCount == 1) continue;
                            else if (leftCount == 1)
                            {
                                d = rightLast;
                            }
                            else if (rightCount == 1)
                            {
                                a = leftLast;
                            }
                            else
                            {
                                if (a + rightLast >= leftLast + d)
                                {
                                    d = rightLast;
                                }
                                else
                                {
                                    a = leftLast;
                                }
                            }
                        }
                        int temp = dist[a, b] + dist[b, c] + dist[c, d];
                        if (temp > maxDist)
                        {
                            maxDist = temp;
                            res[0] = a;
                            res[1] = b;
                            res[2] = c;
                            res[3] = d;
                        }
                    }
                }
                writer.WriteLine((res[0] + 1) + " " + (res[1] + 1) + " " + (res[2] + 1) + " " + (res[3] + 1));
            }
        }
        private static int GetLastAndExclude(LinkedList<int> list, int ex)
        {
            return list.Last.Value != ex ? list.Last.Value : list.Last.Previous.Value;
        }

        private static int GetFirstAndExclude(LinkedList<int> list, int ex)
        {
            return list.First.Value != ex ? list.First.Value : list.First.Next.Value;
        }
        private static Path ExtractMin(LinkedList<Path> list)
        {
            var min = list.First;
            for (var node = list.First.Next; node != list.Last.Next; node = node.Next)
            {
                if (node.Value.Dist < min.Value.Dist)
                {
                    min = node;
                }
            }
            list.Remove(min);
            return min.Value;
        }
        private static void RunBFS(int s, int[,] dist, LinkedList<int>[] adjList, LinkedList<int>[] furthest)
        {
            Queue<int> queue = new Queue<int>();
            LinkedList<Path> list = new LinkedList<Path>();
            dist[s, s] = 0;
            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in adjList[u])
                {
                    int alt = dist[s, u] + 1;
                    if (dist[s, v] > alt)
                    {
                        list.AddLast(new Path { Source = s, Destination = v, Dist = alt });
                        if (list.Count == 4)
                        {
                            ExtractMin(list);
                        }
                        dist[s, v] = alt;
                        queue.Enqueue(v);
                    }
                }
            }
            while (list.Count > 0)
            {
                var v = ExtractMin(list);
                furthest[s].AddFirst(v.Destination);
            }
        }
    }
    public class Path : IComparable<Path>
    {
        public int Source, Destination, Dist;
        public int CompareTo(Path path)
        {
            return this.Dist.CompareTo(path.Dist);
        }
    }
}
