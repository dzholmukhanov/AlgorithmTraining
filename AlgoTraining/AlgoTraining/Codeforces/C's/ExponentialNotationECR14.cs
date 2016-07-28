using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class ExponentialNotationECR14
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string s = fs.ReadLine();
                int first = -1, point = -1;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '.')
                    {
                        point = i;
                        if (first != -1) break;
                    }
                    else if (first == -1 && s[i] != '0')
                    {
                        first = i;
                        if (point != -1) break;
                    }
                }
                if (first == -1)
                {
                    writer.WriteLine(0);
                    return;
                }
                if (point == -1) point = s.Length;

                int b = point - first;
                if (b > 0) b--;
                StringBuilder sb = new StringBuilder();
                for (int i = s.Length - 1; i >= first; i--)
                {
                    if (s[i] == '.') continue;
                    if (sb.Length == 0 && s[i] == '0') continue;
                    sb.Append(s[i]);
                }
                StringBuilder ans = new StringBuilder();
                for (int i = sb.Length - 1; i >= 0; i--)
                {
                    ans.Append(sb[i]);
                    if (i > 0 && i == sb.Length - 1) ans.Append(".");
                }
                if (b != 0) ans.Append("E").Append(b);
                writer.WriteLine(ans);
            }
        }
    }
}
