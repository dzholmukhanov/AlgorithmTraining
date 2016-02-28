using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class MoreCowbell334
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]),
                k = Convert.ToInt32(line[1]);

            int[] bells = new int[n];
            line = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                bells[i] = Convert.ToInt32(line[i]);
            }

            if (k >= n)
            {
                Console.WriteLine(bells.Max());
                return;
            }

            int withoutPairAmount = 2 * (k - (int)Math.Ceiling(n / 2.0));
            if (n % 2 != 0) withoutPairAmount++;

            long[] leftPart = new long[n - withoutPairAmount];
            long[] shirnkedLeftPart = new long[(n - withoutPairAmount) / 2];
            long[] rightPart = new long[withoutPairAmount];

            Array.Copy(bells, 0, leftPart, 0, leftPart.Length);
            Array.Copy(bells, n - withoutPairAmount, rightPart, 0, rightPart.Length);
            for (int i = 0; i < shirnkedLeftPart.Length; i++)
            {
                shirnkedLeftPart[i] = leftPart[i] + leftPart[leftPart.Length - i - 1];
            }
            long result = shirnkedLeftPart.Concat(rightPart).Max();
            Console.WriteLine(result);
        }
    }
}
