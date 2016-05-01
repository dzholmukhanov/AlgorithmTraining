using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class SimpleSubsetECR12
    {
        private static bool[] _isPrime;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                int oneK = 0;
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                    if (a[i] == 1) oneK++;
                }
                Array.Sort(a);
                EvalSieve();
                List<int> subset = new List<int>();
                if (oneK == 1)
                {
                    subset.Add(1);
                    bool solved = false;
                    int p1 = 0, p2 = 0;
                    for (int i = 1; i < n && !solved; i++)
                    {
                        for (int j = i + 1; j < n && !solved; j++)
                        {
                            if (_isPrime[a[i] + a[j]])
                            {
                                p1 = a[i];
                                p2 = a[j];
                                if (_isPrime[a[i] + 1] && _isPrime[a[j] + 1])
                                {
                                    subset.Add(a[i]);
                                    subset.Add(a[j]);
                                    solved = true;
                                }
                            }
                        }
                    }
                    for (int i = 1; i < n && !solved; i++)
                    {
                        if (_isPrime[a[i] + 1])
                        {
                            subset.Add(a[i]);
                            solved = true;
                        }
                    }
                    if (!solved && p1 != 0)
                    {
                        subset = new List<int>();
                        subset.Add(p1);
                        subset.Add(p2);
                    }
                }
                else if (oneK == 0)
                {
                    bool solved = false;
                    for (int i = 0; i < n && !solved; i++)
                    {
                        for (int j = i + 1; j < n && !solved; j++)
                        {
                            if (_isPrime[a[i] + a[j]])
                            {
                                subset.Add(a[i]);
                                subset.Add(a[j]);
                                solved = true;
                            }
                        }
                    }
                    if (!solved) subset.Add(a[0]);
                }
                else if (oneK > 1)
                {
                    subset.AddRange(Enumerable.Repeat(1, oneK));
                    bool solved = false;
                    for (int i = oneK; i < n && !solved; i++)
                    {
                        for (int j = i + 1; j < n && !solved; j++)
                        {
                            if (_isPrime[a[i] + a[j]] && _isPrime[a[i] + 1] && _isPrime[a[j] + 1])
                            {
                                subset.Add(a[i]);
                                subset.Add(a[j]);
                                solved = true;
                            }
                        }
                    }
                    for (int i = oneK; i < n && !solved; i++)
                    {
                        if (_isPrime[a[i] + 1])
                        {
                            subset.Add(a[i]);
                            solved = true;
                        }
                    }
                }
                writer.WriteLine(subset.Count);
                foreach (int x in subset)
                {
                    writer.Write(x + " ");
                }
            }
        }
        public static void EvalSieve()
        {
            int max = 2 * (int)1e6;
            _isPrime = Enumerable.Repeat(true, max + 1).ToArray();
            _isPrime[0] = false;
            _isPrime[1] = false;
            for (int i = 2; i * i <= max; i++)
            {
                if (_isPrime[i])
                {
                    for (int j = i; i * j <= max; j++)
                    {
                        _isPrime[i * j] = false;
                    }
                }
            }
        }
    }
}
