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
        // Not solved yet
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt(), p = sc.NextInt();
            Shark[] s = new Shark[n];
            long total = 1;
            for (int i = 0; i < n; i++)
            {
                int l = sc.NextInt(), r = sc.NextInt();
                s[i] = new Shark { l = l, r = r};
                total *= r - l + 1;
            }
            long num = 0;
            for (int i = 0; i < n; i++)
            {
                int l = i - 1, r = i + 1;
                if (i == 0)
                {
                    l = n - 1;
                }
                else if (i == n - 1)
                {
                    r = 0;
                }
                long m1 = s[i].r / p - ((s[i].l - 1) / p), c1 = s[i].r - s[i].l + 1;
                long m2 = s[l].r / p - ((s[l].l - 1) / p), c2 = s[l].r - s[l].l + 1;
                long m3 = s[r].r / p - ((s[r].l - 1) / p), c3 = s[r].r - s[r].l + 1;
                num += (m1 * c2 + m2 * (c1 - m1)) * (total / (c1 * c2));
                num += (m1 * c3 + m3 * (c1 - m1)) * (total / (c1 * c3));
            }
            double res = (num * 1000.0) / (total * 1.0);
            Console.WriteLine(res.ToString().Replace(",", "."));
        }
    }
    class Shark
    {
        public int l, r;
    }
}
