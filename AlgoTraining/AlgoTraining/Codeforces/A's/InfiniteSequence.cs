using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class InfiniteSequence
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int a1 = fs.NextInt(), an = fs.NextInt(), d = fs.NextInt();
                if (d == 0)
                {
                    if (a1 == an) writer.WriteLine("YES");
                    else writer.WriteLine("NO");
                }
                else
                {
                    if ((an - a1) % d == 0)
                    {
                        if ((an - a1) / d + 1 >= 1) writer.WriteLine("YES");
                        else writer.WriteLine("NO");
                    }
                    else
                    {
                        writer.WriteLine("NO");
                    }
                }
            }
        }
    }
}
