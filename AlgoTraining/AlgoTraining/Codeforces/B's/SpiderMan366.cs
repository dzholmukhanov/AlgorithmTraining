using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class SpiderMan366
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                long sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += fs.NextInt() - 1;
                    writer.WriteLine(sum % 2 == 1 ? 1 : 2);
                }
            }
        }
    }
}
