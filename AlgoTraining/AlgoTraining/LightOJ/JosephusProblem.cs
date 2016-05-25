using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.LightOJ
{
    class JosephusProblem
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                for (int i = 1; i <= t; i++)
                {
                    int n = fs.NextInt(), k = fs.NextInt();
                    int j = Josephus(n, k) + 1;
                    writer.WriteLine(string.Format("Case {0}: {1}", i, j));
                }
            }
        }
        public static int Josephus(int n, int k)
        {
            if (n == 1) return 0;
            return (Josephus(n - 1, k) + k) % n;
        }
    }
}
