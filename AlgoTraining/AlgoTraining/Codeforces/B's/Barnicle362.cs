using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class Barnicle362
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string[] exp = fs.ReadLine().Split('e');
                string[] num = exp[0].Split('.');

                int b = int.Parse(exp[1]);
                StringBuilder sb = new StringBuilder(200);
                sb.Append(num[0]);
                int i = 0;
                for (i = 0; i < b; i++)
                {
                    if (i >= num[1].Length) sb.Append("0");
                    else sb.Append(num[1][i]);
                }
                if (b < num[1].Length && num[1] != "0")
                {
                    sb.Append(".");
                    for (; i < num[1].Length; i++)
                    {
                        sb.Append(num[1][i]);
                    }
                }
                writer.WriteLine(sb);
            }
        }
    }
}
