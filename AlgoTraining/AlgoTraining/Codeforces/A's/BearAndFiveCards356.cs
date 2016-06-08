using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class BearAndFiveCards356
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int[] t = new int[5];
                t[0] = fs.NextInt();
                t[1] = fs.NextInt();
                t[2] = fs.NextInt();
                t[3] = fs.NextInt();
                t[4] = fs.NextInt();
                int a = 0, b = 0, sum = t.Sum();

                for (int i = 0; i < 5; i++)
                {
                    for (int j = i + 1; j < 5; j++)
                    {
                        for (int k = j + 1; k < 5; k++)
                        {
                            if (t[i] == t[j] && t[j] == t[k] && t[i] > a) a = t[i];
                        }
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    for (int j = i + 1; j < 5; j++)
                    {
                        if (t[i] == t[j] && t[i] > b) b = t[i];
                    }
                }
                if (a != 0 && b != 0)
                {
                    if (3 * a > 2 * b) sum -= a * 3;
                    else sum -= b * 2;
                }
                else
                {
                    if (a != 0) sum -= a * 3;
                    else if (b != 0) sum -= b * 2;
                }
                writer.WriteLine(sum);
            }
        }
    }
}
