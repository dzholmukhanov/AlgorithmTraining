using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CFTraining.A_s
{
    class LinkCutTree339
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            BigInteger l = BigInteger.Parse(line[0]), r = BigInteger.Parse(line[1]), k = BigInteger.Parse(line[2]), t = 1;
            StringBuilder sb = new StringBuilder();
            if (l == 1) sb.Append(1 + " ");
            while (t > 0 && t <= r) {
                t *= k;
                if (t >= l && t <= r) sb.Append(t + " ");
            }
            Console.WriteLine(sb.Length == 0 ? "-1" : sb.ToString());
        }
    }
}
