using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class LittleArtemAndDance348
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), q = fs.NextInt();
                int totalOffset = 0, offset = 0, disp = 0, pos0 = 0;
                for (int i = 0; i < q; i++)
                {
                    int t = fs.NextInt();
                    if (t == 1)
                    {
                        int dx = fs.NextInt();
                        offset = (offset + dx) % n;
                    }
                    else
                    {
                        totalOffset = (totalOffset + offset) % n;
                        pos0 = Shift(pos0, offset, n);
                        int dx = pos0 % 2 == 0 ? 1 : -1;
                        disp = (disp + dx) % n;
                        pos0 = Shift(pos0, dx, n);
                        offset = 0;
                    }
                }
                if (offset != 0) totalOffset = (totalOffset + offset) % n;
                int[] res = new int[n];
                int coef = 1;
                for (int i = 0; i < n; i++)
                {
                    int ind = Shift(i, disp * coef, n);
                    ind = Shift(ind, totalOffset, n);
                    res[ind] = i + 1;
                    coef *= -1;
                }
                for (int i = 0; i < n; i++)
                {
                    writer.Write(res[i] + " ");
                }
            }
        }
        private static int Shift(int x, int dx, int n)
        {
            int res = (x + dx) % n;
            if (res < 0) res = n + res;
            return res;
        }
    }
}