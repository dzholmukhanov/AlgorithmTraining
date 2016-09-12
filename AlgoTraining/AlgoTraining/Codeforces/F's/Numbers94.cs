using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.F_s
{
    class Numbers94
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int totalCount = fs.NextInt();
                List<int> a = new List<int>(totalCount);
                Dictionary<int, int> count = new Dictionary<int, int>();
                if (totalCount % 2 == 1)
                {
                    writer.WriteLine("NO");
                    return;
                }
                for (int i = 0; i < totalCount; i++)
			    {
                    int x = fs.NextInt();
                    if (!count.ContainsKey(x))
                    {
                        count.Add(x, 1);
                        a.Add(x);
                    }
                    else count[x]++;
			    }
                int n = a.Count;
                a = a.OrderByDescending(x => x).ToList();
                int temp = count[a[0]];
                totalCount -= temp;
                for (int i = 1; i < n; i++)
                {
                    if (a[i - 1] - a[i] > 1 || count[a[i]] < temp)
                    {
                        writer.WriteLine("NO");
                        break;
                    }
                    if (count[a[i]] == temp)
                    {
                        temp = 0;
                        writer.WriteLine(totalCount - count[a[i]] == 0 ? "YES" : "NO");
                        break;
                    }
                    else if (count[a[i]] > temp)
                    {
                        if (i == n - 1)
                        {
                            writer.WriteLine("NO");
                        }
                        else
                        {
                            temp = count[a[i]] - temp;
                            totalCount -= count[a[i]];
                        }
                    }
                }
            }
        }
    }
}
