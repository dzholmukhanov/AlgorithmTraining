using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Coursera
{
    class MaximumPairwiseMult
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                long max1 = 0, max2 = 0;
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                    if (a[i] > a[max1])
                    {
                        max1 = i;
                    }
                }
                if (max1 == 0) max2 = 1;
                for (int i = 0; i < n; i++)
                {
                    if (a[i] > a[max2] && i != max1)
                    {
                        max2 = i;
                    }
                }
                writer.WriteLine(a[max1] * (long)a[max2]);
            }
        }
    }
}
