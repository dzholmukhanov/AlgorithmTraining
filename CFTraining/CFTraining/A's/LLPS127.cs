using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.A_s
{
    class LLPS127
    {
        public static void Run()
        {
            string s = Console.ReadLine();
            char maxVal = s[0];
            int max = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] > maxVal)
                {
                    maxVal = s[i];
                    max = i;
                }
            }
            string localRes = "" + s[max];
            for (int i = max + 1; i < s.Length; i++)
            {
                if (s[i] == s[max])
                {
                    localRes += s[i];
                }
            }
            Console.WriteLine(localRes);
        }
    }
}
