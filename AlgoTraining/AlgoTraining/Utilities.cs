using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CFTraining
{
    public class Utilities
    {
        public static int binRangeSearch(int[] a, int l, int r, int val)
        {
            if (a[r] < val) return r;
            else if (l >= r) return -1;

            int m = l + (r - l) / 2;
            if (a[m] < val && a[m + 1] < val) return binRangeSearch(a, m + 1, r, val);
            else if (a[m] > val && a[m + 1] > val) return binRangeSearch(a, l, m, val);
            else if (a[m] < val && val <= a[m + 1]) return m;
            else if (a[m] == val && val < a[m + 1] && m > 0) return m - 1;
            else return -1;
        }
        public static void ReadAndWrite()
        {
            var fs = File.Open("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var sw = new StreamWriter(fs);
            var sr = new StreamReader(fs);
            sw.Close();
            sr.Close();
        }
        public static void Print2DArray(int[,] a)
        {
            Console.WriteLine();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
