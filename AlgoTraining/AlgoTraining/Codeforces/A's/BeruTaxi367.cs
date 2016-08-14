using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class BeruTaxi367
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int a = fs.NextInt(), b = fs.NextInt(), n = fs.NextInt();
                double t = double.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    int x = fs.NextInt(), y = fs.NextInt(), v = fs.NextInt();
                    double s = Math.Sqrt((a - x) * (a - x) + (b - y) * (b - y));
                    t = Math.Min(t, s / v);
                }
                writer.WriteLine(t.ToString().Replace(",", "."));
            }
        }
    }
}
