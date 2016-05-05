using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class MagicPowder350
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                long k = fs.NextInt();
                Ingred[] a = new Ingred[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = new Ingred { Id = i, Need = fs.NextInt() };
                }
                for (int i = 0; i < n; i++)
                {
                    a[i].Have = fs.NextInt();
                }
                a = a.OrderBy(x => x.Div()).ToArray();
                long[] sum = new long[n];
                for (int i = 0; i < n; i++)
                {
                    if (i == 0) sum[0] = a[0].Need;
                    else sum[i] = a[i].Need + sum[i - 1];
                }

                long div = a[0].Div(), need = 0;
                for (int i = 0; i < n; i++)
                {
                    if (a[i].Div() > div)
                    {
                        if (k >= need)
                        {
                            k -= need;
                            div++;
                            long diff = a[i].Div() - div;
                            if (diff > 0)
                            {
                                if (k >= diff * sum[i - 1])
                                {
                                    k -= diff * sum[i - 1];
                                    div = a[i].Div();
                                }
                                else
                                {
                                    div += k / sum[i - 1];
                                    need = k + 1; // workaround
                                    break;
                                }
                            }
                            need = sum[i - 1] + a[i].Mod();
                        }
                        else break;
                    }
                    else
                    {
                        need += a[i].Mod();
                    }
                }
                if (k >= need)
                {
                    k -= need;
                    div++;
                    div += k / sum[n - 1];
                }
                writer.WriteLine(div);
            }
        }
    }
    class Ingred
    {
        public int Id;
        public long Need, Have;
        public long Mod()
        {
            return Need - Have % Need;
        }
        public long Div()
        {
            return Have / Need;
        }
    }
}
