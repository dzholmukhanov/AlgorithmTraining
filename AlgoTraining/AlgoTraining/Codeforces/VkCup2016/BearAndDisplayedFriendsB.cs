using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class BearAndDisplayedFriendsB
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), k = fs.NextInt(), q = fs.NextInt();
                User[] t = new User[n];
                List<User> d = new List<User>(k);
                for (int i = 0; i < n; i++)
                {
                    t[i] = new User { Id = i, Val = fs.NextInt() };
                }
                while (q-- > 0)
                {
                    int type = fs.NextInt(), id = fs.NextInt() - 1;
                    if (type == 1)
                    {
                        if (d.Count < k) d.Add(t[id]);
                        else
                        {
                            d = d.OrderByDescending(el => el.Val).ToList();
                            if (d.Last().Val < t[id].Val)
                            {
                                d.RemoveAt(k - 1);
                                d.Add(t[id]);
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine(d.Contains(t[id]) ? "YES" : "NO");
                    }
                }
            }
        }
    }
    class User
    {
        public int Id, Val;
    }
}
