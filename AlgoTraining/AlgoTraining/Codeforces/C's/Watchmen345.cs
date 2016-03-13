using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class Watchmen345
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                Watchmen[] a = new Watchmen[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = new Watchmen { x = fs.NextInt(), y = fs.NextInt() };
                }
                a = a.OrderBy(w => w.x).ThenBy(w => w.y).ToArray();
                Watchmen[] b = a.OrderBy(w => w.y).ToArray();
                long ans = 0, sameX = 0, sameY = 0, dupNum = 0;
                for (int i = 1; i < n; i++)
                {
                    if (a[i].x == a[i - 1].x) sameX++;
                    else if (sameX != 0)
                    {
                        ans += (sameX * (sameX + 1)) / 2;
                        sameX = 0;
                    }

                    if (b[i].y == b[i - 1].y) sameY++;
                    else if (sameY != 0)
                    {
                        ans += (sameY * (sameY + 1)) / 2;
                        sameY = 0;
                    }

                    if (a[i].x == a[i - 1].x && a[i].y == a[i - 1].y) dupNum++;
                    else if (dupNum != 0)
                    {
                        ans -= (dupNum * (dupNum + 1)) / 2;
                        dupNum = 0;
                    }
                }
                if (sameX != 0)
                {
                    ans += (sameX * (sameX + 1)) / 2;
                    sameX = 0;
                }
                if (sameY != 0)
                {
                    ans += (sameY * (sameY + 1)) / 2;
                    sameY = 0;
                }
                if (dupNum != 0)
                {
                    ans -= (dupNum * (dupNum + 1)) / 2;
                    dupNum = 0;
                }
                writer.WriteLine(ans);
            }
        }
    }
    class Watchmen
    {
        public int x, y;
    }
}
