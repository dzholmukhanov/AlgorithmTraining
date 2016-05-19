using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.LightOJ
{
    class FibsievesFantabulousBirthday
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                for (int i = 1; i <= t; i++)
                {
                    long s = fs.NextLong();
                    long upper = (long)Math.Ceiling(Math.Sqrt(s));
                    long lower = upper - 1;
                    long lt = s - lower * lower, x, y;
                    if ((upper & 1) == 0)
                    {
                        x = Math.Min(upper, lt);
                        y = upper - (lt > upper ? (lt - upper) : 0);
                    }
                    else
                    {
                        x = upper - (lt > upper ? (lt - upper) : 0);
                        y = Math.Min(upper, lt);
                    }
                    writer.WriteLine("Case " + i + ": " + x + " " + y);
                }
            }
        }
    }
}
