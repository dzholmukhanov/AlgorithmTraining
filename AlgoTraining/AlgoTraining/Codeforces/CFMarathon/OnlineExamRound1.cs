using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.CFMarathon
{
    class OnlineExamRound1
    {
        private static Random random = new Random();
        private static char[] seq, answer;
        private static int n, x, k;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                n = 5000;
                x = 100;
                k = 2000;
                seq = new char[n];
                answer = new char[n];
                RandomizeRange(answer, 0, n - 1);
                RandomizeRange(seq, 0, n - 1);
                int max = 0;
                for (int i = 0; i < x; i++)
                {
                    //writer.WriteLine(new string(seq));
                    //writer.Flush();
                    int index = Judge() - 1;
                    writer.WriteLine(i + " " + index);
                    writer.Flush();
                    if (index == n) break;
                    Recalc(index);
                    max = Math.Max(max, index);
                }
                writer.WriteLine("Max " + max);
            }
        }
        public static void Recalc(int index)
        {
            if (index < 4100) RandomizeRange(seq, 0, n - 1);
            else
            {
                InvertRange(seq, index, index);
                //RandomizeRange(seq, 4000, n - 1);
            }
            //RandomizeRange(seq, 0, n - 1);
        }
        private static int Compare()
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (seq[i] == answer[i]) count++;
            }
            return count;
        }
        private static int Judge()
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (seq[i] != answer[i]) count++;
                if (count == k) return i + 1;
            }
            return n + 1;
        }
        private static char GetRandomBit()
        {
            return random.NextDouble() < 0.5 ? '0' : '1';
        }
        private static char InvertBit(char c)
        {
            return c == '0' ? '1' : '0';
        }
        private static void RandomizeRange(char[] a, int l, int r)
        {
            for (int i = l; i <= r && i < a.Length; i++)
            {
                a[i] = GetRandomBit();
            }
        }
        private static void InvertRange(char[] a, int l, int r)
        {
            for (int i = l; i <= r && i < a.Length; i++)
            {
                a[i] = InvertBit(seq[i]);
            }
        }
    }
}
