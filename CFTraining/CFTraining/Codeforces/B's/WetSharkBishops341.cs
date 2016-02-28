using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class WetSharkBishops341
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            long[] a = new long[1999], b = new long[1999];
            while (n-- > 0)
            {
                int i = sc.NextInt(), j = sc.NextInt();
                a[(j - i) + 999]++;
                b[(1001 - j) - i + 999]++;
            }
            long sum = 0;
            for (int i = 0; i < 1999; i++)
            {
                sum += (a[i] * (a[i] - 1)) / 2;
                sum += (b[i] * (b[i] - 1)) / 2;
            }
            Console.WriteLine(sum);
        }
    }
}
