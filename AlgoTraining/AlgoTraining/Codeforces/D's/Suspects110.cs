using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class Suspects110
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                int[] a = new int[n];
                int[] accuses = new int[n], defenses = new int[n];
                bool[] isAccusing = new bool[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = fs.NextInt();
                    if (a[i] > 0)
                    {
                        a[i] = a[i] - 1;
                        accuses[a[i]]++;
                        isAccusing[i] = true;
                    }
                    else
                    {
                        a[i] = -a[i] - 1;
                        defenses[a[i]]++;
                        isAccusing[i] = false;
                    }
                }
                bool[] isSuspect = new bool[n];
                int totalAccuses = accuses.Sum(), totalDefenses = defenses.Sum();
                int suspectCount = 0;
                for (int i = 0; i < n; i++)
                {
                    if (accuses[i] + (totalDefenses - defenses[i]) == m)
                    {
                        isSuspect[i] = true;
                        suspectCount++;
                    }
                }
                string[] verdicts = new string[n];
                if (suspectCount == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (isAccusing[i] && isSuspect[a[i]] || !isAccusing[i] && !isSuspect[a[i]]) verdicts[i] = "Truth";
                        else verdicts[i] = "Lie";
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (!isAccusing[i] && !isSuspect[a[i]]) verdicts[i] = "Truth";
                        else if (isAccusing[i] && !isSuspect[a[i]]) verdicts[i] = "Lie";
                        else verdicts[i] = "Not defined";
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    writer.WriteLine(verdicts[i]);
                }
            }
        }
    }
}
