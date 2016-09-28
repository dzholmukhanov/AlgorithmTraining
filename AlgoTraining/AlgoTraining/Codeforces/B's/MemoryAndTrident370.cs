using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class MemoryAndTrident370
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string s = fs.ReadLine();
                int lc = 0, rc = 0, uc = 0, dc = 0;
                lc = s.Where(x => x == 'L').Count();
                rc = s.Where(x => x == 'R').Count();
                uc = s.Where(x => x == 'U').Count();
                dc = s.Where(x => x == 'D').Count();
                if (s.Length % 2 == 1)
                {
                    writer.WriteLine(-1);
                    return;
                }
                int ans = 0;
                if ((lc + rc) % 2 == 1)
                {
                    if (lc > rc) lc--;
                    else rc--;
                    if (uc > dc) dc++;
                    else uc++;
                    ans++;
                }
                if (lc > rc)
                {
                    ans += (lc - rc) / 2;
                }
                else if (lc < rc)
                {
                    ans += (rc - lc) / 2;
                }
                if (uc > dc)
                {
                    ans += (uc - dc) / 2;
                }
                else if (uc < dc)
                {
                    ans += (dc - uc) / 2;
                }
                writer.WriteLine(ans);
            }
        }
    }
}
