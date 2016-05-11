using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class SummerSchool352
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= 1000; i++) sb.Append(i);
                string s = sb.ToString();
                int n = fs.NextInt();
                writer.WriteLine(s[n - 1]);
            }
        }
    }
}
