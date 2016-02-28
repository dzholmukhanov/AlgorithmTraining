using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class BearAndStringDistanceECR8
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt(), totalSum = 0;
                string s = fs.ReadLine();
                int[] sum = new int[n];
                int[] sign = new int[n];
                for (int i = 0; i < n; i++)
                {
                    sum[i] = (s[i] - 'a') <= 12 ? 'z' - s[i] : s[i] - 'a';
                    sign[i] = (s[i] - 'a') <= 12 ? 1 : -1;
                    totalSum += sum[i];
                }
                if (totalSum < k) writer.WriteLine(-1);
                else
                {
                    StringBuilder sb = new StringBuilder();
                    int j = 0;
                    while (k > 0)
                    {
                        if (k > sum[j])
                        {
                            k -= sum[j];
                            sb.Append((char)(s[j] + sign[j] * sum[j]));
                        }
                        else
                        {
                            sb.Append((char)(s[j] + sign[j] * k));
                            k = 0;
                        }
                        j++;
                    }
                    while (j < n)
                    {
                        sb.Append(s[j++]);
                    }
                    writer.WriteLine(sb.ToString());
                }
            }
        }
    }
}
