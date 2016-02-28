using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class TableDecorations273
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            long r = Convert.ToInt32(line[0]),
                g = Convert.ToInt32(line[1]),
                b = Convert.ToInt32(line[2]);
            SortedList<long, long> list = new SortedList<long, long>();
            list.Add(r, r);
            list.Add(g, g);
            list.Add(b, b);
            long t = list[2] / 2;
            long result = 0;
            if (list[0] + list[1] <= t)
            {
                result = (list[0] + list[1]) * 2;
            }
            else
            {
                result = t * 2;
                long last = list[2] - t * 2;
                if (list[0] - t >= 0) {
                    list[0] -= t; // 0 - n
                    list[2] = last; // 0 - 1
                    
                }
                else {
                    t -= list[0];
                    list[0] = 0;
                    list[1] -= t;
                    list[2] = last;
                    if (last == 1) result++;
                }
            }
        }
    }
}
