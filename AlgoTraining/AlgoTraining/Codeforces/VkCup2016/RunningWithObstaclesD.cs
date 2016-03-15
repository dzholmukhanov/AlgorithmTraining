using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class RunningWithObstaclesD
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), s = fs.NextInt(), d = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                Array.Sort(a);
                List<Obstacle> obstacles = new List<Obstacle>(n);
                if (d == 1 || a[0] <= s)
                {
                    writer.WriteLine("IMPOSSIBLE");
                    return;
                }
                obstacles.Add(new Obstacle { X = a[0], Width = 1 });
                for (int i = 1; i < n; i++)
                {
                    if (a[i] - a[i - 1] >= s + 2) obstacles.Add(new Obstacle { X = a[i], Width = 1 });
                    else
                    {
                        obstacles.Last().Width += a[i] - a[i - 1];
                        if (d <= obstacles.Last().Width)
                        {
                            writer.WriteLine("IMPOSSIBLE");
                            return;
                        }
                    }
                }
                int pos = 0;
                foreach (Obstacle obs in obstacles)
                {
                    writer.WriteLine("RUN " + (obs.X - pos - 1));
                    writer.WriteLine("JUMP " + (obs.Width + 1));
                    pos = obs.X + obs.Width;
                }
                if (pos < m) writer.WriteLine("RUN " + (m - pos));
            }
        }
    }
    class Obstacle
    {
        public int X, Width;
    }
}
