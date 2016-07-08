using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class FreeIceCream359
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                long x = fs.NextInt();
                int sad = 0;
                for (int i = 0; i < n; i++)
                {
                    string[] line = fs.ReadLine().Split();
                    if (line[0] == "+")
                    {
                        x += Convert.ToInt32(line[1]);
                    }
                    else
                    {
                        int d = Convert.ToInt32(line[1]);
                        if (x < d) sad++;
                        else x -= d;
                    }
                }
                writer.WriteLine(x + " " + sad);
            }
        }
    }
}
