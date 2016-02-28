using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class FarRelativesProblem343
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] male = new int[367], fem = new int[367];
                for (int i = 0; i < n; i++)
                {
                    string[] line = fs.ReadLine().Split(' ');
                    if (line[0] == "M")
                    {
                        int l = Convert.ToInt32(line[1]), r = Convert.ToInt32(line[2]);
                        for (int j = l; j <= r; j++) male[j]++;
                    }
                    else if (line[0] == "F")
                    {
                        int l = Convert.ToInt32(line[1]), r = Convert.ToInt32(line[2]);
                        for (int j = l; j <= r; j++) fem[j]++;
                    }
                }
                int ans = 0;
                for (int i = 1; i < 367; i++)
                {
                    ans = Math.Max(ans, Math.Min(male[i], fem[i]) * 2);
                }
                writer.WriteLine(ans);
            }
        }
    }
}
