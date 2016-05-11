using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class Diversity352
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                bool[] met = new bool[26];
                int n = fs.NextInt();
                string str = fs.ReadLine();
                int dup = 0, unused = 0;
                foreach (char c in str)
                {
                    if (met[c - 'a']) dup++;
                    else met[c - 'a'] = true;
                }
                foreach (bool b in met)
                {
                    if (!b) unused++;
                }
                writer.WriteLine(dup > unused ? -1 : dup);
            }
        }
    }
}
