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
        private static SortedSet<string> _set = new SortedSet<string>();
        private static HashSet<string> _tempSet = new HashSet<string>();
        private static string _str;
        private static bool[] solved;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                _str = fs.ReadLine();
                solved = new bool[_str.Length];
                Find(_str.Length - 1);
                writer.WriteLine(_set.Count);
                foreach (string suffix in _set)
                {
                    writer.WriteLine(suffix);
                }
            }
        }
        public static void Find(int i)
        {
            if (solved[i]) return;
            if (i - 1 > 4)
            {
                string suffix = _str.Substring(i - 1, 2);
                if (!_tempSet.Contains(suffix))
                {
                    _tempSet.Add(suffix);
                    _set.Add(suffix);
                    Find(i - 2);
                    _tempSet.Remove(suffix);
                }
            }
            if (i - 2 > 4)
            {
                string suffix = _str.Substring(i - 2, 3);
                if (!_tempSet.Contains(suffix))
                {
                    _tempSet.Add(suffix);
                    _set.Add(suffix);
                    Find(i - 3);
                    _tempSet.Remove(suffix);
                }
            }
            solved[i] = true;
        }
    }
}
