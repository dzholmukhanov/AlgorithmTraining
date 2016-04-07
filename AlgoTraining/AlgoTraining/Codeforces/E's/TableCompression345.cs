using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class TableCompression345
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int[,] a = new int[n, m], ans = new int[n, m];
                Number[] line = new Number[n * m];
                Number[] rows = new Number[n], columns = new Number[m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = fs.NextInt();
                        line[i * m + j] = new Number { Row = i, Column = j, Value = a[i, j] };
                    }
                }
                line = line.OrderBy(num => num.Value).ToArray();
                foreach (Number num in line)
                {
                    if (rows[num.Row] == null && columns[num.Column] == null)
                    {
                        num.Value = 1;
                    }
                    else
                    {
                        Number prev;
                        if (rows[num.Row] == null) prev = columns[num.Column];
                        else if (columns[num.Column] == null) prev = rows[num.Row];
                        else prev = rows[num.Row].Value >= columns[num.Column].Value ? rows[num.Row] : columns[num.Column];
                        if (a[prev.Row, prev.Column] == a[num.Row, num.Column])
                        {
                            num.Value = prev.Value;
                        }
                        else
                        {
                            num.Value = prev.Value + 1;
                        }
                    }
                    ans[num.Row, num.Column] = num.Value;
                    rows[num.Row] = num;
                    columns[num.Column] = num;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        writer.Write(ans[i, j] + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
    class Number
    {
        public int Row, Column, Value;
    }
}