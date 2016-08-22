using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class Colliders109
    {
        private static List<int> Primes;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                bool[] isActivated = new bool[n + 1];
                int[] primeOccupation = new int[100001];

                FillPrimeList();
                while (m-- > 0)
                {
                    string[] toks = fs.ReadLine().Split();
                    int colNum = Convert.ToInt32(toks[1]);
                    if (toks[0] == "+")
                    {
                        if (isActivated[colNum])
                        {          
                            writer.WriteLine("Already on");
                        }
                        else
                        {
                            List<int> factors = UniquePrimeFactors(colNum);
                            int conflictWith = -1;
                            foreach (int p in factors)
                            {
                                if (primeOccupation[p] != 0)
                                {
                                    conflictWith = primeOccupation[p];
                                    break;
                                }
                            }
                            if (conflictWith != -1) writer.WriteLine("Conflict with " + conflictWith);
                            else
                            {
                                foreach (int p in factors)
                                {
                                    primeOccupation[p] = colNum;
                                }
                                isActivated[colNum] = true;
                                writer.WriteLine("Success");
                            }
                        }
                    }
                    else
                    {
                        if (!isActivated[colNum])
                        {
                            writer.WriteLine("Already off");
                        }
                        else
                        {
                            List<int> factors = UniquePrimeFactors(colNum);
                            foreach (int p in factors)
                            {
                                primeOccupation[p] = 0;
                            }
                            isActivated[colNum] = false;
                            writer.WriteLine("Success");
                        }
                    }
                }
            }
        }
        public static void FillPrimeList()
        {
            bool[] isPrime = Enumerable.Repeat(true, 401).ToArray();
            Primes = new List<int>();
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i * i < 401; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < 401; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            for (int i = 2; i < 401; i++)
            {
                if (isPrime[i]) Primes.Add(i);
            }
        }
        public static List<int> UniquePrimeFactors(int x)
        {
            int sqrt = (int) Math.Sqrt(x);
            List<int> factors = new List<int>();
            foreach (int p in Primes)
            {
                if (p > sqrt) break;
                if (x % p == 0)
                {
                    factors.Add(p);
                    while (x % p == 0) x /= p;
                }
            }
            if (x != 1) factors.Add(x);
            return factors;
        }
    }
}
