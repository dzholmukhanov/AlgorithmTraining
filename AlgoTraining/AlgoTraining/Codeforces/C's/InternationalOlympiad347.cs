using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class InternationalOlympiad347
    {
        public static string Beg = "1989";
        public static long BegNum = 1989;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                string[] reqs = new string[n];
                for (int i = 0; i < n; i++)
                {
                    reqs[i] = fs.ReadLine().Split('\'')[1];
                }
                for (int i = 0; i < n; i++)
                {
                    long num = Convert.ToInt64(FirstOccurence(reqs[i]));
                    while (!CheckIfUsed(num, reqs[i].Length))
                    {
                        num += (long)Math.Pow(10, reqs[i].Length);
                    }
                    writer.WriteLine(num);
                }
            }
        }
        public static string FirstOccurence(string suffix)
        {
            if (suffix.Length > Beg.Length) return suffix;
            else if (suffix.Length == Beg.Length)
            {
                if (Convert.ToInt64(suffix) >= BegNum) return suffix;
                else return "1" + suffix;
            }
            else
            {
                long t = Convert.ToInt64(Beg.Substring(0, Beg.Length - suffix.Length) + suffix);
                if (t >= BegNum) return t.ToString();
                else return (t + Math.Pow(10, suffix.Length)).ToString();
            }
        }
        public static bool CheckIfUsed(long num, int sufLen)
        {
            for (int i = sufLen - 1; i > 0; i--)
            {
                num -= (long) Math.Pow(10, i);
                if ( num < BegNum) return false;
            }
            return true;
        }
    }
}