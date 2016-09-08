using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class CaptureValerian57
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int a = fs.NextInt();
                string s1 = fs.NextToken();
                string s2 = new string(fs.ReadLine().Reverse().ToArray());
                long c = 0;
                for (int i = 0; i < s2.Length; i++)
                {
                    if (s2[i] != '0') c += (long)Math.Pow(a, i) * SingleDigitToDecimalBase(s2[i]);
                }
                if (s1 == "R")
                {
                    writer.WriteLine(ToRomanNumeral(c.ToString(), 0));
                }
                else
                {
                    int b = Convert.ToInt32(s1);
                    writer.WriteLine(DecimalToAnyBase(c, b));
                }
            }
        }

        private static string ToRomanNumeral(string num, int i)
        {
            if (i >= num.Length) return "";
            if (num[i] == '0') return ToRomanNumeral(num, i + 1);

            int order = num.Length - i;
            string prefix = "";

            if (num[i] >= '1' && num[i] <= '3')
            {
                for (int j = '1'; j <= num[i]; j++)
                {
                    prefix += GetRomanDigit(true, order);
                }
            }
            else if (num[i] == '4')
            {
                prefix = GetRomanDigit(true, order) + GetRomanDigit(false, order);
            }
            else if (num[i] == '9')
            {
                prefix = GetRomanDigit(true, order) + GetRomanDigit(true, order + 1);
            }
            else
            {
                prefix = GetRomanDigit(false, order);
                for (int j = 1; j <= num[i] - '5'; j++)
                {
                    prefix += GetRomanDigit(true, order);
                }
            }
            return prefix + ToRomanNumeral(num, i + 1);
        }

        private static string GetRomanDigit(bool isDecimalMultiple, int order)
        {
            string[] decimals = new string[] { "I", "X", "C", "M" };
            string[] fives = new string[] { "V", "L", "D" };
            return isDecimalMultiple ? decimals[order - 1] : fives[order - 1];
        }

        private static string DecimalToAnyBase(long dec, int b)
        {
            StringBuilder sb = new StringBuilder();
            do
            {
                sb.Append(DecimalDigitToSingle((int)(dec % b)));
                dec /= b;
            }
            while (dec != 0);
            return new string(sb.ToString().Reverse().ToArray());
        }
        private static int SingleDigitToDecimalBase(char d)
        {
            if (d >= '0' && d <= '9') return d - '0';
            else return d - 'A' + 10;
        }
        private static string DecimalDigitToSingle(int digit)
        {
            if (digit >= 0 && digit <= 9) return ((char)(digit + '0')).ToString();
            else return ((char)(digit + 'A' - 10)).ToString();
        }
    }
}
