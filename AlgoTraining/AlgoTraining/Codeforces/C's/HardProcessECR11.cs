using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class HardProcessECR11
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                int l = 0, r = 0, count = 0, max = 0, maxL = -1, maxR = -1;
                if (a[0] == 0) count++;
                if (count == 0 || k > 0)
                {
                    max = 1;
                    maxL = 0;
                    maxR = 0;
                }
                while (r < n - 1)
                {
                    r++;
                    if (a[r] == 0) count++;
                    while (l < n - 1 && count > k)
                    {
                        if (a[l] == 0) count--;
                        l++;
                        if (r < l)
                        {
                            r = l;
                            if (a[l] == 0) count++;
                        }
                    }
                    if (count <= k && r - l + 1 > max)
                    {
                        max = r - l + 1;
                        maxL = l;
                        maxR = r;
                    }
                }
                writer.WriteLine(max);
                for (int i = 0; i < n; i++)
                {
                    if (max > 0 && i >= maxL && i <= maxR) writer.Write(1 + " ");
                    else writer.Write(a[i] + " ");
                }
            }
        }
    }
}
