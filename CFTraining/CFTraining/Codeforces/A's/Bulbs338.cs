using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.A_s
{
    class Bulbs338
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]),
                m = Convert.ToInt32(line[1]);
            bool[] bulbs = new bool[m];
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(line[0]);
                for (int j = 1; j <= x; j++)
                {
                    bulbs[Convert.ToInt32(line[j]) - 1] = true;
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (!bulbs[i])
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
