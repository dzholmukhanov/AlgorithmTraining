using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.GoodBye2016
{
    class NewYearAndRatingC
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), min = int.MinValue + 1, max = int.MaxValue - 1;
                int q = 1900, l = min, r = max;
                for (int i = 0; i < n; i++)
                {
                    int c = fs.NextInt(), d = fs.NextInt();
                    if (d == 1)
                    {
                        if (r < q)
                        {
                            l = r + 1;
                            break;
                        }
                        l = Math.Max(l, q);
                    }
                    else
                    {
                        if (l >= q)
                        {
                            l = r + 1;
                            break;
                        }
                        r = Math.Min(r, q - 1);
                    }
                    if (l != min) l += c;
                    if (r != max) r += c;
                }
                if (l > r) writer.WriteLine("Impossible");
                else if (r == max) writer.WriteLine("Infinity");
                else writer.WriteLine(r);
            }
        }
    }
}
