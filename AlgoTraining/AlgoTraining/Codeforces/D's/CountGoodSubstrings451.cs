using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.D_s
{
    class CountGoodSubstrings451
    {
        public static void Run()
        {
            string str = Console.ReadLine();
            int[,] abCount = new int[2, 2] { { 0, 0 }, { 0, 0 } };
            long[] totalCount = new long[] { 0, 0 };
            for (int i = 0; i < str.Length; i++)
            {
                int aOrB = (str[i] == 'a') ? 0 : 1;
                int evenOrOdd = i % 2;

                abCount[aOrB, evenOrOdd]++;
                totalCount[0] += abCount[aOrB, (evenOrOdd + 1) % 2];
                totalCount[1] += abCount[aOrB, evenOrOdd];
            }
            Console.WriteLine(totalCount[0] + " " + totalCount[1]);
        }
    }
}
