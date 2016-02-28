using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.B_s
{
    class HddIsOutdatedTechnologyECR4
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] line = Console.ReadLine().Split(' ');
            int[] pos = new int[n];
            for (int i = 0; i < n; i++)
            {
                pos[Convert.ToInt32(line[i]) - 1] = i;
            }
            long res = 0;
            for (int i = 1; i < n; i++)
            {
                res += Math.Abs(pos[i] - pos[i - 1]);
            }
            Console.WriteLine(res);
        }
    }
}
