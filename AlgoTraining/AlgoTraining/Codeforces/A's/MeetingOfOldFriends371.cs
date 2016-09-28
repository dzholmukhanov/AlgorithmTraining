using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class MeetingOfOldFriends371
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long l1 = fs.NextLong(), r1 = fs.NextLong();
                long l2 = fs.NextLong(), r2 = fs.NextLong();
                long k = fs.NextLong();
                if ((l1 >= l2 && l1 <= r2) || (l2 >= l1 && l2 <= r1))
                {
                    long r = Math.Min(r1, r2), l = Math.Max(l1, l2);
                    long ans = r - l + 1;
                    writer.WriteLine(k >= l && k <= r ? ans - 1 : ans);
                }
                else writer.WriteLine(0);
            }
        }
    }
}
