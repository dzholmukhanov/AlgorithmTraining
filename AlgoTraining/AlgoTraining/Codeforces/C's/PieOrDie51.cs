using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class PieOrDie51
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), k = fs.NextInt();
                bool res = false;
                while (k-- > 0)
                {
                    int x = fs.NextInt(), y = fs.NextInt();
                    if (n <= 6 || m <= 6 || x >= 1 && x <= 3 || x >= n - 2 && x <= n || y >= 1 && y <= 3 || y >= m - 2 && y <= m) res = true;
                }
                writer.WriteLine(res ? "YES" : "NO");
            }
        }
    }
}
