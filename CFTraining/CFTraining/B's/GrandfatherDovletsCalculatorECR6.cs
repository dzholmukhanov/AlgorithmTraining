using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.B_s
{
    class GrandfatherDovletsCalculatorECR6
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split();
            int a = Convert.ToInt32(line[0]), b = Convert.ToInt32(line[1]), sum = 0;
            int[] segments = new int[] { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6};
            for (int i = a; i <= b; i++)
            {
                int temp = i;
                while (temp != 0)
                {
                    sum += segments[temp % 10];
                    temp /= 10;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
