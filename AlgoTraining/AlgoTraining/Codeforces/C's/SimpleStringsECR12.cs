using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class SimpleStringsECR12
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string s = fs.ReadLine();
                StringBuilder sb = new StringBuilder(s.Length);
                sb.Append(s[0]);
                for (int i = 1; i < s.Length; i++)
                {
                    if (sb[i - 1] == s[i]) sb.Append(FindAnother(s[i], i + 1 < s.Length ? s[i + 1] : '-'));
                    else sb.Append(s[i]);
                }
                writer.WriteLine(sb);
            }
        }
        public static char FindAnother(char a, char b)
        {
            char i = 'a';
            while (i <= 'z')
            {
                if (i != a && i != b) return i;
                i++;
            }
            return '-';
        }
    }
}
