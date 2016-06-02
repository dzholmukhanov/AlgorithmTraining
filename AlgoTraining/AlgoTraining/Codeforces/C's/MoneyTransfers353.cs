using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class MoneyTransfers353
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                Dictionary<long, int> count = new Dictionary<long, int>();
                int n = fs.NextInt();
                int ans = n - 1;
                long sum = 0;
                for (int i = 0; i < n; i++)
                {
                    int a = fs.NextInt();
                    sum += a;
                    if (!count.ContainsKey(sum)) count.Add(sum, 0);
                    count[sum]++;
                    ans = Math.Min(ans, n - count[sum]);
                }
                writer.WriteLine(ans);
            }
        }
    }
}
