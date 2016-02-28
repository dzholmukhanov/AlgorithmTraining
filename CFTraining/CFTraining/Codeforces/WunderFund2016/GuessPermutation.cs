using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.WunderFund2016
{
    class GuessPermutation
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            int[,] a = new int[n, n];
            int[] p = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = sc.NextInt();
                }
            }
            int[] rem = new int[2];
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                int[] count = new int[n + 1];
                bool found = false;
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    count[a[i, j]]++;
                    if (count[a[i, j]] == 2)
                    {
                        p[i] = a[i, j];
                        found = true;
                        break;
                    }
                }
                if (!found) rem[c++] = i;
            }
            p[rem[0]] = n - 1;
            p[rem[1]] = n;
            foreach (int i in p)
            {
                Console.Write(i + " ");
            }
        }
    }
}
