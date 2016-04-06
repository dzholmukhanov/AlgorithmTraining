using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.AprilFool2016
{
    class WithoutTextC
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string str = fs.ReadLine();
                int res = 0;
                for (int i = 1; i <= str.Length; i++)
                {
                    char c = str[0];
                    if (i < str.Length) c = str[i];
                    bool and1 = '@' < c && '[' > c, and2 = '`' < c && '{' > c;
                    int bi1 = and1 ? 1 : 0, bi2 = and2 ? 1 : 0;
                    int times1 = bi1 * GetAlpha(c), times2 = bi2 * GetAlpha(c);
                    int minus = times1 - times2;
                    res = res + minus;
                }
                writer.WriteLine(res);
            }
        }
        public static int GetAlpha(char c)
        {
            if (c >= '0' && c <= '9' || c == '.') return 0;
            else if (c >= 'a' && c <= 'z') return c - 'a' + 1;
            else return c - 'A' + 1;
        }
    }
}
