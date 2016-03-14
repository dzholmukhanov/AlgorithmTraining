using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class WrongPromocodesC
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                bool[] exist = new bool[7];
                string[] codes = new string[n];
                for (int i = 0; i < n; i++)
                {
                    codes[i] = fs.ReadLine();
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        int count = CountSameDigits(codes[i], codes[j]);
                        if (!exist[count])
                        {
                            exist[count] = true;
                        }
                    }
                }
                int ans = 6;
                if (n > 1)
                {
                    if (!exist[5] && !exist[4])
                    {
                        ans = 1;
                        if (!exist[3] && !exist[2]) ans = 2;
                    }
                    else ans = 0;
                }
                writer.WriteLine(ans);
            }
        }
        public static int CountSameDigits(string code1, string code2)
        {
            int res = 0;
            for (int i = 0; i < 6; i++)
            {
                if (code1[i] == code2[i]) res++;
            }
            return res;
        }
    }
}
