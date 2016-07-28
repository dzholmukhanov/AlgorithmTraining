using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class LorenzoVonMatterhorn362
    {
        private static Dictionary<Edge, long> costs = new Dictionary<Edge, long>(); 
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int q = fs.NextInt();
                long u, v, w;
                List<Edge> path;
                while (q-- > 0)
                {
                    int t = fs.NextInt();
                    if (t == 1)
                    {
                        u = fs.NextLong();
                        v = fs.NextLong();
                        w = fs.NextLong();
                        path = GetPath(u, v);
                        foreach (var edge in path)
                        {
                            if (!costs.ContainsKey(edge)) costs.Add(edge, 0);
                            costs[edge] += w;
                        }
                    }
                    else
                    {
                        u = fs.NextLong();
                        v = fs.NextLong();
                        path = GetPath(u, v);
                        writer.WriteLine(GetCost(path));
                    }
                }
            }
        }

        private static long GetCost(List<Edge> path)
        {
            long ans = 0;
            foreach (Edge e in path)
            {
                if (costs.ContainsKey(e)) ans += costs[e];
            }
            return ans;
        }

        private static List<Edge> GetPath(long u, long v)
        {
            if (u > v)
            {
                long t = u;
                u = v;
                v = t;
            }
            List<Edge> res = new List<Edge>(100);
            while (u != v)
            {
                if (u > v)
                {
                    res.Add(new Edge { U = u, V = u / 2 });
                    u /= 2;
                }
                else if (v > u)
                {
                    res.Add(new Edge { U = v, V = v / 2 });
                    v /= 2;
                }
            }
            return res;
        }
    }
    class Edge
    {
        public long U, V;
        public override int GetHashCode()
        {
            return U.GetHashCode() ^ V.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Edge e = (Edge)obj;
            return (U == e.U && V == e.V) || (V == e.U && U == e.V);
        }
    }
}
