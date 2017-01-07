using CFTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class InversionsAfterShuffle388
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                SumSegmentTree seg = new SumSegmentTree(new long[n + 1]);
                double expDiff = 0, denom = n * 1L * (n + 1) / 2, expInvCount = 0;
                long inv = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    inv += seg.QuerySum(0, a[i] - 1);
                    expInvCount += ExpectedInverseCount(n - i);
                    expDiff += (expInvCount - inv) / denom;
                    seg.Update(a[i], n - i);
                }
                long initialInverseCount = 0;
                seg = new SumSegmentTree(new long[n + 1]);
                for (int i = n - 1; i >= 0; i--)
                {
                    initialInverseCount += seg.QuerySum(0, a[i] - 1);
                    seg.Update(a[i], 1);
                }
                writer.WriteLine((initialInverseCount + expDiff).ToString().Replace(",", "."));
            }
        }
        public static double ExpectedInverseCount(long k)
        {
            return k * (k - 1) / (decimal)4.0;
        }
    }
}
