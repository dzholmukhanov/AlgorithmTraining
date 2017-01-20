using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class LuckyNumbers77
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                byte[] a = fs.ReadLine().Select(x => Convert.ToByte(x.ToString())).ToArray();
                if (a.Length % 2 == 1)
                {
                    a = Enumerable.Repeat((byte)4, a.Length + 1).ToArray();
                    AssignTo7FromRight(a, a.Length / 2);
                }
                else
                {
                    int last4 = -1;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] < 4)
                        {
                            AssignTo4FromLeft(a, i);
                            break;
                        }
                        else if (a[i] > 4 && a[i] < 7)
                        {
                            a[i] = 7;
                            AssignTo4FromLeft(a, i + 1);
                            break;
                        }
                        else if (a[i] > 7)
                        {
                            if (last4 == -1)
                            {
                                a = Enumerable.Repeat((byte)4, a.Length + 2).ToArray();
                            }
                            else
                            {
                                a[last4] = 7;
                                AssignTo4FromLeft(a, last4 + 1);
                            }
                            break;
                        }
                        else if (a[i] == 4)
                        {
                            last4 = i;
                        }
                    }
                    int[] sum4 = new int[a.Length];
                    int[] sum7 = new int[a.Length];
                    sum4[0] = a[0] == 4 ? 1 : 0;
                    sum7[0] = a[0] == 7 ? 1 : 0;
                    for (int i = 1; i < a.Length; i++)
                    {
                        sum4[i] = sum4[i - 1] + (a[i] == 4 ? 1 : 0);
                        sum7[i] = sum7[i - 1] + (a[i] == 7 ? 1 : 0);
                    }
                    int count4 = sum4.Last();
                    int count7 = sum7.Last();
                    if (count4 > count7)
                    {
                        AssignTo7FromRight(a, (count4 - count7) / 2);
                    }
                    else if (count7 > count4)
                    {
                        bool found = false;
                        for (int i = a.Length - 1; i >= 0; i--)
                        {
                            if (a[i] == 4)
                            {
                                int tcount4 = (i > 0 ? sum4[i - 1] : 0) + a.Length - i - 1;
                                int tcount7 = (i > 0 ? sum7[i - 1] : 0) + 1;
                                if (tcount4 >= tcount7)
                                {
                                    a[i] = 7;
                                    AssignTo4FromLeft(a, i + 1);
                                    AssignTo7FromRight(a, (tcount4 - tcount7) / 2);
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (!found)
                        {
                            a = Enumerable.Repeat((byte)4, a.Length + 2).ToArray();
                            AssignTo7FromRight(a, a.Length / 2);
                        }
                    }
                }
                writer.WriteLine(string.Join("", a));
            }
        }
        public static void AssignTo4FromLeft(byte[] a, int i)
        {
            for (; i < a.Length; i++)
            {
                a[i] = 4;
            }
        }
        public static void AssignTo7FromRight(byte[] a, int count)
        {
            for (int i = a.Length - 1; i >= 0 && count > 0; i--)
            {
                if (a[i] != 7)
                {
                    a[i] = 7;
                    count--;
                }
            }
        }
        public static void AssignTo4FromRight(byte[] a, int count)
        {
            for (int i = a.Length - 1; i >= 0 && count > 0; i--)
            {
                if (a[i] != 4)
                {
                    a[i] = 4;
                    count--;
                }
            }
        }
    }
}
