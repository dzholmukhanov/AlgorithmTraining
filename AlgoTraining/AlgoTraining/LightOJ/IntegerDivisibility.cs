using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.LightOJ
{
    class IntegerDivisibility
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                for (int i = 1; i <= t; i++)
                {
                    int n = fs.NextInt(), digit = fs.NextInt();
                    long temp = digit % n, cnt = 1;
                    while (temp != 0)
                    {
                        temp = temp * 10 + digit;
                        cnt++;
                        temp %= n;
                    }
                    writer.WriteLine("Case " + i + ": " + cnt);
                }
            }
        }
    }
}
