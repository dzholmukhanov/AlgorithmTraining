using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class TheBestGiftECR3
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]),
                m = Convert.ToInt32(line[1]);
            int[] genres = new int[m];
            line = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                genres[Convert.ToInt32(line[i]) - 1]++;
            }
            int sum = 0, result = 0;
            for (int i = 0; i < m; i++)
            {
                sum += genres[i];
                result += genres[i] * (n - sum);
            }
            Console.WriteLine(result);
        }
    }
}
