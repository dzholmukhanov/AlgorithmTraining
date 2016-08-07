using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class MishkaAndTrip365
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                long[] c = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt64);
                bool[] isCap = new bool[n];
                long sum = c.Sum(), res = 0, caps = 0;
                for (int i = 0; i < k; i++)
                {
                    int ind = fs.NextInt() - 1;
                    isCap[ind] = true;
                    caps += c[ind];
                }
                for (int i = 0; i < n; i++)
                {
                    int l = i - 1, r = (i + 1) % n;
                    if (l < 0) l = n - 1;
                    if (isCap[i]) res += c[i] * (sum - c[i]);
                    else
                    {
                        res += c[i] * caps;
                        if (!isCap[l]) res += c[i] * c[l];
                        if (!isCap[r]) res += c[i] * c[r];
                    }
                }
                writer.WriteLine(res / 2);
            }
        }
    }
}
