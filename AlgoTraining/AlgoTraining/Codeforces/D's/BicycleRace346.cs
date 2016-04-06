using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class BicycleRace346
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                fs.NextInt();
                fs.NextInt();
                int x0 = fs.NextInt(), y0 = fs.NextInt(), ans = 0;
                char dir = 'N';
                for (int i = 0; i < n - 1; i++)
                {
                    int x = fs.NextInt(), y = fs.NextInt();
                    if (x < x0)
                    {
                        if (dir == 'N') ans++;
                        dir = 'W';
                    }
                    else if (x > x0)
                    {
                        if (dir == 'S') ans++;
                        dir = 'E';
                    }
                    else if (y < y0)
                    {
                        if (dir == 'W') ans++;
                        dir = 'S';
                    }
                    else if (y > y0)
                    {
                        if (dir == 'E') ans++;
                        dir = 'N';
                    }
                    x0 = x;
                    y0 = y;
                }
                writer.WriteLine(ans);
            }
        }
    }
}
