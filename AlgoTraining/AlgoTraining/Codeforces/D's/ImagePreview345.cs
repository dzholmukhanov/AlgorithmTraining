using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class ImagePreview345
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), a = fs.NextInt(), b = fs.NextInt(), t = fs.NextInt();
                string line = fs.ReadLine();
                int[] costs = new int[n], costSumRight = new int[n], costSumLeft = new int[n];
                costs[0] = line[0] == 'w' ? b + 1 : 1;
                for (int i = 1; i < n; i++)
                {
                    costs[i] = line[i] == 'w' ? b + 1 : 1;
                    if (i == 1) costSumRight[i] = costs[i];
                    else costSumRight[i] = costSumRight[i - 1] + costs[i] + a;
                }
                for (int i = n - 2; i >= 0; i--)
                {
                    if (i == n - 2) costSumLeft[i] = costs[i + 1];
                    else costSumLeft[i] = costSumLeft[i + 1] + costs[i + 1] + a;
                }   
                int ans = 0;
                if (t >= costs[0])
                {
                    t -= costs[0];
                    int j = 0, k = n - 1;
                    while (j < n - 1 && costSumRight[j + 1] <= t - a)
                    {
                        j++;
                    }
                    while (k > 0 && costSumLeft[k - 1] <= t - a)
                    {
                        k--;
                    }
                    ans = Math.Max(n - k, j + 1);
                    int temp = t;
                    for (int i = n - 1; i > 0; i--)
                    {
                        temp -= costs[i] + a;
                        if (temp < 0) break;
                        if (i == j) j--;
                        while (j > 0 && costSumRight[j] > temp - a * (n - i + 1))
                        {
                            j--;
                        }
                        ans = Math.Max(ans, n - i + 1 + j);
                    }
                    temp = t;
                    for (int i = 1; i < n; i++)
                    {
                        temp -= costs[i] + a;
                        if (temp < 0) break;
                        if (i == k + 1) k++;
                        while (k < n - 1 && costSumLeft[k] > temp - a * (i + 1))
                        {
                            k++;
                        }
                        ans = Math.Max(ans, i + n - k);
                    }
                }
                writer.WriteLine(ans);
            }
        }
    }
}
