using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces._8VCVentureCup2016
{
    public class IslandPuzzleB
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), p = 0, f1 = 0, f2 = 0;
                int[] a = new int[n - 1], b = new int[n - 1];
                for (int i = 0; i < n; i++)
                {
                    int x = fs.NextInt();
                    if (x != 0)
                    {
                        a[p] = x;
                        if (x == 1) f1 = p;
                        p++;
                    }
                }
                p = 0;
                for (int i = 0; i < n; i++)
                {
                    int x = fs.NextInt();
                    if (x != 0)
                    {
                        b[p] = x;
                        if (x == 1) f2 = p;
                        p++;
                    }
                }
                bool ans = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (a[f1] != b[f2])
                    {
                        ans = false;
                        break;
                    }
                    f1 = (f1 + 1) % (n - 1);
                    f2 = (f2 + 1) % (n - 1);
                }
                writer.WriteLine(ans ? "YES" : "NO");
            }
        }
    }
}
