using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class RecyclingBottles352
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                long ax = fs.NextInt(), ay = fs.NextInt();
                long bx = fs.NextInt(), by = fs.NextInt();
                long tx = fs.NextInt(), ty = fs.NextInt();
                long n = fs.NextInt();
                Point[] adils = new Point[n];
                Point[] beras = new Point[n];
                double binSum = 0.0;
                for (int i = 0; i < n; i++)
                {
                    long x = fs.NextInt(), y = fs.NextInt();
                    adils[i] = new Point { Id = i, X = x, Y = y, DistToBin = Dist(x, y, tx, ty), DistToBoy = Dist(x, y, ax, ay) };
                    beras[i] = new Point { Id = i, X = x, Y = y, DistToBin = adils[i].DistToBin, DistToBoy = Dist(x, y, bx, by) };
                    binSum += adils[i].DistToBin * 2;
                }
                adils = adils.OrderByDescending(x => x.DistToBin - x.DistToBoy).ToArray();
                beras = beras.OrderByDescending(x => x.DistToBin - x.DistToBoy).ToArray();

                double ans = binSum - adils[0].DistToBin + adils[0].DistToBoy;
                ans = Math.Min(ans, binSum - beras[0].DistToBin + beras[0].DistToBoy);
                if (adils[0].Id != beras[0].Id)
                {
                    ans = Math.Min(ans, binSum - beras[0].DistToBin + beras[0].DistToBoy - adils[0].DistToBin + adils[0].DistToBoy);
                }
                else if (n > 1)
                {
                    ans = Math.Min(ans, binSum - beras[0].DistToBin + beras[0].DistToBoy - adils[1].DistToBin + adils[1].DistToBoy);
                    ans = Math.Min(ans, binSum - beras[1].DistToBin + beras[1].DistToBoy - adils[0].DistToBin + adils[0].DistToBoy);
                }
                writer.WriteLine(ans.ToString().Replace(',', '.'));
            }
        }

        private static double Dist(long x1, long y1, long x2, long y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
    }
    class Point
    {
        public int Id;
        public long X, Y;
        public double DistToBin, DistToBoy;
    }
}
