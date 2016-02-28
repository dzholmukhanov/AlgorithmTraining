using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.C_s
{
    class TheLabyrinthECR5
    {
        private static string[] lines;
        private static int n, m, id;
        private static bool[,] visited;
        private static int[,] belongs;
        public static void Run()
        {
            string[] line = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(line[0]);
            m = Convert.ToInt32(line[1]);
            lines = new string[n];
            Dictionary<int, int> componentSizes = new Dictionary<int, int>();
            belongs = new int[n, m];
            visited = new bool[n, m];
            id = 0;

            for (int i = 0; i < n; i++) lines[i] = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (lines[i][j] == '.' && !visited[i, j])
                    {
                        componentSizes[id] = DFS(i, j);
                        id++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (lines[i][j] == '*')
                    {
                        HashSet<int> adjacentComponentIds = new HashSet<int>();
                        if (i > 0 && lines[i - 1][j] == '.') adjacentComponentIds.Add(belongs[i - 1, j]);
                        if (j > 0 && lines[i][j - 1] == '.') adjacentComponentIds.Add(belongs[i, j - 1]);
                        if (i < n - 1 && lines[i + 1][j] == '.') adjacentComponentIds.Add(belongs[i + 1, j]);
                        if (j < m - 1 && lines[i][j + 1] == '.') adjacentComponentIds.Add(belongs[i, j + 1]);
                        int size = 1;
                        foreach (int ID in adjacentComponentIds)
                        {
                            size += componentSizes[ID];
                        }
                        sb.Append(size % 10);
                    }
                    else sb.Append(".");
                }
                sb.Append("\n");
            }
            Console.Write(sb);
        }

        public static int DFS(int i, int j)
        {
            int size = 1;
            visited[i, j] = true;
            belongs[i, j] = id;
            if (i > 0 && !visited[i - 1, j] && lines[i - 1][j] == '.') size += DFS(i - 1, j);
            if (j > 0 && !visited[i, j - 1] && lines[i][j - 1] == '.') size += DFS(i, j - 1);
            if (i < n - 1 && !visited[i + 1, j] && lines[i + 1][j] == '.') size += DFS(i + 1, j);
            if (j < m - 1 && !visited[i, j + 1] && lines[i][j + 1] == '.') size += DFS(i, j + 1);
            return size;
        }
    }
}
