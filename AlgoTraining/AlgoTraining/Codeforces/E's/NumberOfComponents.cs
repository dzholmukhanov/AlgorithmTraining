using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class NumberOfComponents
    {
        private static long N;
        private static long[] Arr;

        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                N = fs.NextInt();
                Arr = new long[N];
                for (int i = 0; i < N; i++)
                {
                    Arr[i] = fs.NextLong();
                }
                long sum = Count(0, 0);
                for (int i = 1; i < N; i++)
                {
                    sum += Count(i, i) - Count(i - 1, i);
                }
                Console.WriteLine(sum);
            }
        }

        //public static long Sum(int lBorder, int rBorder)
        //{
        //    if (lBorder == rBorder)
        //    {
        //        return Count(lBorder, lBorder);
        //    }
        //    int mid = (rBorder - lBorder) / 2;
        //    return Sum(lBorder, lBorder + mid) + Sum(lBorder + mid + 1, rBorder) - Count(lBorder + mid, lBorder + mid + 1);
        //}

        public static long Count(int i, int j)
        {
            return (N - Math.Max(Arr[i], Arr[j]) + 1) * Math.Min(Arr[i], Arr[j]);
        }
    }
}
