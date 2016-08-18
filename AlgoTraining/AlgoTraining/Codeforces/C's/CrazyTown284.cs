using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class CrazyTown284
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long x1 = fs.NextInt(), y1 = fs.NextInt();
                long x2 = fs.NextInt(), y2 = fs.NextInt();
                int n = fs.NextInt();
                Line original = new Line 
                { 
                    A = y1 - y2, 
                    B = x2 - x1, 
                    C = x1 * y2 - x2 * y1 
                };
                long minX = Math.Min(x1, x2), maxX = Math.Max(x1, x2);
                long minY = Math.Min(y1, y2), maxY = Math.Max(y1, y2);
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    Line line = new Line { A = fs.NextInt(), B = fs.NextInt(), C = fs.NextInt() };
                    double[] cross = GetIntersection(original, line);
                    if (cross[0] >= minX && cross[0] <= maxX &&
                        cross[1] >= minY && cross[1] <= maxY) count++;
                }
                writer.WriteLine(count);
            }
        }
        public static bool Intersect(Line l1, Line l2)
        {
            return l1.B * l2.A != l1.A * l2.B;
        }
        public static double[] GetIntersection(Line l1, Line l2)
        {
            if (Intersect(l1, l2))
            {
                double[] res = new double[] 
                { 
                    (l1.C * l2.B - l1.B * l2.C) * 1.0 / (l1.B * l2.A - l1.A * l2.B),
                    (l2.A * l1.C - l1.A * l2.C) * 1.0 / (l2.B * l1.A - l2.A * l1.B)
                };
                return res;
            }
            else return new double[] { double.MinValue, double.MinValue };
        }
        public class Line
        {
            public long A, B, C;
        }
    }
}
