using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class FriendsAndSubsequences361
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n], b = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                for (int i = 0; i < n; i++)
                {
                    b[i] = fs.NextInt();
                }
                int l = 0, j = 0;
                int max = 0, min = 0;
                long ans = 0;
                while (j < n)
                {
                    if (a[j] <= b[j])
                    {
                        if (a[max] <= a[j])
                        {
                            max = j;
                            if (a[max] > b[min])
                            {
                                l = min + 1;
                                max = l;
                                min = l;
                                j = l;
                            }
                        }
                        if (b[min] >= b[j])
                        {
                            min = j;
                            if (b[min] < a[max])
                            {
                                l = max + 1;
                                min = l;
                                max = l;
                                j = l;
                            }
                        }
                        if (a[max] == b[min])
                        {
                            ans += Math.Min(max, min) + 1 - l;
                        }
                    }
                    else
                    {
                        l = j + 1;
                        min = l;
                        max = l;
                    }
                    j++;
                }
                writer.WriteLine(ans);
            }
        }
    }
}
