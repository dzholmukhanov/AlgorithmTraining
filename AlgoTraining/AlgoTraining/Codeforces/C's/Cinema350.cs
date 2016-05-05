using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class Cinema350
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                Dictionary<int, int> count = new Dictionary<int, int>();
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                    if (!count.ContainsKey(a[i])) count.Add(a[i], 0);
                    count[a[i]]++;
                }
                int m = fs.NextInt();
                int[] b = new int[m];
                int[] c = new int[m];
                Movie[] movies = new Movie[m];
                for (int i = 0; i < m; i++)
                {
                    b[i] = fs.NextInt();
                }
                for (int i = 0; i < m; i++)
                {
                    c[i] = fs.NextInt();
                    movies[i] = new Movie 
                    { 
                        Id = i + 1, 
                        Fully = count.ContainsKey(b[i]) ? count[b[i]] : 0, 
                        Almost = count.ContainsKey(c[i]) ? count[c[i]] : 0
                    };
                }
                movies = movies.OrderByDescending(x => x.Fully).ThenByDescending(x => x.Almost).ToArray();
                writer.WriteLine(movies[0].Id);
            }
        }
    }
    class Movie
    {
        public int Id, Fully, Almost;
    }
}
