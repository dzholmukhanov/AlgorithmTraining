using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class SonyaAndQueries371
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                Dictionary<string, int> count = new Dictionary<string, int>();
                while (t-- > 0)
                {
                    string[] cmd = fs.ReadLine().Split();
                    if (cmd[0] == "+")
                    {
                        long a = Convert.ToInt64(cmd[1]);
                        string pattern = NumToPattern(a);
                        if (!count.ContainsKey(pattern)) count.Add(pattern, 0);
                        count[pattern]++;
                    }
                    else if (cmd[0] == "-")
                    {
                        long a = Convert.ToInt64(cmd[1]);
                        string pattern = NumToPattern(a);
                        count[pattern]--;
                    }
                    else
                    {
                        string pattern = AppendZeros(cmd[1]);
                        writer.WriteLine(count.ContainsKey(pattern) ? count[pattern] : 0);
                    }
                }
            }
        }
        public static string AppendZeros(string str)
        {
            if (str.Length < 18)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18 - str.Length; i++)
                {
                    sb.Append("0");
                }
                sb.Append(str);
                return sb.ToString();
            }
            else return str;
        }
        public static string NumToPattern(long x)
        {
            StringBuilder sb = new StringBuilder();
            if (x == 0) return AppendZeros("0");
            while (x != 0)
            {
                sb.Append(x % 2);
                x /= 10;
            }
            return AppendZeros(new string(sb.ToString().Reverse().ToArray()));
        }
    }
}
