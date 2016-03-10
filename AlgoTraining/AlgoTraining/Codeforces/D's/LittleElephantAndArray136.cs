using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class LittleElephantAndArray136
    {
        private static Dictionary<int, int> counts;
        private static int answer = 0;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), bsize = (int)Math.Ceiling(Math.Sqrt(n));
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                }
                Query[] queries = new Query[m];
                for (int i = 0; i < m; i++)
                {
                    int left = fs.NextInt() - 1, right = fs.NextInt() - 1;
                    queries[i] = new Query { Id = i, Left = left, Right = right, Block = left / bsize };
                }
                queries = queries.OrderBy(q => q.Block).ThenBy(q => q.Right).ToArray();
                counts = new Dictionary<int, int>();
                int l = 0, r = 0;
                Add(a[0]);
                int[] answers = new int[m];
                foreach (Query q in queries)
                {
                    while (r < q.Right)
                    {
                        r++;
                        Add(a[r]);
                    }
                    while (r > q.Right)
                    {
                        Remove(a[r]);
                        r--;
                    }
                    while (l < q.Left)
                    {
                        Remove(a[l]);
                        l++;
                    }
                    while (l > q.Left)
                    {
                        l--;
                        Add(a[l]);
                    }
                    answers[q.Id] = answer;
                }
                for (int i = 0; i < m; i++)
                {
                    writer.WriteLine(answers[i]);
                }
            }
        }

        private static void Remove(int i)
        {
            if (counts[i] == i) answer--;
            else if (counts[i] - 1 == i) answer++;
            counts[i]--;
        }

        private static void Add(int i)
        {
            if (!counts.ContainsKey(i)) counts.Add(i, 0);
            if (counts[i] == i) answer--;
            else if (counts[i] + 1 == i) answer++;
            counts[i]++;
        }
    }
    class Query
    {
        public int Id, Left, Right, Block;
    }
}
