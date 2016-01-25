using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.B_s
{
    class GenasCode339
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine()), zeros = 0;
            string[] line = Console.ReadLine().Split(' ');
            string a = "1";
            for (int i = 0; i < n; i++)
            {
                if (line[i] == "0")
                {
                    Console.WriteLine(0);
                    return;
                }
                if (IsBeautiful(line[i]))
                {
                    zeros += NumberOfZeros(line[i]);
                }
                else a = line[i];
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(a);
            while (zeros-- > 0) sb.Append("0");
            Console.WriteLine(sb);
        }

        private static int NumberOfZeros(string p)
        {
            int zeros = 0;
            foreach (char c in p)
            {
                if (c == '0') zeros++;
            }
            return zeros;
        }

        private static bool IsBeautiful(string p)
        {
            int ones = 0;
            foreach (char c in p)
            {
                if (c == '0') continue;
                else if (c == '1')
                {
                    ones++;
                    if (ones > 1) return false;
                }
                else return false;
            }
            return true;
        }
    }
}
