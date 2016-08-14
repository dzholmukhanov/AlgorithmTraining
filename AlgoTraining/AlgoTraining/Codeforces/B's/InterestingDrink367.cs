using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class InterestingDrink367
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] x = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                Array.Sort(x);
                int q = fs.NextInt();
                int[] m = new int[q];
                for (int i = 0; i < q; i++)
                {
                    m[i] = fs.NextInt();
                }
                int max = 100000;
                int[] c = new int[max + 1];
                int k = 0, count = 0;
                for (int i = 0; i < n; i++)
			    {
                    while (k < x[i])
                    {
                        c[k++] = count;
                    }
                    count++;
                    c[k] = count;
                }
                while (k <= max)
                {
                    c[k++] = count;
                }
                for (int i = 0; i < q; i++)
                {
                    writer.WriteLine(m[i] >= max ? n : c[m[i]]);
                }
            }
        }
    }
}
