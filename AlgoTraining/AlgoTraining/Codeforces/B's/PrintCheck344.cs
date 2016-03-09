using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.B_s
{
    class PrintCheck344
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), k = fs.NextInt();
                Query[] rows = new Query[n], columns = new Query[m];
                for (int i = 0; i < k; i++)
                {
                    int cmd = fs.NextInt();
                    if (cmd == 1)
                    {
                        int r = fs.NextInt() - 1, a = fs.NextInt(); 
                        rows[r] = new Query { Id = i, Color = a };
                    }
                    else
                    {   
                        int c = fs.NextInt() - 1, a = fs.NextInt();
                        columns[c] = new Query { Id = i, Color = a };
                    }
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int color = 0;
                        if (rows[i] != null && columns[j] != null)
                        {
                            if (rows[i].Id > columns[j].Id) color = rows[i].Color;
                            else color = columns[j].Color;
                        }
                        else if (rows[i] != null) color = rows[i].Color;
                        else if (columns[j] != null) color = columns[j].Color;
                        sb.Append(color + " ");
                    }
                    sb.Append("\n");
                }
                writer.Write(sb);
            }
        }
    }
    class Query
    {
        public int Id { get; set; }
        public int Color { get; set; }
    }
}
