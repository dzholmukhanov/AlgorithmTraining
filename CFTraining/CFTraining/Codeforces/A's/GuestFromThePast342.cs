using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class GuestFromThePast342
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            long n = sc.NextLong(), a = sc.NextLong(), b = sc.NextLong(), c = sc.NextLong(), liters = 0;
            if (b - c < a && n >= b)
            {
                long i = (n - b) / (b - c) + 1;
                liters += i;
                n -= i * (b - c);
            }
            liters += n / a;
            Console.WriteLine(liters);
        }
    }
}
