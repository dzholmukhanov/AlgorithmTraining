using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class Queue205
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string str = fs.ReadLine();
                List<int> list = new List<int>(str.Length);
                int first = -1;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == 'F')
                    {
                        if (first == -1 && list.Count != i)
                        {
                            first = list.Count;
                        }
                        list.Add(i);
                    }
                }
                if (list.Count == 0 || list.Count == str.Length || first == -1)
                {
                    writer.WriteLine(0);
                    return;
                }
                int t = 0;
                for (int i = first + 1; i < list.Count; i++)
                {
                    t = Math.Max(0, t - list[i] + list[i - 1] + 2);
                }
                writer.WriteLine(t + list.Last() - list.Count + 1);
            }
        }
    }
}
