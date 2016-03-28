using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class BearAndForgottenTree3C
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), d = fs.NextInt(), h = fs.NextInt();
                if (d > 2 * h)
                {
                    writer.WriteLine(-1);
                    return;
                }
                if (h == 1)
                {
                    if (d == 1)
                    {
                        if (n != 2)
                        {
                            writer.WriteLine(-1);
                        }
                        else
                        {
                            writer.WriteLine(1 + " " + 2);
                        }
                    }
                    else // d = 2
                    {
                        for (int i = 2; i <= n; i++)
                        {
                            writer.WriteLine(1 + " " + i);
                        }
                    }
                    return;
                }
                StringBuilder sb = new StringBuilder();
                int cur = 0;
                for (int i = 1; i <= h; i++)
                {
                    sb.Append((cur + 1) + " " + (i + 1) + "\n");
                    cur = i;
                }
                int cur2 = 0;
                if (d == h) cur2 = cur;
                for (int i = cur + 1; i < cur + d - h + 1; i++)
                {
                    sb.Append((cur2 + 1) + " " + (i + 1) + "\n");
                    cur2 = i;
                }
                while (cur2 < n - 1)
                {
                    cur2++;
                    sb.Append(2 + " " + (cur2 + 1) + "\n");
                }
                writer.WriteLine(sb);
            }
        }
    }
}
