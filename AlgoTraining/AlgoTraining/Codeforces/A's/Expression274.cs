using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class Expression274
    {
        public static void Run()
        {
            int a = Convert.ToInt32(Console.ReadLine()), 
                b = Convert.ToInt32(Console.ReadLine()),
                c = Convert.ToInt32(Console.ReadLine()),
                numOfOnes = (a == 1) ? 1 : 0;

            if (b == 1) numOfOnes++;
            if (c == 1) numOfOnes++;

            if (numOfOnes == 3) Console.WriteLine(3);
            else if (numOfOnes == 2)
            {
                if (a != 1) Console.WriteLine(a * (b + c));
                else if (b != 1) Console.WriteLine(a + b + c);
                else if (c != 1) Console.WriteLine((a + b) * c);
            }
            else if (numOfOnes == 1)
            {
                if (a == 1) Console.WriteLine((a + b) * c);
                else if (b == 1) Console.WriteLine(Math.Max((a + b) * c, a * (b + c)));
                else if (c == 1) Console.WriteLine(a * (b + c));
            }
            else Console.WriteLine(a * b * c);
        }
        public static void Test()
        {
            /*
             a + b + c      - 1
             a * b + c      - 2
             a * (b + c)    - 3
             a + b * c      - 4
             (a + b) * c    - 5
             a * b * c      - 6
            */
            int[] sums = new int[] { 0, 0, 0, 0, 0, 0 };
            for (int a = 2; a < 100; a++)
            {
                for (int b = 2; b < 100; b++)
                {
                    for (int c = 2; c < 100; c++)
                    {
                        int[] results = new int[] {
                            a + b + c, a * b + c, a * (b + c), a + b * c, (a + b) * c, a * b * c
                        };
                        int max = results[0], ind = 0;
                        for (int i = 1; i < results.Length; i++)
                        {
                            if (max <= results[i])
                            {
                                max = results[i];
                                ind = i;
                            }
                        }
                        sums[ind]++;
                    }
                }
            }
            Console.WriteLine(String.Join(", ", sums));
        }
    }
}
