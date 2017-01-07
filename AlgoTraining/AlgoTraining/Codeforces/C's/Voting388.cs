using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class Voting388
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                string str = fs.ReadLine();
                bool[] isDenied = new bool[n];
                int d = 0, r = 0;
                int dcount = str.Count(x => x == 'D');
                int rcount = str.Count(x => x == 'R');
                int i;
                for (i = 0; true; i = (i + 1) % n)
                {
                    if (isDenied[i]) continue;
                    if (str[i] == 'D')
                    {
                        if (rcount == 0) break;
                        while (str[r] != 'R' || isDenied[r]) r = (r + 1) % n;
                        isDenied[r] = true;
                        rcount--;
                        r = (r + 1) % n;
                        d = (i + 1) % n;
                    }
                    else
                    {
                        if (dcount == 0) break;
                        while (str[d] != 'D' || isDenied[d]) d = (d + 1) % n;
                        isDenied[d] = true;
                        dcount--;
                        d = (d + 1) % n;
                        r = (i + 1) % n;
                    }
                }
                writer.WriteLine(str[i]);
            }
        }
    }
}
