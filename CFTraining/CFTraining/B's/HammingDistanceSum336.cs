using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class HammingDistanceSum336
    {
        public static void Run()
        {
            string a = Console.ReadLine(),
                   b = Console.ReadLine();
            int[] oneSum = new int[a.Length];
            int[] zeroSum = new int[a.Length];
            int[] used = new int[b.Length];
            for (int i = 0; i < oneSum.Length; i++)
            {
                oneSum[i] = (a[i] == '1') ? 1 : 0;
                if (i > 0) oneSum[i] += oneSum[i - 1];
                zeroSum[i] = (a[i] == '0') ? 1 : 0;
                if (i > 0) zeroSum[i] += zeroSum[i - 1];
            }

            long hammingSum = 0;
            if (a.Length == b.Length)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    if (a[i] != b[i]) hammingSum++;
                }
            }
            else
            {
                int maxFreq = Math.Min(a.Length, b.Length - a.Length + 1);
                for (int i = 0; i < used.Length / 2; i++)
                {
                    used[i] = Math.Min(i + 1, maxFreq);
                    used[used.Length - i - 1] = Math.Min(i + 1, maxFreq);
                }
                if (used.Length % 2 == 1) used[used.Length / 2] = Math.Min(used.Length / 2, maxFreq);
                for (int i = 0; i < used.Length; i++)
                {
                    int j = Math.Min(i, a.Length - 1);
                    if (b[i] == '0') hammingSum += oneSum[j] - oneSum[Math.Max(j - used[i], 0)];
                    else hammingSum += zeroSum[j] - zeroSum[Math.Max(j - used[i], 0)]; 
                }
            }
            Console.WriteLine(hammingSum);
        }
    }
}
