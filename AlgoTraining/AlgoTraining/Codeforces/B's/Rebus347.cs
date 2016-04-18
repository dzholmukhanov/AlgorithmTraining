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
                if (plusK > minusK && n - (plusK - minusK) <= 0)
                {
                    writer.WriteLine("Impossible");
                    return;
                }
                else if (plusK < minusK)
                {
                    minusK -= plusK;
                    int p = n / minusK, q = n % minusK, count = p + q > 0 ? 1 : 0;
                    if (plusK < count) 
                    {
                        writer.WriteLine("Impossible");
                        return;
                    }
                    writer.WriteLine("Possible");
                    int t = -1;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i == 0)
                        {
                            writer.Write((n - plusK + count) + " ");
                        }
                        else if (str[i] == "?")
                        {
                            if (t == 0)
                            {
                                if (p > 0)
                                {
                                    writer.Write(n + " ");
                                    p--;
                                }
                                else if (q > 0)
                                {
                                    writer.Write(q + " ");
                                    q = 0;
                                }
                                else writer.Write(1 + " ");
                            }
                            else writer.Write(1 + " ");
                        }
                        else
                        {
                            if (str[i] == "+") t = 0;
                            else if (str[i] == "-") t = 1;
                            writer.Write(str[i] + " ");
                        }
                    }
                }
                else
                {
                    plusK -= minusK;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (i == 0)
                        {
                            writer.Write((n - plusK) + " ");
                        }
                        else if (str[i] == "?")
                        {
                            writer.Write(1 + " ");
                        }
                        else
                        {
                            writer.Write(str[i] + " ");
                        }
                    }
                }
            }
        }
    }
}
