using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class FilyaAndHomework371
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < n; i++)
                {
                    int x = fs.NextInt();
                    set.Add(x);
                }
                if (set.Count < 3)
                {
                    writer.WriteLine("YES");
                }
                else if (set.Count > 3)
                {
                    writer.WriteLine("NO");
                }
                else
                {
                    int[] a = set.ToArray();
                    Array.Sort(a);
                    writer.WriteLine(a[1] - a[0] == a[2] - a[1] ? "YES" : "NO");
                }
            }
        }
    }
}
