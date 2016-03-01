using CFTraining.A_s;
using CFTraining.B_s;
using CFTraining.C_s;
using CFTraining.D_s;
using CFTraining.E_s;
using CFTraining.F_s;
using CFTraining.WorldCodeSprint;
using CFTraining.WunderFund2016;
using CFTraining.AimTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFTraining.HackerRank;
using System.Numerics;
using CFTraining._8VCVentureCup2016;
using AlgoTraining.Test;

namespace CFTraining
{
    class Bootstrap
    {
        public static void Main(string[] args)
        {
            long[] a = Enumerable.Repeat<long>(2, 10).ToArray();
            SqrtDecomposer<long> dec = new SqrtDecomposer<long>(a, new SqrtSum());
            dec.Update(0, 10);
            dec.Update(5, 10);
            dec.Update(9, 10);
            Console.WriteLine(dec.Eval(0, 9));
        }
    }
}
