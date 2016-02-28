using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.AimTech
{
    class ProblemA
    {
        public static void Run()
        {
            ConsoleScanner cs = new ConsoleScanner();
            double d = cs.NextInt(), L = cs.NextInt(), v1 = cs.NextInt(), v2 = cs.NextInt();
            Console.WriteLine(((L - d) / (v1 + v2)).ToString().Replace(",", "."));
        }
    }
}
