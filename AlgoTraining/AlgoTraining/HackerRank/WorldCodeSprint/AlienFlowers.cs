using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.WorldCodeSprint
{
    class AlienFlowers
    {
        // Not solved yet
        private static int Mod = (int)1e9 + 7;
        private static long[] fact = new long[(int)3e5];
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            fact[0] = 1;
            for (int i = 1; i < fact.Length; i++)
            {
                fact[i] = (i * fact[i - 1]) % Mod;
            }

            int A = sc.NextInt(), B = sc.NextInt(), D = sc.NextInt(), C = sc.NextInt();
            long ans = 0;
            if (A == 0 && B == 0 && C == 0 && D == 0) ans = 2;
            else if (((A != 0 && D == 0) || (A == 0 && D != 0)) && B == 0 && C == 0) ans = 1;
            if (B == C && B != 0)
            {
                ans = ((GetCombination(A + B, B) * GetCombination(D + B - 1, B - 1)) % Mod + (GetCombination(D + B, B) * GetCombination(A + B - 1, B - 1)) % Mod) % Mod;
            }
            else if (Math.Abs(B - C) == 1)
            {
                int M = Math.Max(B, C);
                ans = (GetCombination(M + A - 1, M - 1) * GetCombination(M + D - 1, M - 1)) % Mod;
            }
            Console.WriteLine(ans);
        }
        public static long GetCombination(int n, int k)
        {
            if (n < k || n == 0) return 0;
            if (n == k || k == 0) return 1;

            return fact[n] / ((fact[k] * fact[n - k]) % Mod);
        }
        public static long GetBinCoef(int n, int k)
        {
            if (k > n) throw new Exception("Undefined binomial coefficient");
            else if (k == 0) return 1;
            else if (k > n / 2) return GetBinCoef(n, n - k);
            return ((n * GetBinCoef(n - 1, k - 1)) / k) % Mod;
        }
    }
}
