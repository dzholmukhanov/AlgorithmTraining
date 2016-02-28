using System;

namespace CFTraining.A_s
{
    class Dubstep130
    {
        public static void Run()
        {
            string dubstep = Console.ReadLine(), original = "";
            bool metWub = false;
            for (int i = 0; i < dubstep.Length; i++)
            {
                if (i + 2 < dubstep.Length && dubstep.Substring(i, 3).Equals("WUB"))
                {
                    metWub = true;
                    i += 2;
                }
                else
                {
                    if (metWub && original.Length > 0) original += " ";
                    original += dubstep[i];
                    metWub = false;
                }
            }
            Console.WriteLine(original);
        }
    }
}
