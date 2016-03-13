using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces._8VCVentureCup2016
{
    class XorEquationC
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long s = fs.NextLong(), x = fs.NextLong();
                if (s < x || (s - x) % 2 != 0)
                {
                    writer.WriteLine(0);
                    return;
                }
                long and = (s - x) / 2;
                string xorStr = Convert.ToString(x, 2), andStr = Convert.ToString(and, 2);
                int onesNum = 0;
                foreach (char c in xorStr)
                {
                    if (c == '1') onesNum++;
                }
                string shortStr = xorStr;
                string longStr = andStr;
                if (xorStr.Length > andStr.Length)
                {
                    shortStr = andStr;
                    longStr = xorStr;
                }
                int p = longStr.Length - 1;
                for (int i = shortStr.Length - 1; i >= 0; i--, p--)
                {
                    if (shortStr[i] == '1' && longStr[p] == '1')
                    {
                        writer.WriteLine(0);
                        return;
                    }
                }
                writer.WriteLine(Math.Pow(2, onesNum) - (and == 0 ? 2 : 0));
            }
        }
    }
}
