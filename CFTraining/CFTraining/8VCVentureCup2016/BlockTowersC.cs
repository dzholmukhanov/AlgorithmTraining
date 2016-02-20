using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining._8VCVentureCup2016
{
    class BlockTowersC
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), p2 = 2, p3 = 3;
                int[] a = new int[(int)1e7];
                for (int i = 1; i <= n; i++) 
                {
                    a[p2]++;
                    p2 += 2;
                }
                for (int i = 1; i <= m; i++)
                {
                    a[p3]++;
                    p3 += 3;
                }
                while (a[p2] != 0) p2 += 2;
                while (a[p3] != 0) p3 += 3;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] == 2)
                    {
                        if (p2 <= p3)
                        {
                            a[p2]++;
                            while (a[p2] != 0) p2 += 2;
                        }
                        else
                        {
                            a[p3]++;
                            while (a[p3] != 0) p3 += 3;
                        }
                    }
                }
                writer.WriteLine(Math.Max(p2 - 2, p3 - 3));
            }
        }
    }
}
