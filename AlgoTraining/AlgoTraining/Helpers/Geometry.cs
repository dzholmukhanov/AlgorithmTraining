using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Helpers
{
    public class Geometry
    {
        public static bool DoLinesIntersect(Line l1, Line l2)
        {
            return l1.B * l2.A != l1.A * l2.B;
        }
        public static bool DoesLineIntersectSegment(Line line, long x1, long y1, long x2, long y2)
        {
            Line line2 = GetLineFromSegment(x1, y1, x2, y2);
            if (DoLinesIntersect(line, line2))
            {
                double[] cross = GetIntersection(line, line2);
                long minX = Math.Min(x1, x2), maxX = Math.Max(x1, x2);
                long minY = Math.Min(y1, y2), maxY = Math.Max(y1, y2);
                if (cross[0] >= minX && cross[0] <= maxX &&
                    cross[1] >= minY && cross[1] <= maxY) return true;
            }
            return false;
        }
        public static double[] GetIntersection(Line l1, Line l2)
        {
            if (DoLinesIntersect(l1, l2))
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
        public static Line GetLineFromSegment(long x1, long y1, long x2, long y2)
        {
            return new Line
            {
                A = y1 - y2,
                B = x2 - x1,
                C = x1 * y2 - x2 * y1
            };
        }
        public class Line
        {
            public long A, B, C;
        }
    }
}
