using AlgoTraining.Test;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces._8VCVentureCup2016
{
    class FactoryRepairsD
    {
        public static void Run()
        {
            // not solved
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt(), a = fs.NextInt(), b = fs.NextInt(), q = fs.NextInt();
                SqrtDecomposer<long> adec = new SqrtDecomposer<long>(Enumerable.Repeat<long>(0, n).ToArray(), new SqrtBoundedSum(a));
                SqrtDecomposer<long> bdec = new SqrtDecomposer<long>(Enumerable.Repeat<long>(0, n).ToArray(), new SqrtBoundedSum(b));
                while (q-- > 0)
                {
                    int cmd = fs.NextInt();
                    if (cmd == 1)
                    {
                        int d = fs.NextInt() - 1, val = fs.NextInt();
                        adec.Update(d, adec.Get(d) + val);
                        bdec.Update(d, bdec.Get(d) + val);
                    }
                    else
                    {
                        int p = fs.NextInt() - 1;
                        writer.WriteLine(bdec.Eval(0, p - 1) + adec.Eval(p + k, n - 1));
                    }
                }
            }
        }
    }
}