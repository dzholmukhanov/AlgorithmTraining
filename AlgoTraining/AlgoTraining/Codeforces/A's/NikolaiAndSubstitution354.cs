using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class NikolaiAndSubstitution354
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                int min = n + 1, max = 0, l = -1, r = -1;
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                    if (a[i] < min)
                    {
                        min = a[i];
                        l = i;
                    }
                    if (a[i] > max)
                    {
                        max = a[i];
                        r = i;
                    }
                }
                if (l > r)
                {
                    int t = l;
                    l = r;
                    r = t;
                }
                if (r > n - l - 1) writer.WriteLine(r);
                else writer.WriteLine(n - l - 1);
            }
        }
    }
}
