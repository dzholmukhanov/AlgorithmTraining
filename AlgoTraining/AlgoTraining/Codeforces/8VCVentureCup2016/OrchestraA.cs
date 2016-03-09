using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces._8VCVentureCup2016
{
    public class OrchestraA
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int r = fs.NextInt(), c = fs.NextInt(), n = fs.NextInt(), k = fs.NextInt();
                bool[,] a = new bool[r, c];
                for (int i = 0; i < n; i++)
                {
                    int row = fs.NextInt() - 1, col = fs.NextInt() - 1;
                    a[row, col] = true;
                }
                int ans = 0;
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        int[] counts = new int[c - j];
                        for (int l = i; l < r; l++) 
                        {
                            int count = 0;
                            for (int m = j; m < c; m++)
                            {
                                if (a[l, m]) counts[m - j]++;
                                count += counts[m - j];
                                if (count >= k) ans++;
                            }
                        }
                    }
                }
                writer.WriteLine(ans);
            }
        }
    }
}
