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
                string[] ans = new string[m];
                for (int i = 0; i < m; i++)
                {
                    edges[i] = new Edge { Id = i, Weight = fs.NextInt(), IsInMST = fs.NextInt() == 1 };
                }
                edges = edges.OrderBy(e => e.Weight).ThenByDescending(e => e.IsInMST).ToArray();

                long inMst = 0;
                long notInMst = 0;
                List<EdgeOcc> edgeOccs = new List<EdgeOcc>();
                foreach (Edge e in edges)
                {
                    if (e.IsInMST)
                    {
                        ans[e.Id] = (inMst + 1) + " " + (inMst + 2);
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
                        else
                        {
                            edgeOccs.Add(new EdgeOcc { VertexCount = inMst + 1, Edge = e });
                        }
                    }
                }
                long p = inMst + 1;
                long q = p - 2;
                for (int i = edgeOccs.Count - 1; i >= 0; i--)
                {
                    while (edgeOccs[i].VertexCount < p)
                    {
                        p--;
                        q = p - 2;
                    }
                    ans[edgeOccs[i].Edge.Id] = q + " " + p;
                    q--;
                    if (q <= 0)
                    {
                        p--;
                        q = p - 2;
                    }
                }
                for (int i = 0; i < m; i++)
                {
                    writer.WriteLine(ans[i]);
                }
            }
        }
    }
    class EdgeOcc
    {
        public long VertexCount;
        public Edge Edge;
    }
    class Edge
    {
        public int Id;
        public int Weight;
        public bool IsInMST;
    }
}
