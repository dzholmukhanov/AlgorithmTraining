using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.E_s
{
    class AntsInLeavesECR7
    {
        private static int N;
        private static LinkedList<int>[] AdjList;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                N = fs.NextInt();
                AdjList = new LinkedList<int>[N];
                for (int i = 0; i < N; i++)
                {
                    AdjList[i] = new LinkedList<int>();
                }
                for (int i = 0; i < N - 1; i++)
                {
                    int u = fs.NextInt() - 1, v = fs.NextInt() - 1;
                    AdjList[u].AddLast(v);
                    AdjList[v].AddLast(u);
                }
                int max = 0;
                foreach (int v in AdjList[0])
                {
                    List<int> times = new List<int>();
                    DFS(times, v, 0, 1);
                    int[] temp = times.OrderBy(i => i).ToArray();
                    for (int i = 1; i < temp.Length; i++)
                    {
                        if (temp[i] <= temp[i - 1]) temp[i] = temp[i - 1] + 1;
                    }
                    max = Math.Max(max, temp[temp.Length - 1]);
                }
                writer.WriteLine(max);
            }
        }
        public static void DFS(List<int> times, int u, int p, int step)
        {
            if (AdjList[u].Count == 1)
            {
                times.Add(step);
                return;
            }
            foreach (int v in AdjList[u]) {
                if (v != p) {
                    DFS(times, v, u, step + 1);
                }
            }
        }
    }
}
