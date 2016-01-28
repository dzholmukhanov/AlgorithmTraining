using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.E_s
{
    class XorAndFavoriteNumber340
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt(), m = sc.NextInt(), k = sc.NextInt(), blockSize = (int)Math.Ceiling(Math.Sqrt(n));
            int[] a = new int[n], pref = new int[n], count = new int[(int)2e6];
            Query[] queries = new Query[m];
            long[] offlineAnswers = new long[m];

            for (int i = 0; i < n; i++)
            {
                a[i] = sc.NextInt();
                if (i == 0) pref[i] = a[i];
                else pref[i] = a[i] ^ pref[i - 1];
            }
            for (int i = 0; i < m; i++)
            {
                queries[i] = new Query { Id = i, Left = sc.NextInt() - 1, Right = sc.NextInt() - 1 };
                queries[i].Block = queries[i].Left / blockSize;
            }

            queries = queries.OrderBy(q => q.Block).ThenBy(q => q.Right).ToArray();

            int wL = 0, wR = 1;
            count[pref[0]]++;
            long ans = count[pref[1] ^ k];
            count[pref[1]]++;
            // Mo's Algorithm
            foreach (Query query in queries)
            {
                while (wR < query.Right)
                {
                    wR++;
                    ans += count[pref[wR] ^ k];
                    count[pref[wR]]++;
                }
                while (wR > query.Right)
                {
                    count[pref[wR]]--;
                    ans -= count[pref[wR] ^ k];
                    wR--;
                }
                while (wL < query.Left)
                {
                    count[pref[wL]]--;
                    ans -= count[pref[wL] ^ k];
                    wL++;
                }
                while (wL > query.Left)
                {
                    wL--;
                    ans += count[pref[wL] ^ k];
                    count[pref[wL]]++;
                }
                offlineAnswers[query.Id] = ans + count[(wL > 0 ? pref[wL - 1] : 0) ^ k];
            }
            foreach (long res in offlineAnswers)
            {
                Console.WriteLine(res);
            }
        }
    }

    class Query
    {
        public int Id, Left, Right, Block;
    }
}
