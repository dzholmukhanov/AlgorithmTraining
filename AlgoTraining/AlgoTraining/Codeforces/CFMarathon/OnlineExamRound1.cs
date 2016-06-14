using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                n = 1000;
                x = 100;
                k = 2000;
                seq = new char[n];
                answer = new char[n];
                Randomize(answer, 0, n - 1);
                Randomize(seq, 0, n - 1);
                //int max = -1;
                //char[] maxSeq = new char[n];
                //Array.Copy(seq, maxSeq, n);
                //bool flag = false;
                //for (int i = 0; i < x; i++)
                //{
                //    //writer.WriteLine(new string(seq));

                //    //writer.Flush();
                //    //int index = fs.NextInt();

                //    int t = i / 20; // 0 1 2 3 4
                //    if (!flag)
                //    {
                //        Randomize(seq, 1000 * t, 1000 * t + 999);
                //        if (i == 20) Array.Copy(maxSeq, 0, seq, 0, 1000);
                //        else if (i == 40) Array.Copy(maxSeq, 1000, seq, 1000, 1000);
                //        else if (i == 60) Array.Copy(maxSeq, 2000, seq, 2000, 1000);
                //        else if (i == 80) Array.Copy(maxSeq, 3000, seq, 3000, 1000);
                //    }
                //    int index = Judge() - 1;
                //    if (index == n) break;
                //    if (!flag)
                //    {
                //        if (index > max)
                //        {
                //            max = index;
                //            Array.Copy(seq, 1000 * t, maxSeq, 1000 * t, 1000);
                //        }
                //        if (index >= 4200) flag = true;
                //    }
                //    if (flag)
                //    {
                //        Invert(seq, index, index);
                //    }
                //    writer.WriteLine(i + " " + index + " " + t);
                //    writer.Flush();
                //}
                int min = int.MaxValue, max = int.MinValue;
                for (int i = 0; i < 20; i++)
                {
                    int cmp = Compare();
                    min = Math.Min(min, cmp);
                    max = Math.Max(max, cmp);
                    writer.WriteLine(i + " " + cmp);
                    writer.Flush();
                    Randomize(seq, 0, n - 1);
                }
                writer.WriteLine(min + " " + max);
            }
        }
        public static void Recalc(int index)
        {
            if (index < 4100) Randomize(seq, 0, n - 1);
            else Invert(seq, index, index);

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
        private static void Randomize(char[] a, int l, int r)
        {
            for (int i = l; i <= r && i < a.Length; i++)
            {
                a[i] = random.NextDouble() < 0.5 ? '0' : '1';
            }
        }
        private static void Invert(char[] a, int l, int r)
        {
            for (int i = l; i <= r && i < a.Length; i++)
            {
                a[i] = a[i] == '0' ? '1' : '0';
            }
        }
    }
}
