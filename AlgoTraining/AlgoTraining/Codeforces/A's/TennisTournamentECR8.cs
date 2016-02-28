using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class TennisTournamentECR8
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), b = fs.NextInt(), p = fs.NextInt(), bottles = 0, towels = n * p;
                while (n > 1)
                {
                    int teams = (int)Math.Pow(2, (int)Math.Log(n, 2));
                    bottles += b * teams + teams / 2;
                    n -= teams / 2;
                }
                writer.WriteLine(bottles + " " + towels);
            }
        }
    }
}
