using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.LightOJ
{
    class AnsweringQueries
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                for (int i = 1; i <= t; i++)
                {
                    writer.WriteLine("Case " + i + ":");
                    int n = fs.NextInt(), q = fs.NextInt();
                    int[] a = new int[n];
                    long sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        a[j] = fs.NextInt();
                        sum -= j * a[j];
                        sum += (n - j - 1) * a[j];
                    }
                    while (q-- > 0)
                    {
                        int c = fs.NextInt();
                        if (c == 0)
                        {
                            int x = fs.NextInt(), v = fs.NextInt();
                            long diff = v - a[x];
                            sum -= x * diff;
                            sum += (n - x - 1) * diff;
                            a[x] = v;
                        }
                        else
                        {
                            writer.WriteLine(sum);
                        }
                    }
                }
            }
        }
    }
}
