using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CFTraining
{
    public class Utilities
    {
        public static int binRangeSearch(int[] a, int l, int r, int val)
        {
            if (a[r] < val) return r;
            else if (l >= r) return -1;

            int m = l + (r - l) / 2;
            if (a[m] < val && a[m + 1] < val) return binRangeSearch(a, m + 1, r, val);
            else if (a[m] > val && a[m + 1] > val) return binRangeSearch(a, l, m, val);
            else if (a[m] < val && val <= a[m + 1]) return m;
            else if (a[m] == val && val < a[m + 1] && m > 0) return m - 1;
            else return -1;
        }
        public static void ReadAndWrite()
        {
            var fs = File.Open("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var sw = new StreamWriter(fs);
            var sr = new StreamReader(fs);
            sw.Close();
            sr.Close();
        }
        public static void Print2DArray(int[,] a)
        {
            Console.WriteLine();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static long BinPow(long a, long p)
        {
            if (p == 0) return 1;
            if ((p & 1) == 0)
            {
                long t = BinPow(a, p / 2);
                return t * t;
            }
            else
            {
                return a * BinPow(a, p - 1);
            }
        }
        public static long BinPowMod(long a, long p, long mod)
        {
            if (p == 0) return 1;
            if ((p & 1) == 0)
            {
                long t = BinPow(a, p / 2);
                return (t * t) % mod;
            }
            else
            {
                return (a % mod * BinPow(a, p - 1)) % mod;
            }
        }

        public static long[,] BinPowMatrix(long[,] a, long p) // p >= 1
        {
            if (a.GetLength(0) != a.GetLength(1))
            {
                throw new Exception("Not a square matrix");
            }

            if (p == 1) return a;
            if ((p & 1) == 0)
            {
                long[,] t = BinPowMatrix(a, p / 2);
                return MultiplyMatrices(t, t);
            }
            else
            {
                return MultiplyMatrices(a, BinPowMatrix(a, p - 1));
            }
        }

        public static long[,] BinPowMatrixMod(long[,] a, long p, long mod) // p >= 1
        {
            if (a.GetLength(0) != a.GetLength(1))
            {
                throw new Exception("Not a square matrix");
            }

            if (p == 1) return a;
            if ((p & 1) == 0)
            {
                long[,] t = BinPowMatrixMod(a, p / 2, mod);
                return MultiplyMatricesMod(t, t, mod);
            }
            else
            {
                return MultiplyMatricesMod(a, BinPowMatrixMod(a, p - 1, mod), mod);
            }
        }

        private static long[,] MultiplyMatrices(long[,] a, long[,] b)
        {
            if (a.GetLength(1) == b.GetLength(0))
            {
                long[,] c = new long[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < c.GetLength(0); i++)
                {
                    for (int j = 0; j < c.GetLength(1); j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < a.GetLength(1); k++)
                            c[i, j] = c[i, j] + a[i, k] * b[k, j];
                    }
                }
                return c;
            }
            else
            {
                throw new Exception("Can't multiply because of incompatible sizes");
            }
        }

        private static long[,] MultiplyMatricesMod(long[,] a, long[,] b, long mod)
        {
            if (a.GetLength(1) == b.GetLength(0))
            {
                long[,] c = new long[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < c.GetLength(0); i++)
                {
                    for (int j = 0; j < c.GetLength(1); j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < a.GetLength(1); k++)
                        {
                            c[i, j] = c[i, j] + a[i, k] % mod * b[k, j] % mod;
                            c[i, j] %= mod;
                        }
                    }
                }
                return c;
            }
            else
            {
                throw new Exception("Can't multiply because of incompatible sizes");
            }
        }

        private static long[,] MatrixMod(long[,] a, long mod)
        {
            long[,] b = new long[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    b[i, j] = a[i, j] % mod;
                }
            }
            return b;
        }
    }
}
