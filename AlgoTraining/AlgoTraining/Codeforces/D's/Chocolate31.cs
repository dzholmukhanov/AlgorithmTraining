using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class Chocolate31
    {
        class Node
        {
            public int X, Y;
            public Node Right, Bottom;
        }
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int w = fs.NextInt(), h = fs.NextInt(), n = fs.NextInt();
                Node[,] grid = new Node[h, w];
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        grid[i, j] = new Node { X = j, Y = i };
                    }
                }
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (j < w - 1) grid[i, j].Right = grid[i, j + 1];
                        if (i < h - 1) grid[i, j].Bottom = grid[i + 1, j];
                    }
                }
                while (n-- > 0)
                {
                    int x1 = fs.NextInt(), y1 = h - fs.NextInt();
                    int x2 = fs.NextInt(), y2 = h - fs.NextInt();

                    if (y1 == y2)
                    {
                        if (y1 == 0 || y1 == h) continue;
                        for (int i = Math.Min(x1, x2); i < Math.Max(x1, x2); i++)
                        {
                            grid[y1 - 1, i].Bottom = null;
                        }
                    }
                    else if (x1 == x2)
                    {
                        if (x1 == 0 || x1 == w) continue;
                        for (int i = Math.Min(y1, y2); i < Math.Max(y1, y2); i++)
                        {
                            grid[i, x1 - 1].Right = null;
                        }
                    }
                }
                bool[,] visited = new bool[h, w];
                List<int> sizes = new List<int>();
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (!visited[i, j])
                        {
                            Stack<Node> stack = new Stack<Node>();
                            stack.Push(grid[i, j]);
                            int size = 0;
                            while (stack.Count > 0)
                            {
                                size++;
                                Node current = stack.Pop();
                                visited[current.Y, current.X] = true;
                                if (current.Right != null && !visited[current.Right.Y, current.Right.X]) stack.Push(current.Right);
                                if (current.Bottom != null && !visited[current.Bottom.Y, current.Bottom.X]) stack.Push(current.Bottom);
                            }
                            sizes.Add(size);
                        }
                    }
                }
                sizes = sizes.OrderBy(x => x).ToList();
                foreach (int size in sizes)
                {
                    writer.Write(size + " ");
                }
            }
        }
    }
}
