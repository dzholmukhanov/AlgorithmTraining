using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class RandomTeams273
    {
        public static void Run()
        {
            String[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]), m = Convert.ToInt32(line[1]);

            int minPlayerNum = n / m;
            int excess = n - (minPlayerNum * m);

            long kmin = (m - excess) * SequenceSum(minPlayerNum) + excess * SequenceSum(minPlayerNum + 1);
            long kmax = SequenceSum(n - (m - 1));

            Console.WriteLine(kmin + " " + kmax);
        }
        public static long SequenceSum(long n)
        {
            return (n * (n - 1)) / 2;
        }
    }
}
