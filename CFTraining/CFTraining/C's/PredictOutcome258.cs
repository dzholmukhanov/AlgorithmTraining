using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class PredictOutcome258
    {
        public static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                string[] line = Console.ReadLine().Split(' ');
                long n = Convert.ToInt64(line[0]),
                    k = Convert.ToInt64(line[1]),
                    d1 = Convert.ToInt64(line[2]),
                    d2 = Convert.ToInt64(line[3]);
                long[,] outcomes = new long[4, 3] { 
                    { 0, d1, d1 + d2 },
                    { d1 > d2 ? 0 : d2 - d1, Math.Max(d1, d2), d2 > d1 ? 0 : d1 - d2},
                    { d1, 0, d2},
                    { d1 + d2, d2, 0}
                };
                bool doesExist = false;
                for (int i = 0; i < 4; i++)
                {
                    long sum = outcomes[i, 0] + outcomes[i, 1] + outcomes[i, 2];
                    if (sum <= k && (k - sum) % 3 == 0)
                    {
                        outcomes[i, 0] += (k - sum) / 3;
                        outcomes[i, 1] += (k - sum) / 3;
                        outcomes[i, 2] += (k - sum) / 3;
                        long max = Math.Max(outcomes[i, 0], Math.Max(outcomes[i, 1], outcomes[i, 2]));
                        long equil = max - outcomes[i, 0];
                        equil += max - outcomes[i, 1];
                        equil += max - outcomes[i, 2];
                        if ((n - k) >= equil && ((n - k) - equil) % 3 == 0)
                        {
                            doesExist = true;
                            break;
                        }
                    }
                }
                Console.WriteLine(doesExist ? "yes" : "no");
            }
        }
    }
}
