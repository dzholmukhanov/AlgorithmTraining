using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.D_s
{
    class LongestK_GoodSegmentECR5
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]);
            int k = Convert.ToInt32(line[1]);
            int[] a = new int[n], used = new int[1000001];
            int l = -1, r = -1, maxLen = 0;
            line = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++) a[j] = Convert.ToInt32(line[j]);

            int i = 0, unique = 0;
            for (int j = 0; j < n; j++)
            {
                used[a[j]]++;
                if (used[a[j]] == 1) unique++;
                if (unique > k)
                {
                    while (unique > k)
                    {
                        used[a[i]]--;
                        if (used[a[i]] == 0) unique--;
                        i++;
                    }
                }
                if (unique <= k)
                {
                    if (j - i + 1 > maxLen)
                    {
                        maxLen = j - i + 1;
                        l = i;
                        r = j;
                    }
                }
            }
            Console.WriteLine((l + 1) + " " + (r + 1));
        }
    }
}
