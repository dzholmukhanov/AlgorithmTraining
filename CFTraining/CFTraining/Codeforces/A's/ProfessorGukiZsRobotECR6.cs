using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.A_s
{
    class ProfessorGukiZsRobotECR6
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split();
            int x1 = Convert.ToInt32(line[0]), y1 = Convert.ToInt32(line[1]);
            line = Console.ReadLine().Split();
            int x2 = Convert.ToInt32(line[0]), y2 = Convert.ToInt32(line[1]);
            Console.WriteLine(Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2)));
        }
    }
}
