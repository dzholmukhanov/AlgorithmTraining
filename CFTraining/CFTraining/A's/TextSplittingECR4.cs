using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.A_s
{
    class TextSplittingECR4
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            string str = Console.ReadLine();
            int n = Convert.ToInt32(line[0]),
                p = Convert.ToInt32(line[1]),
                q = Convert.ToInt32(line[2]);
            if (n % p == 0) PrintString(str, p, n / p, 0, 0);
            else if (n % q == 0) PrintString(str, q, n / q, 0, 0);
            else
            {
                int pm = -1, qm = -1;
                for (int a = 1; a < 100; a++)
                {
                    for (int b = 1; b <= 100 - a; b++)
                    {
                        if (a * p + b * q == n)
                        {
                            pm = a;
                            qm = b;
                            break;
                        }
                    }
                    if (pm != -1) break;
                }
                if (pm != -1) PrintString(str, p, pm, q, qm);
                else Console.WriteLine(-1);
            }
        }
        public static void PrintString(string str, int p1, int pm1, int p2, int pm2)
        {
            Console.WriteLine(pm1 + pm2);
            int p = 0;
            for (int i = 0; i < pm1; i++)
            {
                Console.WriteLine(str.Substring(p, p1));
                p += p1;
            }
            for (int i = 0; i < pm2; i++)
            {
                Console.WriteLine(str.Substring(p, p2));
                p += p2;
            }
        }
    }
}
