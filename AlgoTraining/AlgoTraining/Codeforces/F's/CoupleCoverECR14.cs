using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.F_s
{
    class CoupleCoverECR14
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int max = (int)3e6;
                int[] a = new int[n];
                int[] cnt = new int[max + 1];
                long[] prod = new long[max + 1];
                for (int i = 0; i < n; i++)
			    {
			        a[i] = fs.NextInt();
                    cnt[a[i]]++;
                }
                int m = fs.NextInt();
                for (int i = 1; i <= max; i++)
                {
                    for (int j = i; i * 1L * j <= max; j++)
                    {
                        if (i == j) prod[i * j] += cnt[i] * 1L * (cnt[i] - 1);
                        else prod[i * j] += cnt[i] * 1L * cnt[j] * 2;
                    }
                }
                for (int i = 1; i < prod.Length; i++)
                {
                    prod[i] += prod[i - 1];
                }
                long total = n * 1L * (n - 1);
                while (m-- > 0)
                {
                    int p = fs.NextInt();
                    writer.WriteLine(total - prod[p - 1]);
                }
            }
        }
    }
}
