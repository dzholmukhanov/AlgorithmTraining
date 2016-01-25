using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.A_s
{
    class SaitamaDestroysHotel336
    {
        public static void Run() {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]),
                s = Convert.ToInt32(line[1]);
            Dictionary<int, List<int>> passengers = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                int f = Convert.ToInt32(line[0]),
                    t = Convert.ToInt32(line[1]);
                if (!passengers.ContainsKey(f)) passengers[f] = new List<int>();
                passengers[f].Add(t);
            }
            int time = 0;
            for (int i = s; i > 0; i--)
            {
                if (passengers.ContainsKey(i))
                {
                    List<int> passengersOnTheFloor = passengers[i];
                    int diff = passengersOnTheFloor.Max() - time;
                    time += diff > 0 ? diff : 0;
                }
                time++;
            }
            Console.WriteLine(time);
        }
    }
}
