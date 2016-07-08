using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class GirlsZoo359
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 1; j < n - i; j++)
                    {
                        if (a[j] < a[j - 1])
                        {
                            int t = a[j];
                            a[j] = a[j - 1];
                            a[j - 1] = t;
                            writer.WriteLine(j + " " + (j + 1));
                        }
                    }
                }
            }
        }
    }
}
