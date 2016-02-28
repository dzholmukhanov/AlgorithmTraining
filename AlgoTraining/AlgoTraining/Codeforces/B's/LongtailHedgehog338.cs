using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.B_s
{
    class LongtailHedgehog338
    {
        private static int n, m;
        private static int[] longest;
        private static List<int>[] adjMatrix;

        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(line[0]);
            m = Convert.ToInt32(line[1]);
            adjMatrix = new List<int>[n];
            int[] conn = new int[n];
            longest = new int[n];
            for (int i = 0; i < n; i++)
            {
                adjMatrix[i] = new List<int>();
            }
            for (int i = 0; i < m; i++)
            {
                line = Console.ReadLine().Split(' ');
                int u = Convert.ToInt32(line[0]) - 1,
                    v = Convert.ToInt32(line[1]) - 1;
                adjMatrix[u].Add(v);
                adjMatrix[v].Add(u);
                conn[u]++;
                conn[v]++;
            }
            for (int u = n - 1; u >= 0; u--)
            {
                if (longest[u] == 0) DFS(u);
            }
            long answer = 0;
            for (int i = 0; i < n; i++)
            {
                answer = Math.Max((long)longest[i] * conn[i], answer);
            }
            Console.WriteLine(answer);
        }
        public static void DFS(int u)
        {
            longest[u] = 1;
            foreach (int v in adjMatrix[u])
            {
                if (v < u)
                {
                    if (longest[v] == 0) DFS(v);
                    longest[u] = Math.Max(longest[v] + 1, longest[u]);
                }
            }
        }
    }
}
