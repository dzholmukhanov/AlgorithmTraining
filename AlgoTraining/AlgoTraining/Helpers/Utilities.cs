using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /* This function calculates power of p in n! */
        private static int CountFact(int n, int p)
        {
            int k = 0;
            while (n >= p)
            {
                k += n / p;
                n /= p;
            }
            return k;
        }

        /*  Modular Multiplicative Inverse
            Using Euler's Theorem
            a^(phi(m)) = 1 (mod m)
            a^(-1) = a^(m-2) (mod m) */
        private static long InverseEuler(int n, int mod)
        {
            return BinPowMod(n, mod - 2, mod);
        }

        public static int FactorialMod(int n, int mod)
        {
            long res = 1; 
            while (n > 0)
            {
                for (int i = 2, m = n % mod; i <= m; i++)
                    res = (res * i) % mod;
                if ((n /= mod) % 2 > 0)
                    res = mod - res;
            }
            return (int)res;
        }

        public static long Combination(int n, int r, int mod)
        {
            if (CountFact(n, mod) > CountFact(r, mod) + CountFact(n - r, mod))
                return 0;

            return (FactorialMod(n, mod) *
                    ((InverseEuler(FactorialMod(r, mod), mod) *
                    InverseEuler(FactorialMod(n - r, mod), mod)) % mod)) % mod;
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
                long t = BinPowMod(a, p / 2, mod);
                return (t * t) % mod;
            }
            else
            {
                return (a % mod * BinPowMod(a, p - 1, mod)) % mod;
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

        private static long[,] MatrixProductMod(long[,] matrixA, long[,] matrixB, long mod)
        {
            int aRows = matrixA.GetLength(0); int aCols = matrixA.GetLength(1);
            int bRows = matrixB.GetLength(0); int bCols = matrixB.GetLength(1);
            if (aCols != bRows)
                throw new Exception("Can't multiply because of incompatible sizes");

            long[,] result = new long[aRows, bCols];

            Parallel.For(0, aRows, i =>
            {
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k) // could use k < bRows
                        result[i, j] = (result[i, j] + matrixA[i, k] * matrixB[k, j]) % mod;
            });

            return result;
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
