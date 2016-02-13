using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.HackerRank
{
    class StockMaximize
    {
        public static void Run()
        {
            ConsoleScanner cs = new ConsoleScanner();
            int T = cs.NextInt();
            while (T-- > 0)
            {
                int N = cs.NextInt();
                long[] sum = new long[N], a = new long[N];
                int[] index = new int[N];
                for (int i = 0; i < N; i++)
                {
                    a[i] = cs.NextInt();
                    index[i] = i;
                    if (i > 0) sum[i] = sum[i - 1] + a[i];
                    else sum[0] = a[0];
                }
                Array.Sort(a, index);
                long res = 0;
                int left = 0;
                for (int i = N - 1; i >= 0; i--)
                {
                    int maxIndex = index[i];
                    if (maxIndex >= left)
                    {
                        res += a[i] * (maxIndex - left) - (maxIndex > 0 ? sum[maxIndex - 1] : 0) + (left > 0 ? sum[left - 1] : 0);
                        left = maxIndex + 1;
                    }
                }
                Console.WriteLine(res);
            }
        }
    }
}
