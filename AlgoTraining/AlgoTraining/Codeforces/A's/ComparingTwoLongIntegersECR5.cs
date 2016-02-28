using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CFTraining.A_s
{
    class ComparingTwoLongIntegersECR5
    {
        public static void Run()
        {
            string a = Console.ReadLine(), b = Console.ReadLine();
            //BigInteger a = BigInteger.Parse(first), b = BigInteger.Parse(second);
            //Console.WriteLine(a == b ? "=" : a < b ? "<" : ">");
            a = a.TrimStart('0');
            b = b.TrimStart('0');
            if (a.Length > b.Length) Console.WriteLine(">");
            else if (a.Length < b.Length) Console.WriteLine("<");
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > b[i])
                    {
                        Console.WriteLine(">");
                        return;
                    }
                    else if (a[i] < b[i])
                    {
                        Console.WriteLine("<");
                        return;
                    }
                } 
                Console.WriteLine("=");
            }
        }
    }
}
