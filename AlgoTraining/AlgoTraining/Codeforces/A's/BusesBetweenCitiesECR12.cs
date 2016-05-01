using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.A_s
{
    class BusesBetweenCitiesECR12
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int fa = fs.NextInt(), ta = fs.NextInt();
                int fb = fs.NextInt(), tb = fs.NextInt();
                string[] time = fs.ReadLine().Split(':');
                int dep = Convert.ToInt32(time[0]) * 60 + Convert.ToInt32(time[1]);
                int arr = dep + ta;
                int t = 300, z = 0;
                while (t < 1440)
                {
                    if ((t >= dep && t < arr) || (t + tb > dep && t + tb <= arr) || (t < dep && t + tb > arr)) z++;
                    t += fb;
                }
                writer.WriteLine(z);
            }
        }
    }
}
