using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class HardWork57
    {
        private static String[] _charsToRemove = new String[] { "-", ";", "_" };

        public static void Run()
        {
            String[] words = new String[] { RemoveSigns(Console.ReadLine().ToLower()), RemoveSigns(Console.ReadLine().ToLower()), RemoveSigns(Console.ReadLine().ToLower())};

            int n = Convert.ToInt32(Console.ReadLine());

            while (n-- > 0)
            {
                String strToCheck = RemoveSigns(Console.ReadLine().ToLower());
                if (strToCheck.Length == words[0].Length + words[1].Length + words[2].Length && strToCheck.Contains(words[0]) && strToCheck.Contains(words[1]) && strToCheck.Contains(words[2]))
                {
                    String[] cases = new String[] {
                        words[0] + words[1] + words[2],
                        words[0] + words[2] + words[1],
                        words[1] + words[0] + words[2],
                        words[1] + words[2] + words[0],
                        words[2] + words[0] + words[1],
                        words[2] + words[1] + words[0],
                    };
                    if (cases.Contains(strToCheck)) Console.WriteLine("ACC");
                    else Console.WriteLine("WA");
                }
                else Console.WriteLine("WA");
            } 
        }

        public static String RemoveSigns(String str)
        {
            foreach (var c in _charsToRemove)
            {
                str = str.Replace(c, String.Empty);
            }
            return str;
        }
    }
}
