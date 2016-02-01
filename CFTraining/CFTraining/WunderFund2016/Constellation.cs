using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.WunderFund2016
{
    class Constellation
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            List<Point> points = new List<Point>();
            Point f = new Point { x = sc.NextInt(), y = sc.NextInt(), i = 1 };
            for (int i = 1; i < n; i++)
            {
                Point p = new Point { x = sc.NextInt(), y = sc.NextInt(), i = i + 1 };
                p.dist = p.DistanceSqr(f);
                points.Add(p);
            }
            points = points.OrderBy(p => p.dist).ToList();
            Point s = points.First();
            points.RemoveAt(0);
            foreach (Point t in points)
            {
                if (!Collinear(f.x, f.y, s.x, s.y, t.x, t.y))
                {
                    Console.WriteLine(f.i + " " + s.i + " " + t.i);
                    return;
                }
            }
        }

        public static bool Collinear(long x1, long y1, long x2, long y2, long x3, long y3)
        {
            return (y1 - y2) * (x1 - x3) == (y1 - y3) * (x1 - x2);
        }
    }
    class Point
    {
        public long i, x, y;
        public long dist;
        public long DistanceSqr(Point a)
        {
            return (x - a.x) * (x - a.x) + (y - a.y) * (y - a.y);
        }
    }
}
