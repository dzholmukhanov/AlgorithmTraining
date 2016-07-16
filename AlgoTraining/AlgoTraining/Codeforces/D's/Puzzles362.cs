using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class Puzzles362
    {
        private static LinkedList<int>[] AdjList;
        private static int[] Sizes;
        private static double[] StartTimes;

        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                AdjList = new LinkedList<int>[n];
                Sizes = new int[n];
                StartTimes = new double[n];
                for (int i = 0; i < n; i++)
			    {
                    AdjList[i] = new LinkedList<int>();
			    }
                for (int i = 1; i < n; i++)
                {
                    int p = fs.NextInt() - 1;
                    AdjList[p].AddLast(i);
                }
                EvalSize(0);
                StartTimes[0] = 1;
                EvalStartTimes(0, 0);

                for (int i = 0; i < n; i++)
                {
                    writer.Write(StartTimes[i].ToString().Replace(",", ".") + " ");
                }
            }
        }

        private static void EvalStartTimes(int u, int parent)
        {
            if (u != 0)
            {
                StartTimes[u] = StartTimes[parent] + 1 + 0.5 * (Sizes[parent] - Sizes[u] - 1);
            }
            foreach (int v in AdjList[u])
            {
                EvalStartTimes(v, u);
            }
        }

        private static int EvalSize(int u)
        {
            int size = 1;
            foreach (int v in AdjList[u])
            {
                size += EvalSize(v);
            }
            Sizes[u] = size;
            return size;
        }
    }
}
