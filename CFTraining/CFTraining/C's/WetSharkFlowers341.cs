using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class WetSharkFlowers341
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt(), p = sc.NextInt();
            long[] l = new long[n], r = new long[n];
            for (int i = 0; i < n; i++)
            {
                l[i] = sc.NextInt();
                r[i] = sc.NextInt();
            }
            double expected = 0;
            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                long pi = r[i] / p - (l[i] - 1) / p, pj = r[j] / p - (l[j] - 1) / p;
                double e = 1 - ((r[i] - l[i] + 1 - pi) * (r[j] - l[j] + 1 - pj) * 1.0) / ((r[i] - l[i] + 1) * (r[j] - l[j] + 1) * 1.0);
                expected += e * 2e3;
            }
            Console.WriteLine(expected.ToString().Replace(",", "."));
        }
    }
}
