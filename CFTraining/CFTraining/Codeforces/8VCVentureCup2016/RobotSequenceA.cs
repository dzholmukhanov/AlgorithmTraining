using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining._8VCVentureCup2016
{
    class RobotSequenceA
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), cmd = 0;
                string s = fs.ReadLine();
                for (int i = 0; i < n - 1; i++)
                {
                    int x = 0, y = 0;
                    perform(ref x, ref y, s[i]);
                    for (int j = i + 1; j < n; j++)
                    {
                        perform(ref x, ref y, s[j]);
                        if (x == 0 && y == 0) cmd++;
                    }
                }
                writer.WriteLine(cmd);
            }
        }

        private static void perform(ref int x, ref int y, char c)
        {
            if (c == 'U') y--;
            else if (c == 'D') y++;
            else if (c == 'L') x--;
            else x++;
        }
    }
}
