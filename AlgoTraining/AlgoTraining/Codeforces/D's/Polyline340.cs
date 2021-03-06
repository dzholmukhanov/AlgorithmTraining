﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.D_s
{
    class Polyline340
    {
        public static void Run()
        {
            Console.WriteLine(Solve());
        }

        public static int Solve()
        {
            List<Point> p = new List<Point>();
            for (int i = 0; i < 3; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                p.Add(new Point { x = Convert.ToInt32(line[0]), y = Convert.ToInt32(line[1]) });
            }

            if (p[0].LieInSameLine(p[1]) != 0 && p[0].LieInSameLine(p[1]) == p[0].LieInSameLine(p[2])) return 1;
            int s1 = p[0].LieInSameLine(p[1]), s2 = p[0].LieInSameLine(p[2]), s3 = p[1].LieInSameLine(p[2]);
            if (s1 > 0)
            {
                if (s1 == 1)
                {
                    int min = Math.Min(p[0].y, p[1].y);
                    int max = Math.Max(p[0].y, p[1].y);
                    if (p[2].y <= min || p[2].y >= max)
                    {
                        return 2;
                    }
                }
                if (s1 == 2)
                {
                    int min = Math.Min(p[0].x, p[1].x);
                    int max = Math.Max(p[0].x, p[1].x);
                    if (p[2].x <= min || p[2].x >= max)
                    {
                        return 2;
                    }
                }
            }
            else if (s2 > 0)
            {
                if (s2 == 1)
                {
                    int min = Math.Min(p[0].y, p[2].y);
                    int max = Math.Max(p[0].y, p[2].y);
                    if (p[1].y <= min || p[1].y >= max)
                    {
                        return 2;
                    }
                }
                if (s2 == 2)
                {
                    int min = Math.Min(p[0].x, p[2].x);
                    int max = Math.Max(p[0].x, p[2].x);
                    if (p[1].x <= min || p[1].x >= max)
                    {
                        return 2;
                    }
                }
            }
            else if (s3 > 0)
            {
                if (s3 == 1)
                {
                    int min = Math.Min(p[1].y, p[2].y);
                    int max = Math.Max(p[1].y, p[2].y);
                    if (p[0].y <= min || p[0].y >= max)
                    {
                        return 2;
                    }
                }
                if (s3 == 2)
                {
                    int min = Math.Min(p[1].x, p[2].x);
                    int max = Math.Max(p[1].x, p[2].x);
                    if (p[0].x <= min || p[0].x >= max)
                    {
                        return 2;
                    }
                }
            }
            return 3;
        }
    }

    class Point
    {
        public int x, y;
        public int LieInSameLine(Point p)
        {
            if (x == p.x) return 1;
            else if (y == p.y) return 2;
            else return 0;
        }
    }
}
