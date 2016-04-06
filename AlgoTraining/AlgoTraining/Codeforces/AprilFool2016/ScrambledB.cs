using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.AprilFool2016
{
    class ScrambledB
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] m = new int[n], r = new int[n];
                for (int i = 0; i < n; i++) m[i] = fs.NextInt();
                for (int i = 0; i < n; i++) r[i] = fs.NextInt();
                int size = (int)1e6;
                bool[] onDuty = new bool[size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i % m[j] == r[j])
                        {
                            onDuty[i] = true;
                            break;
                        }
                    }
                }
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    if (onDuty[i]) count++;
                }
                writer.WriteLine(((count * 1.0) / size).ToString().Replace(",", "."));
            }
        }
    }
}
