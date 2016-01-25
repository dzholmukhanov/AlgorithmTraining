using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.HackerRank
{
    class MaximumSubarray
    {
        public static void Run()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[N];
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    a[j] = Convert.ToInt32(line[j]);
                }
                Console.WriteLine(Contiguous(a) + " " + Noncontiguous(a));
            }
        }
        public static int Contiguous(int[] a)
        {
            int maxCurrent = a[0], max = maxCurrent;
            for (int i = 1; i < a.Length; i++)
            {
                maxCurrent = Math.Max(maxCurrent + a[i], a[i]);
                max = Math.Max(max, maxCurrent);
            }
            return max;
        }

        public static int Noncontiguous(int[] a)
        {
            int res = -1, minNegative = int.MinValue;
            foreach (int i in a) 
            {
                if (i >= 0)  {
                    if (res == -1) res = 0;
                    res += i;
                }
                else minNegative = Math.Max(i, minNegative);
            }
            return (res == -1) ? minNegative : res;
        }
    }
}
