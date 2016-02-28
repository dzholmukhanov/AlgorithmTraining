using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.D_s
{
    class OptimalNumberPermutationECR7
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[2 * n];
                if (n % 2 == 0)
                {
                    for (int i = 0; i < n / 2; i++)
                    {
                        a[i] = i * 2 + 1;
                        a[n - 1 - i] = i * 2 + 1;
                    }
                    for (int i = n; i < n + (n - 1) / 2; i++)
                    {
                        a[i] = (i - n) * 2 + 2;
                        a[3 * n - 2 - i] = (i - n) * 2 + 2;
                    }
                    a[n + (n - 1) / 2] = n;
                    a[2 * n - 1] = n;
                }
                else
                {
                    for (int i = 0; i < n / 2; i++)
                    {
                        a[i] = i * 2 + 1;
                        a[n - 1 - i] = i * 2 + 1;
                    }
                    a[n / 2] = n;
                    for (int i = n; i < n + (n - 1) / 2; i++)
                    {
                        a[i] = (i - n) * 2 + 2;
                        a[3 * n - 2 - i] = (i - n) * 2 + 2;
                    }
                    a[2 * n - 1] = n;
                }
                for (int i = 0; i < 2 * n; i++)
                {
                    writer.Write(a[i] + " ");
                }
                writer.WriteLine();
            }
        }
    }
}
