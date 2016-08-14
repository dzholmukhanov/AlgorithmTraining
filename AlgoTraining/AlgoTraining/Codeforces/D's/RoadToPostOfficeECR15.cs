using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class RoadToPostOfficeECR15
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long d = fs.NextLong(), k = fs.NextLong(), a = fs.NextLong(), b = fs.NextLong(), t = fs.NextLong();
                if (k >= d)
                {
                    writer.WriteLine(d * a);
                }
                else
                {
                    long dc = d / k * k;
                    long res = d * b + ((long)Math.Ceiling(dc * 1.0 / k) - 1) * t + dc * (a - b);
                    res = Math.Min(d * b + ((long)Math.Ceiling(d * 1.0 / k) - 1) * t + d * (a - b), res);
                    res = Math.Min(d * b + k * (a - b), res);
                    writer.WriteLine(res);
                }
            }
        }
    }
}
