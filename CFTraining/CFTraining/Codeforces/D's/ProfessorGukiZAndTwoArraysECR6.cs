using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.D_s
{
    class ProfessorGukiZAndTwoArraysECR6
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] line = Console.ReadLine().Split(' ');
            long asum = 0, bsum = 0;
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(line[i]);
                asum += a[i];
            }
            int m = Convert.ToInt32(Console.ReadLine());
            int[] b = new int[m];
            line = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++)
            {
                b[i] = Convert.ToInt32(line[i]);
                bsum += b[i];
            }
            int k = 0, l = -1, r = -1;
            long val = Math.Abs(asum - bsum);
            if (val == 0)
            {
                Console.WriteLine(0 + "\n" + 0);
                return;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    long temp = Math.Abs((asum - a[i] + b[j]) - (bsum - b[j] + a[i]));
                    if (temp < val)
                    {
                        k = 1;
                        val = temp;
                        l = i;
                        r = j;
                    }
                }
            }
            if (k == 0)
            {
                Console.WriteLine(val + "\n" + 0);
                return;
            }
            asum = asum - a[l] + b[r];
            bsum = bsum - b[r] + a[l];
            int t = a[l];
            a[l] = b[r];
            b[r] = t;
            sb.Append((l + 1) + " " + (r + 1) + "\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    long temp = Math.Abs((asum - a[i] + b[j]) - (bsum - b[j] + a[i]));
                    if (temp < val)
                    {
                        val = temp;
                        k = 2;
                        l = i;
                        r = j;
                    }
                }
            }
            if (k == 2)
            {
                sb.Append((l + 1) + " " + (r + 1) + "\n");
            }
            Console.WriteLine(val);
            Console.WriteLine(k);
            Console.Write(sb);
        }
    }
}
