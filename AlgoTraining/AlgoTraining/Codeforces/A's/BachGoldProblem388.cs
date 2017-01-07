using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class BachGoldProblem388
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                writer.WriteLine(n / 2);
                if (n % 2 == 0) 
                {
                    for (int i = 0; i < n / 2; i++)
                    {
                        writer.Write("2 ");
                    }
                }
                else
                {
                    for (int i = 0; i < (n / 2) - 1; i++)
                    {
                        writer.Write("2 ");
                    }
                    writer.Write("3");
                }
            }
        }
    }
}
