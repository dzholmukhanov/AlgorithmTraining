using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class Pyramid354
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                double[] a = new double[n * n];
                while (k > 0)
                {
                    Fill(0, 1, a, 1, n);
                    k--;
                }
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] >= 1.0) count++;
                }
                writer.WriteLine(count);
            }
        }
        public static void Fill(int i, double val, double[] a, int level, int n)
        {
            a[i] += val;
            if (a[i] > 1)
            {
                double ex = a[i] - 1;
                a[i] = 1;
                if (level < n)
                {
                    Fill(i + level, ex / 2, a, level + 1, n);
                    Fill(i + level + 1, ex / 2, a, level + 1, n);
                }
            }
        }
    }
}
