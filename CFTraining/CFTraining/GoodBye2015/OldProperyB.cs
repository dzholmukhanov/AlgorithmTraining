using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.GoodBye2015
{
    class OldProperyB
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            ulong a = ulong.Parse(line[0]), b = ulong.Parse(line[1]) + 1;
            int remA = NumOfRemaining(Convert.ToString((long)a, 2)), remB = NumOfRemaining(Convert.ToString((long)b, 2));
            Console.WriteLine(remA - remB);
        }
        public static int NumOfRemaining(string str)
        {
            int i;
            for (i = 0; i < str.Length; i++) if (str[i] == '0') break;
            string remaining = "";
            if (i < str.Length) remaining = str.Substring(i);
            int rem = remaining.Length;
            for (i = str.Length + 1; i < 62; i++) rem += i - 1;
            return rem;
        }
    }
}
