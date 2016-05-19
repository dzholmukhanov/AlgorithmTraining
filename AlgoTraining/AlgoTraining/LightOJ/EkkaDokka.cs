using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.LightOJ
{
    class EkkaDokka
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                for (int i = 1; i <= t; i++)
                {
                    long w = fs.NextLong();
                    if ((w & 1) == 0)
                    {
                        long m = 1;
                        while ((w & 1) == 0)
                        {
                            m <<= 1;
                            w >>= 1;
                        }
                        writer.WriteLine("Case " + i + ": " + w + " " + m);
                    }
                    else
                    {
                        writer.WriteLine("Case " + i + ": Impossible");
                    }
                }
            }
        }
    }
}
