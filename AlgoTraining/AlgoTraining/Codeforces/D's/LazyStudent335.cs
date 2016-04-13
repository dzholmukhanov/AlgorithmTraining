using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class LazyStudent335
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int m = fs.NextInt();
                Edge[] edges = new Edge[m];
                for (int i = 0; i < m; i++)
                {
                    edges[i] = new Edge { Weight = fs.NextInt(), IsInMST = fs.NextInt() == 1 };
                }
                edges = edges.OrderBy(e => e.Weight).ToArray();

                long inMst = 0, notInMst = 0;
                StringBuilder sb = new StringBuilder();
                foreach (Edge e in edges)
                {
                    if (e.IsInMST)
                    {
                        sb.Append((inMst + 1) + " " + (inMst + 2) + "\n");
                        inMst++;
                    }
                    else
                    {
                        notInMst++;
                        if (notInMst > (inMst * (inMst - 1)) / 2)
                        {
                            writer.WriteLine(-1);
                            return;
                        }
                    }
                }
                for (int i = 1; i <= n && notInMst > 0; i++)
                {
                    for (int j = i + 2; j <= n && notInMst > 0; j++)
                    {
                        sb.Append(i + " " + j + "\n");
                        notInMst--;
                    }
                }
                writer.WriteLine(sb);
            }
        }
    }
    class Edge
    {
        public int Weight;
        public bool IsInMST;
    }
}
