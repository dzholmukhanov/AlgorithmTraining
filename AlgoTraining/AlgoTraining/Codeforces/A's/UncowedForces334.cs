using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class UncowedForces334
    {
        public static void Run()
        {
            int[] x = new int[] { 500, 1000, 1500, 2000, 2500 };
            string[] mStr = Console.ReadLine().Split(' '),
                     wStr = Console.ReadLine().Split(' '),
                     hStr = Console.ReadLine().Split(' ');
            decimal totalScore = 0;
            for (int i = 0; i < 5; i++)
            {
                int m = Convert.ToInt16(mStr[i]),
                    w = Convert.ToInt16(wStr[i]);
                totalScore += Math.Max(0.3m * x[i], (1 - m / 250m) * x[i] - 50 * w);
            }
            totalScore += 100 * Convert.ToInt16(hStr[0]);
            totalScore -= 50 * Convert.ToInt16(hStr[1]);
            Console.WriteLine((int)totalScore);
        }
    }
}
