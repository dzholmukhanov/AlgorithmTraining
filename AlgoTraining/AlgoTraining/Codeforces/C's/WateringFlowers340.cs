using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.C_s
{
    class WateringFlowers340
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]), x1 = Convert.ToInt32(line[1]), y1 = Convert.ToInt32(line[2]),
                x2 = Convert.ToInt32(line[3]), y2 = Convert.ToInt32(line[4]);
            LinkedList<Flower> first = new LinkedList<Flower>();
            LinkedList<Flower> second = new LinkedList<Flower>();
            
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(line[0]), y = Convert.ToInt32(line[1]);
                first.AddLast(new Flower { x = x, y = y, dist = (long)(x - x1) * (long)(x - x1) + (long)(y - y1) * (long)(y - y1) });
            }
            long res = long.MaxValue;
            for (int i = 0; i <= n; i++)
            {
                Flower firstmax = first.Count > 0 ? first.Aggregate((c, d) => c.dist > d.dist ? c : d) : null;
                Flower secondmax = second.Count > 0 ? second.Aggregate((c, d) => c.dist > d.dist ? c : d) : null;
                long d1 = 0, d2 = 0;
                if (firstmax != null) d1 = firstmax.dist;
                if (secondmax != null) d2 = secondmax.dist;
                res = Math.Min(res, d1 + d2);
                if (firstmax != null)
                {
                    first.Remove(firstmax);
                    firstmax.dist = (long)(firstmax.x - x2) * (long)(firstmax.x - x2) + (long)(firstmax.y - y2) * (long)(firstmax.y - y2);
                    second.AddLast(firstmax);
                }
            }
            Console.WriteLine(res);
        }
    }
    class Flower
    {
        public int x, y;
        public long dist;
    }
}
