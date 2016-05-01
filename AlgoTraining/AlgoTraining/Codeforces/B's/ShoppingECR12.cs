using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class ShoppingECR12
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), k = fs.NextInt();
                LinkedList<int> row = new LinkedList<int>();
                for (int i = 0; i < k; i++)
                {
                    row.AddLast(fs.NextInt());
                }
                int[,] orders = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        orders[i, j] = fs.NextInt();
                    }
                }
                int res = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int index = 0;
                        var node = row.First;
                        for (; node != null; node = node.Next, index++)
                        {
                            if (orders[i, j] == node.Value) break;
                        }
                        res += index + 1;
                        row.Remove(node);
                        row.AddFirst(node);
                    }
                }
                writer.WriteLine(res);
            }
        }
    }
}
