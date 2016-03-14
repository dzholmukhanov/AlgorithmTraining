using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.VkCup2016
{
    class PhotoLikesA
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), maxLikes = 0, maxIndex = 0;
                int[] likes = new int[(int)1e6];
                for (int i = 0; i < n; i++)
                {
                    int index = fs.NextInt() - 1;
                    likes[index]++;
                    if (likes[index] > maxLikes)
                    {
                        maxLikes = likes[index];
                        maxIndex = index + 1;
                    }
                }
                writer.WriteLine(maxIndex);
            }
        }
    }
}
