using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class TheseusAndLabyrinth
    {
        private static int n, m;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                n = fs.NextInt();
                m = fs.NextInt();
                char[,] a = new char[n, m];
                int[][,] dist = new int[4][,];
                for (int i = 0; i < 4; i++)
                {
                    dist[i] = new int[n, m];
                }
                for (int i = 0; i < n; i++)
                {
                    string line = fs.ReadLine();
                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = line[j];
                        for (int k = 0; k < 4; k++)
                        {
                            dist[k][i, j] = int.MaxValue;
                        }
                    }
                }
                int xt = fs.NextInt() - 1, yt = fs.NextInt() - 1;
                int xm = fs.NextInt() - 1, ym = fs.NextInt() - 1;
                RunBFS(a, dist, xt, yt);
                int ans = Math.Min(dist[0][xm, ym], Math.Min(dist[1][xm, ym], Math.Min(dist[2][xm, ym], dist[3][xm, ym])));
                writer.WriteLine(ans == int.MaxValue ? -1 : ans);
            }
        }
        private static void RunBFS(char[,] a, int[][,] dist, int i0, int j0) 
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(new Vertex { l = 0, i = i0, j = j0 });
            dist[0][i0, j0] = 0;

            bool[][,] visited = new bool[4][,];
            for (int i = 0; i < 4; i++)
            {
                visited[i] = new bool[n, m];
            }
            visited[0][i0, j0] = true;

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                int d = dist[v.l][v.i, v.j];
                if (!visited[(v.l + 1) % 4][v.i, v.j])
                {
                    queue.Enqueue(new Vertex { l = (v.l + 1) % 4, i = v.i, j = v.j });
                    dist[(v.l + 1) % 4][v.i, v.j] = d + 1;
                    visited[(v.l + 1) % 4][v.i, v.j] = true;
                }
                if (HaveDoors(a, v.i, v.j, 0, v.l) && !visited[v.l][v.i - 1, v.j])
                {
                    queue.Enqueue(new Vertex { l = v.l, i = v.i - 1, j = v.j });
                    dist[v.l][v.i - 1, v.j] = d + 1;
                    visited[v.l][v.i - 1, v.j] = true;
                }
                if (HaveDoors(a, v.i, v.j, 1, v.l) && !visited[v.l][v.i, v.j + 1])
                {
                    queue.Enqueue(new Vertex { l = v.l, i = v.i, j = v.j + 1 });
                    dist[v.l][v.i, v.j + 1] = d + 1;
                    visited[v.l][v.i, v.j + 1] = true;
                }
                if (HaveDoors(a, v.i, v.j, 2, v.l) && !visited[v.l][v.i + 1, v.j])
                {
                    queue.Enqueue(new Vertex { l = v.l, i = v.i + 1, j = v.j });
                    dist[v.l][v.i + 1, v.j] = d + 1;
                    visited[v.l][v.i + 1, v.j] = true;
                }
                if (HaveDoors(a, v.i, v.j, 3, v.l) && !visited[v.l][v.i, v.j - 1])
                {
                    queue.Enqueue(new Vertex { l = v.l, i = v.i, j = v.j - 1 });
                    dist[v.l][v.i, v.j - 1] = d + 1;
                    visited[v.l][v.i, v.j - 1] = true;
                }
            }
        }
        private static char[] door1 = new char[] { '^', '>', 'v', '<' };
        private static char[] door3 = new char[] { 'U', 'R', 'D', 'L' };
        public static char Rotate(char c, int factor)
        {
            if (c == '^' || c == '>' || c == 'v' || c == '<') return door1[(IndexOf(door1, c) + factor) % 4];
            else if (c == 'U' || c == 'R' || c == 'D' || c == 'L') return door3[(IndexOf(door3, c) + factor) % 4];
            else if (c == '-') return factor % 2 == 0 ? '-' : '|';
            else if (c == '|') return factor % 2 == 0 ? '|' : '-';
            else if (c == '+') return '+';
            
            return '*';
        }
        public static bool HaveDoors(char[,] a, int i, int j, int dir, int rotateFactor)
        {
            if (dir == 0 || dir == 2) // up down
            {
                char u, d;
                if (dir == 0)
                {
                    if (i <= 0) return false;
                    u = Rotate(a[i - 1, j], rotateFactor);
                    d = Rotate(a[i, j], rotateFactor);
                }
                else
                {
                    if (i >= a.GetLength(0) - 1) return false;
                    u = Rotate(a[i, j], rotateFactor);
                    d = Rotate(a[i + 1, j], rotateFactor);
                }
                return (u == '+' || u == '|' || u == 'v' || u == 'U' || u == 'R' || u == 'L') && (d == '+' || d == '|' || d == '^' || d == 'D' || d == 'R' || d == 'L');
            }
            else if (dir == 1 || dir == 3) // right left
            {
                char l, r;
                if (dir == 1)
                {
                    if (j >= a.GetLength(1) - 1) return false;
                    l = Rotate(a[i, j], rotateFactor);
                    r = Rotate(a[i, j + 1], rotateFactor);
                }
                else
                {
                    if (j <= 0) return false;
                    l = Rotate(a[i, j - 1], rotateFactor);
                    r = Rotate(a[i, j], rotateFactor);
                }
                return (l == '+' || l == '-' || l == '>' || l == 'U' || l == 'D' || l == 'L') && (r == '+' || r == '-' || r == '<' || r == 'D' || r == 'R' || r == 'U');
            }
            return false;
        }
        public static int IndexOf(char[] a, char c)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == c) return i;
            }
            return -1;
        }
    }
    class Vertex
    {
        public int l, i, j;
    }
}
