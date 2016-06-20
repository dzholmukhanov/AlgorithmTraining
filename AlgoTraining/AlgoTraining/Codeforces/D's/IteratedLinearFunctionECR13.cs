using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class IteratedLinearFunctionECR13
    {
        private static int _mod = (int)1e9 + 7;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long A = fs.NextLong(), B = fs.NextLong(), n = fs.NextLong(), x = fs.NextLong();
                if (n == 0) writer.WriteLine(x);
                else if (n == 1) writer.WriteLine((A * x + B) % _mod);
                else
                {
                    long[,] initial = new long[,] { { A * x + B, 1 } };
                    long[,] factor = new long[,] { { A, 0 }, { B, 1 } };
                    long[,] res = MultiplyMatricesMod(initial, BinPowMatrixMod(factor, n - 1, _mod), _mod);
                    writer.WriteLine(res[0, 0]);
                }
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
