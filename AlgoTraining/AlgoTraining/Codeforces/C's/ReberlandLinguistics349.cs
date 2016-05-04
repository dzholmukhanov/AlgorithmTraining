using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    // Not solved yet
    class ReberlandLinguistics349
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string s = fs.ReadLine();
                SortedSet<string> set = new SortedSet<string>();
                if (s.Length > 6)
                {
                    for (int i = 6; i < s.Length; i++)
                    {
                        if (i == s.Length - 2) continue;
                        string temp = s.Substring(i - 1, 2);
                        if (!set.Contains(temp)) set.Add(temp);
                        if (i - 2 > 4)
                        {
                            temp = s.Substring(i - 2, 3);
                            if (!set.Contains(temp)) set.Add(temp);
                        }
                    }
                    writer.WriteLine(set.Count);
                    foreach (string suffix in set) 
                    {
                        writer.WriteLine(suffix);
                    }
                }
                else
                {
                    writer.WriteLine(0);
                }
            }
        }
    }
}
