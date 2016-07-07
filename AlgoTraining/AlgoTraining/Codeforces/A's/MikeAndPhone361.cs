using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class MikeAndPhone361
    {
        private static int[,] digits = new int[4, 3] 
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
            {-1, 0, -1},
        };

        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                List<int[]> d = new List<int[]>();
                string s = fs.ReadLine();
                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse("" + s[i]);
                    if (i > 0) d.Add(GetDiff(a[i - 1], a[i]));
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (digits[i, j] == a[0]) continue;
                        if (digits[i, j] != -1 && IsValid(i, j, d))
                        {
                            writer.WriteLine("NO");
                            return;
                        }
                    }
                }
                writer.WriteLine("YES");
            }
        }
        private static bool IsValid(int i, int j, List<int[]> d)
        {
            try
            {
                foreach (int[] v in d)
                {
                    i += v[0];
                    j += v[1];
                    if (digits[i, j] == -1) return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static int[] GetDiff(int d1, int d2)
        {
            int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (digits[i, j] == d1)
                    {
                        i1 = i;
                        j1 = j;
                    }
                    if (digits[i, j] == d2)
                    {
                        i2 = i;
                        j2 = j;
                    }
                }
            }
            return new int[] { i2 - i1, j2 - j1 };
        }
    }
}
