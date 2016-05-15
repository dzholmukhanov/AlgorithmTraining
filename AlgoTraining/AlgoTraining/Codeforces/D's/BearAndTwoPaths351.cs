using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class BearAndTwoPaths351
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                int a = fs.NextInt(), b = fs.NextInt(), c = fs.NextInt(), d = fs.NextInt();
                if (n == 4 || k <= n) writer.WriteLine(-1);
                else
                {
                    writer.Write(a + " " + c + " ");
                    for (int i = 1; i <= n; i++)
                    {
                        if (i != a && i != b && i != c && i != d) writer.Write(i + " ");
                    }
                    writer.WriteLine(d + " " + b);

                    writer.Write(c + " " + a + " ");
                    for (int i = 1; i <= n; i++)
                    {
                        if (i != a && i != b && i != c && i != d) writer.Write(i + " ");
                    }
                    writer.Write(b + " " + d);
                }
            }
        }
    }
}
