using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.WunderFund2016
{
    class SlimeCombining
    {
        private static StringBuilder _sb = new StringBuilder();
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            Solve(n);
            Console.WriteLine(_sb);
        }
        public static void Solve(int n)
        {
            if (n == 0) return;
            int p = (int)Math.Log(n, 2);
            _sb.Append((p + 1) + " ");
            Solve(n - (int)Math.Pow(2, p));
        }
    }
}
