using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class ReberlandLinguistics349
    {
        private static SortedSet<string> _set = new SortedSet<string>();
        private static string _str;
        private static bool[,] solved;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                _str = fs.ReadLine();
                solved = new bool[2, _str.Length];
                Find(_str.Length - 1, "");
                writer.WriteLine(_set.Count);
                foreach (string suffix in _set)
                {
                    writer.WriteLine(suffix);
                }
            }
        }
        public static void Find(int i, string prev)
        {
            if (i - 1 > 4 && !solved[0, i])
            {
                string suffix = _str.Substring(i - 1, 2);
                if (suffix != prev)
                {
                    _set.Add(suffix);
                    Find(i - 2, suffix);
                    solved[0, i] = true;
                }
            }
            if (i - 2 > 4 && !solved[1, i])
            {
                string suffix = _str.Substring(i - 2, 3);
                if (suffix != prev)
                {
                    _set.Add(suffix);
                    Find(i - 3, suffix);
                    solved[1, i] = true;
                }
            }
        }
    }
}