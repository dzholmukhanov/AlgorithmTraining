using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class RobbersWatch359
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                if (n > 823543 || m > 823543) writer.WriteLine(0);
                else
                {
                    List<string> hours = new List<string>(6000);
                    List<string> minutes = new List<string>(6000);
                    char[] nums = new char[] { '0', '1', '2', '3', '4', '5', '6' };
                    string maxHour = IntToStringFast(n - 1, nums);
                    string maxMinute = IntToStringFast(m - 1, nums);
                    if (maxHour.Length + maxMinute.Length > 7)
                    {
                        writer.WriteLine(0);
                        return;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        StringBuilder sb = new StringBuilder(IntToStringFast(i, nums));
                        while (sb.Length < maxHour.Length) sb.Insert(0, 0);
                        string hour = sb.ToString();
                        if (IsUnique(hour))
                        {
                            hours.Add(hour);
                        }
                    }
                    for (int i = 0; i < m; i++)
                    {
                        StringBuilder sb = new StringBuilder(IntToStringFast(i, nums));
                        while (sb.Length < maxMinute.Length) sb.Insert(0, 0);
                        string minute = sb.ToString();
                        if (IsUnique(minute))
                        {
                            minutes.Add(minute);
                        }
                    }
                    int ans = 0;
                    foreach (string h in hours)
                    {
                        foreach (string min in minutes)
                        {
                            if (AreUnique(h, min))
                            {
                                ans++;
                            }
                        }
                    }
                    writer.WriteLine(ans);
                }
            }
        }

        private static bool AreUnique(string hour, string min)
        {
            bool[] count = new bool[7];
            for (int i = 0; i < hour.Length; i++)
            {
                count[hour[i] - '0'] = true;
            }
            for (int i = 0; i < min.Length; i++)
            {
                if (count[min[i] - '0']) return false;
            }
            return true;
        }

        private static bool IsUnique(string hour)
        {
            bool[] count = new bool[7];
            for (int i = 0; i < hour.Length; i++)
            {
                if (count[hour[i] - '0']) return false;
                else count[hour[i] - '0'] = true;
            }
            return true;
        }
        public static string IntToStringFast(int value, char[] baseChars)
        {
            // 32 is the worst cast buffer size for base 2 and int.MaxValue
            int i = 32;
            char[] buffer = new char[i];
            int targetBase = baseChars.Length;

            do
            {
                buffer[--i] = baseChars[value % targetBase];
                value = value / targetBase;
            }
            while (value > 0);

            char[] result = new char[32 - i];
            Array.Copy(buffer, i, result, 0, 32 - i);

            return new string(result);
        }
    }
}
