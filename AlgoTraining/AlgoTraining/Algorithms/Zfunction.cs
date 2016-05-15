using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Algorithms
{
    public class Zfunction
    {
        public static void Run()
        {
            StringBuilder sb = new StringBuilder((int)1e8);
            for (int i = 0; i < (int)1e8; i++)
            {
                sb.Append(1);
            }
            string str = sb.ToString();

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            int[] z2 = ZFunction(str);
            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds / 1000.0;

            Console.WriteLine("Linear algoritm RT: " + elapsedMs2);
        }
        public static int[] ZFunctionTrivial(string str)
        {
            int n = str.Length;
            int[] z = new int[n];
            for (int i = 1; i < n; i++)
            {
                while(i + z[i] < n && str[z[i]] == str[i + z[i]]) 
                {
                    z[i]++;
                }
            }
            return z;
        }
        public static int[] ZFunction(string str)
        {
            int n = str.Length;
            int[] z = new int[n];
            int l = 0, r = 0;
            for (int i = 1; i < n; i++)
            {
                if (i <= r)
                {
                    z[i] = Math.Min(z[i - l], r - i + 1);
                }
                while (i + z[i] < n && str[z[i]] == str[i + z[i]])
                {
                    z[i]++;
                }
                if (i + z[i] - 1 > r)
                {
                    l = i;
                    r = i + z[i] - 1;
                }
            }
            return z;
        }
    }
}
