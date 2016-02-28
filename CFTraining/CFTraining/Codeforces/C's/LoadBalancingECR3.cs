using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class LoadBalancingECR3
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] m = new int[n];
            string[] line = Console.ReadLine().Split(' ');
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                m[i] = Convert.ToInt32(line[i]);
                sum += m[i];
            }
            int avg = sum / n, lack = 0, excess = 0, excessCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < avg) lack += avg - m[i];
                else if (m[i] > avg) {
                    excess += m[i] - avg;
                    excessCount++;
                }
            }
            excess -= lack;
            Console.WriteLine(lack + (excess <= excessCount ? 0 : excess - excessCount));
        }
    }

}
