using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class MishkaAndGame365
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int m = 0, c = 0;
                for (int i = 0; i < n; i++)
                {
                    int a = fs.NextInt(), b = fs.NextInt();
                    if (a > b) m++;
                    else if (b > a) c++;
                }
                writer.WriteLine(m > c ? "Mishka" : c > m ? "Chris" : "Friendship is magic!^^");
            }
        }
    }
}
