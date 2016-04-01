using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class RoadsNotOnlyInBerland25
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                DisjointSet dsu = new DisjointSet();
                List<string> cycles = new List<string>();
                for (int i = 1; i <= n; i++) 
                {
                    dsu.MakeSet(i);
                }
                for (int i = 0; i < n - 1; i++)
                {
                    int a = fs.NextInt(), b = fs.NextInt();
                    if (dsu.FindSet(a) == dsu.FindSet(b)) cycles.Add(a + " " + b);
                    else dsu.Union(a, b);
                }
                HashSet<int> hashSet = new HashSet<int>();
                for (int i = 1; i <= n; i++)
                {
                    hashSet.Add(dsu.FindSet(i));
                }
                int[] leaders = hashSet.ToArray();
                writer.WriteLine(leaders.Length - 1);
                int j = 0;
                for (int i = 0; i < leaders.Length - 1; i++)
                {
                    writer.WriteLine(cycles[j++] + " " + leaders[i] + " " + leaders[i + 1]);
                }
            }
        }
    }
}
