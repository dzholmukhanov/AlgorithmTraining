using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class QualifyingContest346
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                Player[] p = new Player[n];
                string[] ans = Enumerable.Repeat("", m).ToArray();
                for (int i = 0; i < n; i++)
                {
                    string[] s = fs.ReadLine().Split();
                    p[i] = new Player { Name = s[0], Region = Convert.ToInt32(s[1]) - 1, Score = Convert.ToInt32(s[2]) };
                }
                p = p.OrderBy(x => x.Region).ThenByDescending(x => x.Score).ToArray();
                int j = 0, lastRegion = -1;
                for (int i = 0; i < n; i++)
                {
                    if (p[i].Region != lastRegion)
                    {
                        j = 0;
                        lastRegion = p[i].Region;
                    }
                    if (j == 0) ans[p[i].Region] += p[i].Name + " ";
                    else if (j == 1) ans[p[i].Region] += p[i].Name;
                    else if (j == 2 && p[i].Score == p[i - 1].Score) ans[p[i].Region] = "?";
                    j++;
                }
                for (int i = 0; i < m; i++)
                {
                    writer.WriteLine(ans[i]);
                }
            }
        }
    }
    class Player
    {
        public string Name;
        public int Region, Score;
    }
}
