using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.HackerRank
{
    class Equal
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int T = sc.NextInt();
            while (T-- > 0)
            {
                int N = sc.NextInt();
                int[] a = new int[N];
                for (int i = 0; i < N; i++)
                {
                    a[i] = sc.NextInt();
                }
                int min = a.Min();
                int[] solutions = new int[5];
                for (int i = 0; i < N; i++)
                {
                    int diff = a[i] - min;
                    solutions[0] += diff / 5 + (diff % 5) / 2 + (diff % 5) % 2;
                    solutions[1] += (diff + 1) / 5 + ((diff + 1) % 5) / 2 + ((diff + 1) % 5) % 2;
                    solutions[2] += (diff + 2) / 5 + ((diff + 2) % 5) / 2 + ((diff + 2) % 5) % 2;
                    solutions[3] += (diff + 3) / 5 + ((diff + 3) % 5) / 2 + ((diff + 3) % 5) % 2;
                    solutions[4] += (diff + 4) / 5 + ((diff + 4) % 5) / 2 + ((diff + 4) % 5) % 2;
                }
                Console.WriteLine(solutions.Min());
            }
        }
    }
}
