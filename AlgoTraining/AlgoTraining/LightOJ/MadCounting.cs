using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.LightOJ
{
    class MadCounting
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                for (int i = 1; i <= t; i++)
                {
                    int n = fs.NextInt();
                    int[] count = new int[(int)1e6 + 2];
                    for (int j = 0; j < n; j++)
                    {
                        int x = fs.NextInt() + 1;
                        count[x]++;
                    }
                    int ans = 0;
                    for (int j = 1; j < count.Length; j++)
                    {
                        if (count[j] > 0)
                        {
                            ans += (int)(Math.Ceiling(count[j]/(j * 1.0)) * j);
                        }
                    }
                    writer.WriteLine("Case " + i + ": " + ans);
                }
            }
        }
    }
}
