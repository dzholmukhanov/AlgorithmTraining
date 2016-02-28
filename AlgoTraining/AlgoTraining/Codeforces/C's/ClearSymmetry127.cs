using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.C_s
{
    class ClearSymmetry127
    {
        public static void Run()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int[] sharpToDim = new int[101]; // x -> n
            sharpToDim[1] = 1;
            sharpToDim[2] = 3;
            sharpToDim[3] = 5;
            sharpToDim[4] = 3;
            sharpToDim[5] = 3;
            for (int i = 6; i < 101; i++) sharpToDim[i] = int.MaxValue;
            int odd = 5, currentX = 6;
            while (currentX <= 100)
            {
                int Sm = Math.Min(((odd / 2) / 2 * 4 + 1) + ((((odd - 1) / 2) * ((odd - 1) / 2))/2 + ((odd - 1)/2)%2) * 4, 100);
                while (currentX <= Sm) sharpToDim[currentX] = Math.Min(sharpToDim[currentX++], odd);
                odd += 2;
            }
            int even = 6;
            currentX = 4;
            while (currentX <= 100)
            {
                int Sm = Math.Min(((((even - 2) / 2) * ((even - 2) / 2)) / 2 + ((even - 2) / 2) % 2) * 4, 100);
                while (currentX <= Sm)
                {
                    sharpToDim[currentX] = Math.Min(sharpToDim[currentX], even);
                    currentX += 4;
                }
                even += 2;
            }
            Console.WriteLine(sharpToDim[x]);
        }
    }
}
