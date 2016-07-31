using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class AsFastAsPossible364
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), l = fs.NextInt(), v1 = fs.NextInt(), v2 = fs.NextInt(), k = fs.NextInt();
                int g = (int)Math.Ceiling(n * 1.0 / k);
                double lbus = l * (1.0 * v1 + v2) / (v2 * 1.0 + (2 * g - 1) * v1);
                double time = (l - lbus) / v1 + lbus / v2;
                writer.WriteLine(time.ToString().Replace(",", "."));
            }
        }
    }
}
