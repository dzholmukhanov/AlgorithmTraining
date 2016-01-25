using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.A_s
{
    class Elephant340
    {
        public static void Run()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(x / 5 + (x % 5 > 0 ? 1 : 0));
        }
    }
}
