using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.C_s
{
    class PearsInARowECR6
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] line = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(line[i]);
            }
            Dictionary<int, bool> met = new Dictionary<int, bool>();
            LinkedList<Tuple<int, int>> segments = new LinkedList<Tuple<int, int>>();
            
            int l = 0, r = 0, k = 0;
            while (r < n)
            {
                if (!met.ContainsKey(a[r])) met.Add(a[r++], true);
                else
                {
                    met = new Dictionary<int, bool>();
                    segments.AddLast(new Tuple<int, int>(l + 1, r + 1));
                    k++;
                    r++;
                    l = r;
                }
            }
            if (k == 0) Console.WriteLine(-1);
            else
            {
                if (l < n)
                {
                    Tuple<int, int> last = segments.Last.Value;
                    segments.Last.Value = new Tuple<int, int>(last.Item1, n);
                }
                Console.WriteLine(k);
                foreach (Tuple<int, int> segment in segments)
                {
                    Console.WriteLine(segment.Item1 + " " + segment.Item2);
                }
            }
        }
    }
}
