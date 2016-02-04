using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.AimTech
{
    class ProblemB
    {
        public static void Run()
        {
            ConsoleScanner cs = new ConsoleScanner();
            int n = cs.NextInt();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = cs.NextInt();
            }
            a = a.OrderBy(x => x).ToArray();
            long len = 0;
            int prev = int.MaxValue;
            for (int i = n - 1; i >= 0; i--)
            {
                if (a[i] < prev)
                {
                    len += a[i];
                    prev = a[i];
                    if (prev == 1) break;
                }
                else
                {
                    len += prev - 1;
                    prev--;
                    if (prev == 1) break;
                }
            }
            Console.WriteLine(len);
        }
    }
}
