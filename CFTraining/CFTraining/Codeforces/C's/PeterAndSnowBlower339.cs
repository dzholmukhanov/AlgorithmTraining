using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.C_s
{
    class PeterAndSnowBlower339
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]), x0 = Convert.ToInt32(line[1]), y0 = Convert.ToInt32(line[2]), px = int.MinValue, py = int.MinValue, fx = int.MinValue, fy = int.MinValue;
            double minDist = double.MaxValue, maxDist = double.MinValue, segmentDist;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(line[0]), y = Convert.ToInt32(line[1]);
                if (px != int.MinValue)
                {
                    segmentDist = pDistance(x0, y0, px, py, x, y);
                    if (segmentDist < minDist)
                    {
                        minDist = segmentDist;
                    }
                }
                else
                {
                    fx = x;
                    fy = y;
                }
                long pointDist = ((long)x0 - x) * ((long)x0 - x) + ((long)y0 - y) * ((long)y0 - y);
                if (pointDist > maxDist)
                {
                    maxDist = pointDist;
                }
                px = x;
                py = y;
            }
            segmentDist = pDistance(x0, y0, px, py, fx, fy);
            if (segmentDist < minDist)
            {
                minDist = segmentDist;
            }
            double ans = Math.PI * maxDist - Math.PI * minDist * minDist;
            Console.WriteLine(ans.ToString().Replace(',','.'));
        }

        public static double pDistance(int x, int y, int x1, int y1, int x2, int y2) 
        {
            double A = x - x1;
            double B = y - y1;
            double C = x2 - x1;
            double D = y2 - y1;

            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = -1;
            if (len_sq != 0) //in case of 0 length line
                param = dot / len_sq;

            double xx, yy;
            if (param < 0) {
                xx = x1;
                yy = y1;
            }
            else if (param > 1) {
                xx = x2;
                yy = y2;
            }
            else {
                xx = x1 + param * C;
                yy = y1 + param * D;
            }

            double dx = x - xx;
            double dy = y - yy;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
