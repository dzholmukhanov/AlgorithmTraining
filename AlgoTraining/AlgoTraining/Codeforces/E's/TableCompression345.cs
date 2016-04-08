using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class ValueAndRowComparer : IComparer<Number>
    {
        public int Compare(Number num1, Number num2)
        {
            if (num1.Value.CompareTo(num2.Value) == 0)
            {
                return num1.Row.CompareTo(num2.Row);
            }
            else return num1.Value.CompareTo(num2.Value);
        }
    }
    class ValueAndColumnComparer : IComparer<Number>
    {
        public int Compare(Number num1, Number num2)
        {
            if (num1.Value.CompareTo(num2.Value) == 0)
            {
                return num1.Column.CompareTo(num2.Column);
            }
            else return num1.Value.CompareTo(num2.Value);
        }
    }
    class TableCompression345
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), size = n * m;
                int[,] ans = new int[n, m];
                Number[] sorted = new Number[size];
                LinkedList<Number>[] sets = new LinkedList<Number>[n * m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        sorted[i * m + j] = new Number { Id = i * m + j, Row = i, Column = j, Value = fs.NextInt() };
                        sets[i * m + j] = new LinkedList<Number>();
                    }
                }
                Array.Sort(sorted, new ValueAndRowComparer());
                DisjointSet dsu = new DisjointSet();
                dsu.MakeSet(sorted[0].Id);
                for (int i = 1; i < size; i++)
                {
                    dsu.MakeSet(sorted[i].Id);
                    if (sorted[i].Value == sorted[i - 1].Value && sorted[i].Row == sorted[i - 1].Row)
                    {
                        dsu.Union(sorted[i].Id, sorted[i - 1].Id);
                    }
                }
                Array.Sort(sorted, new ValueAndColumnComparer());
                for (int i = 1; i < size; i++)
                {
                    if (sorted[i].Value == sorted[i - 1].Value && sorted[i].Column == sorted[i - 1].Column)
                    {
                        dsu.Union(sorted[i].Id, sorted[i - 1].Id);
                    }
                }

                foreach(Number num in sorted) 
                {
                    sets[dsu.FindSet(num.Id)].AddLast(num);
                }

                Number[] rows = new Number[n], columns = new Number[m];
                for (int i = 0; i < size; i++)
                {
                    Number num = sorted[i];
                    if (ans[num.Row, num.Column] != 0)
                    {
                        num.Value = ans[num.Row, num.Column];
                        rows[num.Row] = num;
                        columns[num.Column] = num;
                        continue;
                    }

                    int count = dsu.GetSetElementCount(num.Id), max = 1;
                    if (rows[num.Row] != null) max = Math.Max(max, rows[num.Row].Value + 1);
                    if (columns[num.Column] != null) max = Math.Max(max, columns[num.Column].Value + 1);

                    if (count > 1)
                    {
                        int setNum = dsu.FindSet(num.Id);
                        foreach (Number other in sets[setNum])
                        {
                            if (other.Id == num.Id) continue;
                            if (rows[other.Row] != null) max = Math.Max(max, rows[other.Row].Value + 1);
                            if (columns[other.Column] != null) max = Math.Max(max, columns[other.Column].Value + 1);
                        }
                        foreach (Number other in sets[setNum])
                        {
                            if (other.Id == num.Id) continue;
                            ans[other.Row, other.Column] = max;
                        }
                    }
                    num.Value = max;
                    ans[num.Row, num.Column] = max;
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
        public int Id, Row, Column, Value;
    }
}