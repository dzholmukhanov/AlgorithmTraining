using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class VanyaAndLabel355
    {
        private static Dictionary<char, int> map;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                map = new Dictionary<char, int>();
                int val = 0;
                for (char c = '0'; c <= '9'; c++) map.Add(c, val++);
                for (char c = 'A'; c <= 'Z'; c++) map.Add(c, val++);
                for (char c = 'a'; c <= 'z'; c++) map.Add(c, val++);
                map.Add('-', val++);
                map.Add('_', val++);

                string s = fs.ReadLine();
                long ans = 1;
                foreach (char c in s)
                {
                    string bin = Convert.ToString(map[c], 2);
                    for (int i = bin.Length + 1; i <= 6; i++)
                    {
                        ans = (ans * 3) % 1000000007;
                    }
                    foreach (char b in bin)
                    {
                        if (b == '0') ans = (ans * 3) % 1000000007;
                    }
                }
                writer.WriteLine(ans);
            }
        }
    } 
}