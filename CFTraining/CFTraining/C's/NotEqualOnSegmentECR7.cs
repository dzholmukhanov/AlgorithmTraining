using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class NotEqualOnSegmentECR7
    {
        public static void Run()
        {
            using (FastScanner reader = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = reader.NextInt(), m = reader.NextInt();
                int[] a = new int[n], count = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = reader.NextInt();
                }
                count[n - 1] = 1;
                for (int i = n - 2; i >= 0; i--)
                {
                    if (a[i] == a[i + 1]) count[i] = count[i + 1] + 1;
                    else count[i] = 1;
                }
                while (m-- > 0)
                {
                    int l = reader.NextInt() - 1, r = reader.NextInt() - 1, x = reader.NextInt(), t = l;
                    if (a[l] == x) t = l + count[l];
                    if (t > r) writer.WriteLine(-1);
                    else writer.WriteLine(t + 1);
                }
            }
        }
    }
}
