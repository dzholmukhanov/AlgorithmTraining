using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CFTraining.HackerRank
{
    class NextPalindrome
    {
        public static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t --> 0)
            {
                BigInteger result = getNextPalindrome(BigInteger.Parse(Console.ReadLine()));
                Console.WriteLine(result.ToString());
            }
        }
        public static BigInteger getNextPalindrome(BigInteger num)
        {
            int len = num.ToString().Length;
            if (len == 1)
            {
                if (num == new BigInteger(9)) return new BigInteger(11);
                return num + 1;
            }
            else
            {
                int firstHalfPow = (len % 2 == 0) ? len / 2 : len / 2 + 1;
                int secondHalfPow = len / 2;
                BigInteger first = num / ((int) Math.Pow(10, firstHalfPow));
                BigInteger second = num % ((int) Math.Pow(10, secondHalfPow));
                BigInteger firstInverse = BigInteger.Parse(string.Join("", first.ToString().Reverse()));
                if (firstInverse > second)
                {
                    return num + (firstInverse - second);
                }
                else if (second > firstInverse)
                {
                    BigInteger compl = new BigInteger((int)Math.Pow(10, secondHalfPow));
                    return getNextPalindrome(num + (compl - second));
                }
                else
                {
                    return getNextPalindrome(num + 1);
                }
            }
        }
    }
}
