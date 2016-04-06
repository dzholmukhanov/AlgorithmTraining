using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.F_s
{
    class PolycarpAndHay346
    {
        public static int N, M;
        private static Hay[,] A;
        private static int[,] Answer;
        private static bool[,] Visited;
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                N = fs.NextInt();
                M = fs.NextInt();
                long k = fs.NextLong();
                A = new Hay[N, M];
                Answer = new int[N, M];
                Visited = new bool[N, M];
                List<Hay> hays = new List<Hay>(N * M);
                DisjointSet dsu = new DisjointSet();
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        A[i, j] = new Hay { Id = M * i + j, Row = i, Column = j, Height = fs.NextLong() };
                        hays.Add(A[i, j]);
                    }
                }
                hays = hays.OrderByDescending(h => h.Height).ToList();
                foreach (Hay hay in hays)
                {
                    dsu.MakeSet(hay.Id);
                    if (hay.Row > 0 && hay.Height <= A[hay.Row - 1, hay.Column].Height) dsu.Union(hay.Id, A[hay.Row - 1, hay.Column].Id);
                    if (hay.Column > 0 && hay.Height <= A[hay.Row, hay.Column - 1].Height) dsu.Union(hay.Id, A[hay.Row, hay.Column - 1].Id);
                    if (hay.Row < N - 1 && hay.Height <= A[hay.Row + 1, hay.Column].Height) dsu.Union(hay.Id, A[hay.Row + 1, hay.Column].Id);
                    if (hay.Column < M - 1 && hay.Height <= A[hay.Row, hay.Column + 1].Height) dsu.Union(hay.Id, A[hay.Row, hay.Column + 1].Id);
                    int count = dsu.GetSetElementCount(hay.Id);
                    if (k % hay.Height == 0)
                    {
                        long need = k / hay.Height;
                        int temp = (int)need;
                        if (need <= (long)count)
                        {
                            RunDFS(hay.Row, hay.Column, (int)hay.Height, ref temp);
                            writer.WriteLine("YES");
                            for (int i = 0; i < N; i++)
                            {
                                for (int j = 0; j < M; j++)
                                {
                                    writer.Write(Answer[i, j] + " ");
                                }
                                writer.WriteLine();
                            }
                            return;
                        }
                    }
                }
                writer.WriteLine("NO");
            }
        }

        private static void RunDFS(int i, int j, int value, ref int count)
        {
            if (count == 0) return;
            Visited[i, j] = true;
            Answer[i, j] = value;
            count--;
            if (i > 0 && value <= A[i - 1, j].Height && !Visited[i - 1, j]) RunDFS(i - 1, j, value, ref count);
            if (j > 0 && value <= A[i, j - 1].Height && !Visited[i, j - 1]) RunDFS(i, j - 1, value, ref count);
            if (i < N - 1 && value <= A[i + 1, j].Height && !Visited[i + 1, j]) RunDFS(i + 1, j, value, ref count);
            if (j < M - 1 && value <= A[i, j + 1].Height && !Visited[i, j + 1]) RunDFS(i, j + 1, value, ref count);
        }
    }
    class Hay
    {
        public int Id, Row, Column;
        public long Height;
    }
}
