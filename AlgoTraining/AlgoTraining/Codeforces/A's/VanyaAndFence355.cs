using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class VanyaAndFence355
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), h = fs.NextInt(), res = 0;
                for (int i = 0; i < n; i++)
                {
                    int a = fs.NextInt();
                    res += a <= h ? 1 : 2;
                }
                writer.Write(res);
            }
        }
    }
}
