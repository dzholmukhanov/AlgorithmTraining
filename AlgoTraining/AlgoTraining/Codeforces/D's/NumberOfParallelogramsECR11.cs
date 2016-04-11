using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class NumberOfParallelogramsECR11
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                Point[] points = new Point[n];
                for (int i = 0; i < n; i++)
                {
                    points[i] = new Point { X = fs.NextInt(), Y = fs.NextInt() };
                }
                long c = 0;
                if (n > 1)
                {
                    List<Point> cross = new List<Point>();
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = i + 1; j < n; j++)
                        {
                            cross.Add(new Point { X = points[j].X + points[i].X, Y = points[j].Y + points[i].Y });
                        }
                    }
                    cross = cross.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
                    long count = 0;
                    for (int i = 1; i < cross.Count; i++)
                    {
                        if (cross[i].Equals(cross[i - 1])) count++;
                        else
                        {
                            c += count * (count + 1);
                            count = 0;
                        }
                    }
                }
                writer.WriteLine(c / 2);
            }
        }
    }
    class Point
    {
        public int X;
        public int Y;

        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            return this.X == p.X && this.Y == p.Y;
        }
    }
}
