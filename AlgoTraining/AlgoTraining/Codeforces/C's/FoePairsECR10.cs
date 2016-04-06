using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class FoePairsECR10
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int[] p = new int[n], pair = new int[n + 1], ind = new int[n + 1];
                bool[] hasFoe = new bool[n + 1];
                for (int i = 0; i < n; i++)
                {
                    p[i] = fs.NextInt();
                    ind[p[i]] = i;
                }
                ind[0] = -1;
                for (int i = 0; i < m; i++)
                {
                    int a = fs.NextInt(), b = fs.NextInt();
                    hasFoe[a] = true;
                    hasFoe[b] = true;
                    if (ind[a] < ind[b] && ind[a] > ind[pair[b]]) pair[b] = a;
                    else if (ind[b] < ind[a] && ind[b] > ind[pair[a]]) pair[a] = b;
                }
                long ans = 1;
                int l = 0, r = 0;
                bool[] met = new bool[n + 1];
                if (hasFoe[p[0]]) met[p[0]] = true;
                while (r < n - 1)
                {
                    r++;
                    if (!hasFoe[p[r]]) ans += r - l + 1;
                    else
                    {
                        met[p[r]] = true;
                        if (met[pair[p[r]]])
                        {
                            while (l < ind[pair[p[r]]] + 1)
                            {
                                if (met[p[l]]) met[p[l]] = false;
                                l++;
                            }
                        }
                        ans += r - l + 1;
                    }
                }
                writer.WriteLine(ans);
            }
        }
    }
}
