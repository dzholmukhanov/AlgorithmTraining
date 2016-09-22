using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class PlayingWithSuperglueCroc
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int x1 = fs.NextInt(), y1 = fs.NextInt();
                int x2 = fs.NextInt(), y2 = fs.NextInt();
                int w = Math.Abs(x1 - x2) + 1, h = Math.Abs(y1 - y2) + 1;
                if ((w == 5 && h == 5) || (w >= 6 || h >= 6) || (w == 4 && h == 5) || (w == 5 && h == 4)) writer.WriteLine("Second");
                else writer.WriteLine("First");
            }
        }
    }
}
