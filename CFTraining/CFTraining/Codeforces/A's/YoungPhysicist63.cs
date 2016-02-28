using System;

namespace CFTraining.A_s
{
    class YoungPhysicist63
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine()), x = 0, y = 0, z = 0;
            while (n-- > 0)
            {
                string[] line = Console.ReadLine().Split(' ');
                x += Convert.ToInt32(line[0]);
                y += Convert.ToInt32(line[1]);
                z += Convert.ToInt32(line[2]);
            }
            Console.WriteLine( (x == 0 && y == 0 && z == 0) ? "YES" : "NO" );
        }
    }
}
