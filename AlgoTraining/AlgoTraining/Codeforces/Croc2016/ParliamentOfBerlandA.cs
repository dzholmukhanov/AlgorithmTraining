using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.Croc2016
{
    class ParliamentOfBerlandA
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), a = fs.NextInt(), b = fs.NextInt();
                bool shouldReverse = b % 2 == 0;
                int[,] hall = new int[a, b];
                if (n <= a * b)
                {
                    for (int i = 0; i < a; i++)
                    {
                        int row = b * i;
                        if (shouldReverse && i % 2 == 1)
                        {
                            for (int j = b - 1; j >= 0; j--)
                            {
                                hall[i, j] = row + b - j;
                                if (hall[i, j] == n)
                                {
                                    i = a;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < b; j++)
                            {
                                hall[i, j] = row + j + 1;
                                if (hall[i, j] == n)
                                {
                                    i = a;
                                    break;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            writer.Write(hall[i, j] + " ");
                        }
                        writer.WriteLine();
                    }
                }
                else
                {
                    writer.WriteLine(-1);
                }
            }
        }
    }
}
