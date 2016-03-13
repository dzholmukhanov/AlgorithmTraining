using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
            {
                if (x[i] > y[i]) return 1;
                else if (x[i] < y[i]) return -1;
            }
            return x.Length == y.Length ? 0 : Compare(x + y, y + x);
        }
    }
    class SmallestStringConcatenationECR9
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                string[] a = new string[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.ReadLine();
                }
                Array.Sort(a, new StringComparer());
                StringBuilder sb = new StringBuilder();
                foreach (string str in a)
                {
                    sb.Append(str);
                }
                writer.WriteLine(sb);
            }
        }
    }
}