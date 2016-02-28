using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.D_s
{
    class TheUnionOfKSegmentsECR4
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]), k = Convert.ToInt32(line[1]);
            Endpoint[] points = new Endpoint[n * 2];
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                int l = Convert.ToInt32(line[0]), r = Convert.ToInt32(line[1]) + 1; // r exclusively
                Endpoint beg = new Endpoint { IsFirst = true, X = l };
                Endpoint end = new Endpoint { IsFirst = false, X = r };
                points[t++] = beg;
                points[t++] = end;
            }
            points = points.OrderBy(p => p.X).ThenBy(p => p.IsFirst).ToArray();
            int cross = 0, m = 0;
            StringBuilder outputStr = new StringBuilder();
            foreach (Endpoint p in points)
            {
                if (p.IsFirst)
                {
                    cross++;
                    if (cross == k)
                    {
                        outputStr.Append(p.X + " ");
                    }
                }
                else
                {
                    cross--;
                    if (cross == k - 1)
                    {
                        outputStr.Append((p.X - 1) + "\n");
                        m++;
                    }
                }
            }
            Console.WriteLine(m);
            Console.Write(outputStr.ToString());
        }
    }
    class Endpoint
    {
        public int X { get; set; }
        public bool IsFirst { get; set; }
    }
}
