using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.GoodBye2015
{
    class DaysA
    {
        public static void Run()
        {
            int[] weekDays = new int[7];
            int p = 4;
            for (int i = 0; i < 366; i++)
            {
                weekDays[p]++;
                p = (p + 1) % 7;
            }
            string[] line = Console.ReadLine().Split(' ');
            int num = Convert.ToInt32(line[0]);
            if (line[2] == "week")
            {
                Console.WriteLine(weekDays[num - 1]);
            }
            else
            {
                if (num <= 29) Console.WriteLine(12);
                else if (num < 31) Console.WriteLine(11);
                else Console.WriteLine(7);
            }
        }
    }
}
