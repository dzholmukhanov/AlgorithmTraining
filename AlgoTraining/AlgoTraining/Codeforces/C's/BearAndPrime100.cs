using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class BearAndPrime100
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 4, 9, 25, 49 };
                int count = 0;
                for (int i = 0; i < primes.Length; i++)
                {
                    writer.WriteLine(primes[i]);
                    writer.Flush();
                    count += fs.ReadLine() == "yes" ? 1 : 0;
                }
                writer.WriteLine(count <= 1 ? "prime" : "composite");
                writer.Flush();
            }
        }
    }
}
