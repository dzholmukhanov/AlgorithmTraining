using CFTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class MishkaAndInterestingSum365
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = Array.ConvertAll(fs.ReadLine().Split(), Convert.ToInt32);
                int m = fs.NextInt();
                Query[] queries = new Query[m];
                for (int i = 0; i < m; i++)
                {
                    queries[i] = new Query { Id = i, Left = fs.NextInt() - 1, Right = fs.NextInt() - 1};
                }
                queries = queries.OrderBy(q => q.Right).ToArray();
                int[] xor = new int[n];
                int[] answers = new int[m];
                xor[0] = a[0];
                for (int i = 1; i < n; i++)
                {
                    xor[i] = xor[i - 1] ^ a[i];
                }
                Dictionary<int, int> lastPos = new Dictionary<int, int>();
                XorSegmentTreeFast distincts = new XorSegmentTreeFast(new int[n]);
                int r = -1;
                foreach (Query q in queries)
                {
                    while (r < q.Right)
                    {
                        r++;
                        if (lastPos.ContainsKey(a[r]))
                        {
                            distincts.Update(lastPos[a[r]], 0);
                            lastPos[a[r]] = r;
                        }
                        else
                        {
                            lastPos.Add(a[r], r);
                        }
                        distincts.Update(r, a[r]);
                    }
                    answers[q.Id] = q.Left > 0 ? xor[q.Right] ^ xor[q.Left - 1] : xor[q.Right];
                    answers[q.Id] ^= distincts.QueryXor(q.Left, q.Right);
                }
                for (int i = 0; i < m; i++)
                {
                    writer.WriteLine(answers[i]);
                }
            }
        }
        class Query
        {
            public int Id, Left, Right;
        }
    }
}
