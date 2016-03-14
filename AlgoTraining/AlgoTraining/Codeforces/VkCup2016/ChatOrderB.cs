using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class ChatOrderB
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                HashSet<string> friends = new HashSet<string>();
                string[] convs = new string[n];
                for (int i = 0; i < n; i++)
                {
                    convs[i] = fs.ReadLine();
                }
                for (int i = n - 1; i >= 0; i--)
                {
                    if (!friends.Contains(convs[i]))
                    {
                        writer.WriteLine(convs[i]);
                        friends.Add(convs[i]);
                    }
                }
            }
        }
    }
}
