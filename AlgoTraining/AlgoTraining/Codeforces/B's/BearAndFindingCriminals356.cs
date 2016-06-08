using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class BearAndFindingCriminals356
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), a = fs.NextInt() - 1;
                int[] b = new int[n];
                for (int i = 0; i < n; i++)
                {
                    b[i] = fs.NextInt();
                }
                int j = a - 1, k = a + 1;
                int ans = b[a];
                while (j >= 0 && k < n)
                {
                    if (b[j] == 1 && b[k] == 1) ans += 2;
                    j--;
                    k++;
                }
                if (j >= 0)
                {
                    for (int i = 0; i <= j; i++)
                    {
                        ans += b[i];
                    }
                }
                else if (k < n)
                {
                    for (int i = k; i < n; i++)
                    {
                        ans += b[i];
                    }
                }
                writer.WriteLine(ans);
            }
        }
    }
}
