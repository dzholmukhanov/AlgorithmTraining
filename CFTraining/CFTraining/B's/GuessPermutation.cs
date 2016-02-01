using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class GuessPermutation
    {
        // Not solved yet
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            if (n == 2)
            {
                Console.ReadLine();
                Console.ReadLine();
                Console.WriteLine(2 + " " + 1);
            }
            else
            {
                int[,] a = new int[n, n];
                int[] p = new int[n];
                List<int> all = new List<int>();
                for (int z = 0; z < n; z++)
                {
                    all.Add(z + 1);
                    for (int w = 0; w < n; w++)
                    {
                        a[z, w] = sc.NextInt();
                    }
                }
                int i, j, k, t, s, val = 0;
                for (i = 0; i < n; i++)
                {
                    int oc = 0;
                    for (j = 0; j < n; j++)
                    {
                        for (k = j + 1; k < n; k++)
                        {
                            if (a[i, j] == a[i, k])
                            {
                                s = i;
                                t = j;
                                oc++;
                                val = a[i, j];
                            }
                        }
                    }
                    if (oc == 1) break;
                }
                for (int l = 0; l < n; l++)
                {
                    if (a[i, l] != 0 && a[i, l] != val)
                    {
                        p[l] = a[i, l];
                        all.Remove(a[i, l]);
                    }
                }
                for (int l = 0; l < n; l++)
                {
                    if (p[l] == 0)
                    {
                        p[l] = all.First();
                        all.RemoveAt(0);
                    }
                    Console.Write(p[l] + " ");
                }
            }
        }
    }
}
