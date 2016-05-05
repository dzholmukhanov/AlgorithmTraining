using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class GameOfRobots350
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt();
                int[] ids = new int[n];
                for (int i = 0; i < n; i++)
                {
                    ids[i] = fs.NextInt();
                }
                long sum = 0;
                long r = 0;
                for (int i = 1; i <= n; i++)
                {
                    sum += i;
                    if (k <= sum)
                    {
                        r = i;
                        break;
                    }
                }
                int index = (int)(k - (r * (r - 1)) / 2) - 1;
                writer.WriteLine(ids[index]);
            }
        }
    }
}
