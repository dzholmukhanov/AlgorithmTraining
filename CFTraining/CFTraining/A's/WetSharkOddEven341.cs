using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class WetSharkOddEven341
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            int min = int.MaxValue, oddCount = 0;
            long sum = 0;
            while (n-- > 0)
            {
                int t = sc.NextInt();
                if (t % 2 == 1)
                {
                    oddCount++;
                    min = Math.Min(min, t);
                }
                sum += t;
            }
            if (oddCount % 2 == 1) sum -= min;
            Console.WriteLine(sum);
        }
    }
}
