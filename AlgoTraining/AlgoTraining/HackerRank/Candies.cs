using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.HackerRank
{
    class Candies
    {
        public static void Run()
        {
            ConsoleScanner cs = new ConsoleScanner();
            int n = cs.NextInt();
            int[] ratings = new int[n];
            int[] candies = new int[n];
            for (int i = 0; i < n; i++)
            {
                ratings[i] = cs.NextInt();
            }
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && i < n - 1)
                {
                    if (ratings[i] <= ratings[i - 1] && ratings[i] <= ratings[i + 1]) candies[i] = 1;
                }
                else if (n > 1)
                {
                    if (i == 0 && ratings[i] <= ratings[i + 1] || i == n - 1 && ratings[i] <= ratings[i - 1]) candies[i] = 1;
                }
                else candies[i] = 1;
            }
            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1]) candies[i] = candies[i - 1] + 1;
            }
            for (int i = n - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1]) candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += candies[i];
            }
            Console.WriteLine(sum);
        }
    }
}
