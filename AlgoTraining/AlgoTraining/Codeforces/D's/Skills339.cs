using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.D_s
{
    class Skills339
    {
        // Not solved!
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]), A = Convert.ToInt32(line[1]), cf = Convert.ToInt32(line[2]), cm = Convert.ToInt32(line[3]);
            long m = Convert.ToInt64(line[4]), totalSum = 0;
            int[] a = new int[n], indices = new int[n];
            long[] difSums = new long[n];

            line = Console.ReadLine().Split(' ');
            int np0 = 0;
            for (int i = 0; i < n; i++) {
                a[i] = Convert.ToInt32(line[i]);
                if (a[i] == A) np0++;
                indices[i] = i;
                totalSum += A - a[i];
            }

            Array.Sort(a, indices);
            for (long i = 1; i < n; i++)
            {
                difSums[i] = difSums[i - 1] + (a[i] - a[i - 1]) * i;
            }

            long sum = 0, remaining = 0;
            int k = 0, j = n - 1;
            for (int i = n - 1; i >= 0; i--)
            {
                if (a[i] == A) continue;
                sum += A - a[i];
                if (sum <= m)
                {
                    k++;
                    j--;
                }
                else
                {
                    sum -= A - a[i];
                    break;
                }
            }
            remaining = m - sum;

            if (totalSum == sum)
            {
                long force = (long)n * cf + (long)A * cm;
                Console.WriteLine(force);
                for (int i = 0; i < n; i++) Console.Write(A + " ");
                return;
            }

            long maxForce = 0;
            int l = -1, r = -1, minLevel = 0, search = 1, used = 0;
            for (int i = 0; i <= k; i++)
            {
                int lastIndex = 0, amin;
                if (j + i != -1)
                {
                    while (search <= j + i + 1 && search < n)
                    {
                        if (difSums[search] > remaining) break;
                        search++;
                    }
                    lastIndex = search - 1;
                    amin = (int)Math.Min(A, a[lastIndex] + (remaining - difSums[lastIndex]) / (j + i + 1));
                }
                else
                {
                    amin = A;
                }
                long force = (long)(np0 + k - i) * cf + (long)amin * cm;
                if (force >= maxForce)
                {
                    maxForce = force;
                    l = lastIndex;
                    r = n - 1 - (np0 + k - i);
                    minLevel = amin;
                    used = k - i;
                }
                if (j + i + 1 < n) remaining += A - a[j + i + 1];
            }

            if (n == 1000 && A == 1000 && cf == 51 && cm == 60 && m == 300)
            {
                Console.WriteLine("np0 " + np0);
                Console.WriteLine("used " + used);
                Console.WriteLine("minLevel " + minLevel);
            }


            int[] b = new int[n];
            for (int i = 0; i <= l; i++) b[indices[i]] = minLevel;
            for (int i = l + 1; i <= r; i++) b[indices[i]] = a[i];
            for (int i = r + 1; i < n; i++) b[indices[i]] = A;

            Console.WriteLine(maxForce);
            for (int i = 0; i < n; i++) Console.Write(b[i] + " ");
        }
    }
}
