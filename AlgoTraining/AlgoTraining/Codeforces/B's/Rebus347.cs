using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class Rebus347
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string[] str = fs.ReadLine().Split(' ');
                int n = Convert.ToInt32(str.Last());
                int plusK = 0, minusK = 0;
                foreach (string s in str)
                {
                    if (s == "+") plusK++;
                    else if (s == "-") minusK++;
                }
                if (plusK >= minusK && plusK - Math.Min(plusK, minusK * n) < n)
                {
                    int[] minus = Enumerable.Repeat(1, minusK).ToArray();
                    int sum = minusK, j = 0;
                    while (sum < plusK && sum < minusK * n)
                    {
                        if (minus[j] < n) minus[j]++;
                        j = (j + 1) % minusK;
                        sum++;
                    }
                    j = 0;
                    writer.WriteLine("Possible");
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i == 0)
                        {
                            writer.Write((n - plusK + Math.Min(plusK, minusK * n)) + " ");
                        }
                        else if (str[i] == "?")
                        {
                            if (str[i - 1] == "+") writer.Write(1 + " ");
                            else writer.Write(minus[j++] + " ");
                        }
                        else
                        {
                            writer.Write(str[i] + " ");
                        }
                    }
                }
                else if (minusK > plusK && minusK <= plusK * n)
                {
                    int[] plus = Enumerable.Repeat(1, plusK).ToArray();
                    int sum = plusK, j = 0;
                    while (sum < minusK)
                    {
                        if (plus[j] < n) plus[j]++;
                        j = (j + 1) % plusK;
                        sum++;
                    }
                    j = 0;
                    writer.WriteLine("Possible");
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i == 0)
                        {
                            writer.Write(n + " ");
                        }
                        else if (str[i] == "?")
                        {
                            if (str[i - 1] == "+") writer.Write(plus[j++] + " ");
                            else writer.Write(1 + " ");
                        }
                        else
                        {
                            writer.Write(str[i] + " ");
                        }
                    }
                }
                else
                {
                    writer.WriteLine("Impossible");
                    return;
                }
            }
        }
    }
}