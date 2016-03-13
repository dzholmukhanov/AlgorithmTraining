using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class GrandmaLauraAndApplesECR9
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), p = fs.NextInt();
                string[] buyers = new string[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    buyers[i] = fs.ReadLine();
                }
                long revenue = p / 2;
                double prevVal = 1;
                for (int i = 1; i < n; i++)
                {
                    if (buyers[i] == "half") prevVal *= 2;
                    else prevVal = prevVal * 2 + 1;
                    revenue += (long)((prevVal / 2) * p);
                }
                writer.WriteLine(revenue);
            }
        }
    }
}
