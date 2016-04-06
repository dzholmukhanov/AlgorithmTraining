using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.AprilFool2016
{
    class YouAreProfessionalG
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                try
                {
                    int F = fs.NextInt(), I = fs.NextInt(), T = fs.NextInt();
                    int[] likes = new int[I];
                    if (F <= 10 && F >= 1 && I <= 10 && I >= 1 && T <= F && T >= 1)
                    {
                        for (int i = 0; i < F; i++)
                        {
                            string str = fs.ReadLine();
                            if (str.Length != I)
                            {
                                writer.WriteLine(0);
                                return;
                            }
                            for (int j = 0; j < I; j++)
                            {
                                if (str[j] == 'Y') likes[j]++;
                                else if (str[j] != 'Y' && str[j] != 'N')
                                {
                                    writer.WriteLine(0);
                                    return;
                                }
                            }
                        }
                        if (!String.IsNullOrEmpty(fs.ReadLine()))
                        {
                            writer.WriteLine(0);
                            return;
                        }
                        int ans = 0;
                        for (int i = 0; i < I; i++)
                        {
                            if (likes[i] >= T) ans++;
                        }
                        writer.WriteLine(ans);
                    }
                    else writer.WriteLine(0);
                }
                catch (Exception e)
                {
                    writer.WriteLine(0);
                    return;
                }
            }
        }
    }
}
