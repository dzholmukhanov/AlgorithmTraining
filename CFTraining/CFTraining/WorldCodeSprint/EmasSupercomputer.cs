using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.WorldCodeSprint
{
    class EmasSupercomputer
    {
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(line[0]), m = Convert.ToInt32(line[1]);
            bool[,] grid = new bool[n, m];
            List<Plus> pluses = new List<Plus>();
            for (int i = 0; i < n; i++)
            {
                string t = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    grid[i, j] = t[j] == 'G';
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j])
                    {
                        int side = 1;
                        pluses.Add(new Plus { x = j, y = i, side = 0 });
                        while (i - side >= 0 && grid[i - side, j]
                                && i + side < n && grid[i + side, j]
                                && j - side >= 0 && grid[i, j - side]
                                && j + side < m && grid[i, j + side])
                        {
                            pluses.Add(new Plus { x = j, y = i, side = side });
                            side++;
                        }
                    }
                }
            }
            int maxArea = 0;
            for (int i = 0; i < pluses.Count; i++)
            {
                for (int j = i + 1; j < pluses.Count; j++)
                {
                    if (!pluses[i].Crosses(pluses[j])) maxArea = Math.Max(maxArea, pluses[i].GetArea() * pluses[j].GetArea());
                }
            }
            Console.WriteLine(maxArea);
        }
    }
    class Plus
    {
        public int x, y, side;
        public bool Crosses(Plus p)
        {
            int hdif = Math.Abs(p.x - x), vdif = Math.Abs(p.y - y);
            if ((hdif <= side && vdif <= p.side) || (hdif <= p.side && vdif <= side))
            {
                return true;
            }
            else if (x == p.x && ((y - side <= p.y + p.side) || (y + side >= p.y - p.side)))
            {
                return true;
            }
            else if (y == p.y && ((x - side <= p.x + p.side) || (x + side >= p.x - p.side)))
            {
                return true;
            }
            return false;
        }
        public int GetArea()
        {
            return 4 * side + 1;
        }
    }
}
