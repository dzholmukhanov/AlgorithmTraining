using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.B_s
{
    class Chocolate340
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] line = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(line[i]);
            }
            bool firstMet = false;
            int zeroCount = 0;
            long res = 1;
            for (int i = 0; i < n; i++)
            {
                if (!firstMet && a[i] == 1) firstMet = true;
                else if (firstMet)
                {
                    if (a[i] == 0)
                    {
                        zeroCount++;
                    }
                    else
                    {
                        res *= zeroCount + 1;
                        zeroCount = 0;
                    }
                }
            }
            Console.WriteLine(firstMet ? res : 0);
        }
    }
}
