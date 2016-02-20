using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining._8VCVentureCup2016
{
    class JerrysProtestD
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = 5000;
                int[] a = new int[n], difOcc = new int[m], totalOcc = new int[5000];
                double spec = 0;
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        difOcc[Math.Abs(a[i] - a[j])]++;
                    }
                }
                totalOcc[m - 1] = difOcc[m - 1];
                for (int i = m - 2; i >= 0; i--)
                {
                    totalOcc[i] = totalOcc[i + 1] + difOcc[i];
                }
                for (int i = 1; i < m; i++)
                {
                    for (int j = 1; j < m; j++)
                    {
                        if (difOcc[i] > 0 && difOcc[j] > 0)
                        {
                            int rem = i + j + 1;
                            if (rem < m)
                            {
                                spec += (long)difOcc[i] * (long)difOcc[j] * (long)totalOcc[rem];
                            }
                        }
                    }
                }
                writer.WriteLine((spec / Math.Pow(totalOcc[0], 3)).ToString().Replace(",", "."));
            }
        }
    }
}
