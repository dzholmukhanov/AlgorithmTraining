using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class MikeAndThiefs361
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long maxCapacity = (long)1e16;
                long ways = fs.NextLong();
                long requiredCapacity = FindVal(1, maxCapacity, ways);
                writer.WriteLine(requiredCapacity);
            }
        }

        private static long FindVal(long l, long r, long ways)
        {
            if (l > r) return -1;
            long mid = (l + r) / 2;
            long res = 0;
            for (long k = 2, prod = k * k * k; prod <= mid; k++, prod = k * k * k)
            {
                res += mid / prod;
            }
            if (res < ways) return FindVal(mid + 1, r, ways);
            else if (res > ways) return FindVal(l, mid - 1, ways);
            else
            {
                if (l != r) return FindVal(l, mid, ways);
                else return l;
            }
        }
    }
}
