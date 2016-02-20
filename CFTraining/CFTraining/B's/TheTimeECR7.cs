using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.B_s
{
    class TheTimeECR7
    {
        public static void Run()
        {
            string[] time = Console.ReadLine().Split(':');
            int hours = Convert.ToInt32(time[0]), minutes = Convert.ToInt32(time[1]);
            int passed = Convert.ToInt32(Console.ReadLine());
            hours = (hours + (minutes + passed) / 60) % 24;
            minutes = (minutes + passed) % 60;
            Console.WriteLine(hours.ToString("00") + ":" + minutes.ToString("00"));
        }
    }
}
