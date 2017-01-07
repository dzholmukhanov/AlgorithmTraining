using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class ParallelogramIsBack388
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int[,] points = new int[3, 2];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        points[i, j] = fs.NextInt();
                    }
                }
                writer.WriteLine(3);
                for (int i = 0; i < 3; i++)
                {
                    int ax = points[i, 0], ay = points[i, 1];
                    int bx = points[(i + 1) % 3, 0], by = points[(i + 1) % 3, 1];
                    int cx = points[(i + 2) % 3, 0], cy = points[(i + 2) % 3, 1];
                    int dx = ax + (bx - ax) + (cx - ax);
                    int dy = ay + (by - ay) + (cy - ay);
                    writer.WriteLine(dx + " " + dy);
                }
            }
        }
    }
}
