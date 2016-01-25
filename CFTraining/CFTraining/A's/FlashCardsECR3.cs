using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class FlashCardsECR3
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            Array.Sort(a);
            int sum = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                sum += a[i];
                if (sum >= m)
                {
                    Console.WriteLine(n - i);
                    return;
                }
            }
        }
    }
}
