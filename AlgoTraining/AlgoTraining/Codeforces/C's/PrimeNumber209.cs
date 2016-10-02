using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class PrimeNumber209
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), x = fs.NextInt();
                int mod = (int)1e9 + 7;
                long[] a = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt64);

                long sum = a.Sum();
                SortedDictionary<long, int> count = new SortedDictionary<long, int>();
                for (int i = 0; i < n; i++)
                {
                    long pow = sum - a[i];
                    if (!count.ContainsKey(pow)) count[pow] = 0;
                    count[pow]++;
                }
                LinkedList<Frequency> freqs = new LinkedList<Frequency>();
                foreach (var pair in count)
                {
                    freqs.AddLast(new Frequency { Pow = pair.Key, Value = pair.Value });
                }
                long minPow = 0;
                while(freqs.Count > 0) 
                {
                    var node = freqs.First;
                    freqs.RemoveFirst();
                    var next = freqs.First;
                    long pow = node.Value.Pow;
                    int freq = node.Value.Value;
                    if (freq % x == 0)
                    {
                        if (next != null && next.Value.Pow == pow + 1)
                        {
                            next.Value.Value += freq / x;
                        }
                        else
                        {
                            freqs.AddFirst(new Frequency { Pow = pow + 1, Value = freq / x });
                        }
                    }
                    else
                    {
                        minPow = pow;
                        break;
                    }
                }
                writer.WriteLine(BinPowMod(x, Math.Min(minPow, sum), mod));
            }
        }
        public static long BinPowMod(long a, long p, long mod)
        {
            if (p == 0) return 1;
            if ((p & 1) == 0)
            {
                long t = BinPowMod(a, p / 2, mod);
                return (t * t) % mod;
            }
            else
            {
                return (a % mod * BinPowMod(a, p - 1, mod)) % mod;
            }
        }
        class Frequency
        {
            public long Pow;
            public int Value;
        }
    }
}
