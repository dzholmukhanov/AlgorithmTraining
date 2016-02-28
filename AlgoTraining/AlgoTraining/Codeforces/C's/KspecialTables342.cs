using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class KspecialTables342
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt(), k = sc.NextInt();
            int left = 1, right = n * (k - 1) + 1, ksum = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < k - 1) sb.Append(left++ + " ");
                    else
                    {
                        if (j == k - 1) ksum += right;
                        sb.Append(right++ + " ");
                    }
                }
                sb.Append("\n");
            }
            Console.WriteLine(ksum);
            Console.Write(sb);
        }
    }
}
