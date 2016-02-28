using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class NewSkateboardECR8
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                string s = fs.ReadLine();
                long ans = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int d = Convert.ToInt32("" + s[i]);
                    if (i < s.Length - 1)
                    {
                        int dd = Convert.ToInt32("" + s[i] + s[i + 1]);
                        if (dd % 4 == 0) ans += i + 1;
                    }
                    if (d % 4 == 0) ans++;
                }
                writer.WriteLine(ans);
            }
        }
    }
}
