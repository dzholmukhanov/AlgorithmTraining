using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.C_s
{
    class RunningTrack338
    {
        public static void Run()
        {
            string s = Console.ReadLine(), t = Console.ReadLine(), sr = string.Join("", s.Reverse());
            int p = 0, answer = 0;
            StringBuilder output = new StringBuilder();
            while (p < t.Length)
            {
                int maxLen = 0, pl = 0, pr = 0;
                for (int l = 0; l < s.Length; l++)
                {
                    if (s[l] == t[p])
                    {
                        int r = l;
                        for (r = l + 1; ; r++)
                        {
                            if (p + (r - l) >= t.Length || r == s.Length || s[r] != t[p + (r - l)])
                            {
                                r--;
                                break;
                            }
                        }
                        if (r - l + 1 > maxLen)
                        {
                            maxLen = r - l + 1;
                            pl = l;
                            pr = r;
                        }
                    }
                }
                for (int l = 0; l < sr.Length; l++)
                {
                    if (sr[l] == t[p])
                    {
                        int r = l;
                        for (r = l + 1; ; r++)
                        {
                            if (p + (r - l) >= t.Length || r == sr.Length || sr[r] != t[p + (r - l)])
                            {
                                r--;
                                break;
                            }
                        }
                        if (r - l + 1 > maxLen)
                        {
                            maxLen = r - l + 1;
                            pl = (s.Length - 1) - l;
                            pr = (s.Length - 1) - r;
                        }
                    }
                }
                if (maxLen == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                else
                {
                    answer++;
                    output.Append((pl + 1) + " " + (pr + 1) + "\n");
                    p += maxLen;
                }
            }
            Console.WriteLine(answer);
            Console.Write(output.ToString());
        }
    }
}
