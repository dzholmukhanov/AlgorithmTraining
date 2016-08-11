using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class Hulk366
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0) sb.Append("I hate ");
                    else sb.Append("I love ");
                    if (i < n - 1) sb.Append("that ");
                }
                sb.Append("it");
                writer.WriteLine(sb);
            }
        }
    }
}
