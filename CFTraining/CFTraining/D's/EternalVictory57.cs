using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.D_s
{
    class EternalVictory57
    {
        private static LinkedList<Tuple<int, int>>[] _adjList;
        private static int _size;
        // Very bad implementation! But accepted...
        public static void Run()
        {
            _size = Convert.ToInt32(Console.ReadLine());
            _adjList = new LinkedList<Tuple<int, int>>[_size];

            for (int i = 0; i < _size; i++)
            {
                _adjList[i] = new LinkedList<Tuple<int, int>>();
            }

            int n = _size;
            LinkedList<Tuple<int, int, int>> edges = new LinkedList<Tuple<int, int, int>>();
            while (--n > 0)
            {
                String[] line = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(line[0]) - 1,
                    y = Convert.ToInt32(line[1]) - 1,
                    w = Convert.ToInt32(line[2]);
                _adjList[x].AddLast(new Tuple<int, int>(y, w));
                _adjList[y].AddLast(new Tuple<int, int>(x, w));
                edges.AddLast(new Tuple<int, int, int>(Math.Min(x, y), Math.Max(x, y), w));
            }

            List<Tuple<int, int>> longestPath = findLongestPath();
            long minTripLength = 0;
            foreach (Tuple<int, int, int> edge in edges)
            {
                if (longestPath.Contains(new Tuple<int, int>(edge.Item1, edge.Item2)))
                    minTripLength += edge.Item3;
                else
                    minTripLength += edge.Item3 * 2;
            }
            Console.WriteLine(minTripLength);
        }

        private static int[] parent;
        private static long[] pathCosts;
        private static bool[] visited;
        public static List<Tuple<int, int>> findLongestPath()
        {
            List<Tuple<int, int>> longestPath = new List<Tuple<int, int>>();
            parent = new int[_size];
            pathCosts = new long[_size];
            visited = new bool[_size];
            parent[0] = 0;
            visited[0] = true;
            runDFS(0, 0);

            int maxIndex = 0;
            long maxValue = pathCosts[0];
            for (int i = 1; i < _size; i++)
            {
                if (pathCosts[i] > maxValue)
                {
                    maxValue = pathCosts[i];
                    maxIndex = i;
                }
            }
            int current = maxIndex;
            while (current != 0)
            {
                longestPath.Add(new Tuple<int, int>(Math.Min(parent[current], current), Math.Max(parent[current], current)));
                current = parent[current];
            }
            return longestPath;
        }
        public static void runDFS(int start, long cost)
        {
            bool isLeaf = true;
            foreach (Tuple<int, int> edge in _adjList[start])
            {
                if (!visited[edge.Item1])
                {
                    isLeaf = false;
                    parent[edge.Item1] = start;
                    visited[edge.Item1] = true;
                    runDFS(edge.Item1, cost + edge.Item2);
                }
            }
            if (isLeaf) pathCosts[start] = cost;
        }
    }
}
