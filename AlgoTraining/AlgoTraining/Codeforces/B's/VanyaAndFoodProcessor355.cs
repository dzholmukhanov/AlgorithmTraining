using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class VanyaAndFoodProcessor355
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), h = fs.NextInt(), k = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                int sum = 0, j = 0;
                long sec = 0;
                while (j < n)
                {
                    while (j < n && sum + a[j] <= h) sum += a[j++];
                    if (j < n)
                    {
                        int need = a[j] - (h - sum);
                        int s = (int)Math.Ceiling(need * 1.0 / k);
                        sec += s;
                        sum -= s * k;
                        if (sum < 0) sum = 0;
                    }
                    else
                    {
                        sec += (int)Math.Ceiling(sum * 1.0 / k);
                    }
                }
                writer.WriteLine(sec);
            }
        }
    }
}
