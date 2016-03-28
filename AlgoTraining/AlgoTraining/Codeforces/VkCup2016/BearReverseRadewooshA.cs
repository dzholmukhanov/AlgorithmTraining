using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class BearReverseRadewooshA
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), c = fs.NextInt();
                int[] p = new int[n], t = new int[n];
                for (int i = 0; i < n; i++)
                {
                    p[i] = fs.NextInt();
                }
                for (int i = 0; i < n; i++)
                {
                    t[i] = fs.NextInt();
                }
                int limak = 0, radewoosh = 0, time = 0;
                for (int i = 0; i < n; i++)
                {
                    time += t[i];
                    limak += Math.Max(0, p[i] - c * time);
                }
                time = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    time += t[i];
                    radewoosh += Math.Max(0, p[i] - c * time);
                }
                writer.WriteLine(limak > radewoosh ? "Limak" : radewoosh > limak ? "Radewoosh" : "Tie");
            }
        }
    }
}
