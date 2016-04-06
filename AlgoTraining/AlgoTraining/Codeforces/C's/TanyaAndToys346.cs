using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class TanyaAndToys346
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long n = fs.NextInt(), m = fs.NextLong();
                long[] a = new long[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextLong();
                }
                Array.Sort(a);
                long sum = 0, j = 1, k = 0, count = 0;
                StringBuilder sb = new StringBuilder();
                while (sum < m && j <= 1e9)
                {
                    if (k < n && j == a[k])
                    {

                        k++;
                    }
                    else
                    {
                        if (sum + j <= m)
                        {
                            count++;
                            sum += j;
                            sb.Append(j + " ");
                        }
                        else break;
                    }
                    j++;
                }
                //string ans = sb.ToString();
                //if (ans.Length > 0 && ans.Last() == ' ') ans = ans.Substring(0, ans.Length - 1);
                writer.WriteLine(count);
                if (count > 0) writer.WriteLine(sb);
            }
        }
    }
}
