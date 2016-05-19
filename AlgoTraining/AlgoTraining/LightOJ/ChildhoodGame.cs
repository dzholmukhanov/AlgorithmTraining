using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.LightOJ
{
    class ChildhoodGame
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int t = fs.NextInt();
                for (int i = 1; i <= t; i++)
                {
                    string[] line = fs.ReadLine().Split();
                    int n = Convert.ToInt32(line[0]);
                    string winner = "Alice";
                    if (line[1] == "Alice")
                    {
                        winner = (n - 1) % 3 == 0 ? "Bob" : "Alice";
                    }
                    else
                    {
                        winner = n % 3 == 0 ? "Alice" : "Bob";
                    }
                    writer.WriteLine("Case " + i + ": " + winner);
                }
            }
        }
    }
}
