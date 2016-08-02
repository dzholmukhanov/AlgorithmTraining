using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class Vacations363
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), inf = (int)1e8;
                int[] a = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                int r = 1;
                int g = a[0] == 3 || a[0] == 2 ? 0 : inf;
                int c = a[0] == 3 || a[0] == 1 ? 0 : inf;
                for (int i = 1; i < n; i++)
                {
                    int ng = Math.Min(c, r) + (a[i] == 3 || a[i] == 2 ? 0 : inf);
                    int nc = Math.Min(r, g) + (a[i] == 3 || a[i] == 1 ? 0 : inf);
                    int nr = Math.Min(r, Math.Min(g, c)) + 1;
                    r = nr;
                    g = ng;
                    c = nc;
                }
                writer.WriteLine(Math.Min(r, Math.Min(g, c)));
            }
        }
    }
}
