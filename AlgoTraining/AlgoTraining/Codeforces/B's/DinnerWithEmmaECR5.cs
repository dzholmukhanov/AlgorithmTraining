using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.B_s
{
    class DinnerWithEmmaECR5
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]), m = Convert.ToInt32(line[1]);
            int[] rowMins = new int[n];
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                int min = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    int t = Convert.ToInt32(line[j]);
                    if (t < min) min = t;
                }
                rowMins[i] = min;
            }
            Console.WriteLine(rowMins.Max());
        }
    }
}
