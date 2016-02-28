using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class BirthdayCake343
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] rows = new int[n], cols = new int[n];
                for (int i = 0; i < n; i++)
                {
                    string s = fs.ReadLine();
                    for (int j = 0; j < n; j++)
                    {
                        if (s[j] == 'C')
                        {
                            rows[i]++;
                            cols[j]++;
                        }
                    }
                }
                long ans = 0;
                for (int i = 0; i < n; i++)
                {
                    ans += (rows[i] * (rows[i] - 1)) / 2;
                    ans += (cols[i] * (cols[i] - 1)) / 2;
                }
                writer.WriteLine(ans);
            }
        }
    }
}
