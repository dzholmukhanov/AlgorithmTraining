using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class MemoryAndCow370
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                long[] a = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt64);
                long dif = 0;
                long[] b = new long[n];
                int k = 1;
                for (int i = n - 1; i >= 0; i--)
                {
                    b[i] = a[i] - k * dif;
                    dif += k * b[i];
                    k = -k;
                }
                for (int i = 0; i < n; i++)
                {
                    writer.Write(b[i] + " ");
                }
            }
        }
    }
}
