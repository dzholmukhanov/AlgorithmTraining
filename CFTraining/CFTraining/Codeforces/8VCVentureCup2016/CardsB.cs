using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining._8VCVentureCup2016
{
    class CardsB
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), rc = 0, bc = 0, gc = 0;
                string s = fs.ReadLine();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'R') rc++;
                    else if (s[i] == 'G') gc++;
                    else bc++;
                }
                string ans = "";
                if (rc > 0 && bc > 0 && gc > 0) ans = "BGR";
                else if (rc > 0 && gc == 0 && bc == 0) ans = "R";
                else if (gc > 0 && rc == 0 && bc == 0) ans = "G";
                else if (bc > 0 && gc == 0 && rc == 0) ans = "B";
                else if (rc > 1 && bc > 1 || rc > 1 && gc > 1 || gc > 1 && bc > 1) ans = "BGR";
                else if (rc == 1 && gc == 1) ans = "B";
                else if (gc == 1 && bc == 1) ans = "R";
                else if (rc == 1 && bc == 1) ans = "G";
                else if (rc == 0)
                {
                    if (bc == 1) ans = "BR";
                    else if (gc == 1) ans = "GR";
                }
                else if (gc == 0)
                {
                    if (rc == 1) ans = "GR";
                    else if (bc == 1) ans = "BG";
                }
                else if (bc == 0)
                {
                    if (rc == 1) ans = "BR";
                    else if (gc == 1) ans = "BG";
                }
                writer.WriteLine(ans);
            }
        }
    }
}
