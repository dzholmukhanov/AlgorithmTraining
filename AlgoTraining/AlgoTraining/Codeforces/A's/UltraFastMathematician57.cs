using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class UltraFastMathematician57
    {
        public static void Run()
        {
            string numA = Console.ReadLine(),
                   numB = Console.ReadLine(),
                   result = "";
            for (int i = 0; i < numA.Length; i++)
                result += numA[i] == numB[i] ? "0" : "1";
            Console.WriteLine(result);
        }
    }
}
