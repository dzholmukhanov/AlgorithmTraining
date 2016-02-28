using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.AimTech
{
    class ProblemC
    {
        public static void Run()
        {
            ConsoleScanner cs = new ConsoleScanner();
            int n = cs.NextInt(), m = cs.NextInt(), acount = 0, bcount = 0, ccount = 0;
            int[,] graph = new int[n, n];
            char[] letter = Enumerable.Repeat(' ', n).ToArray();
            LinkedList<int> nodes = new LinkedList<int>();
            for (int i = 0; i < n; i++) nodes.AddLast(i);
            for (int i = 0; i < m; i++)
            {
                int u = cs.NextInt() - 1, v = cs.NextInt() - 1;
                graph[u, v] = 1;
                graph[v, u] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                int adj = 0;
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, j] == 1) adj++;
                }
                if (adj == n - 1)
                {
                    nodes.Remove(i);
                    letter[i] = 'b';
                    bcount++;
                }
            }
            if (nodes.Count != 0)
            {
                int a = nodes.First();
                nodes.RemoveFirst();
                letter[a] = 'a';
                acount++;
                for (int i = 0; i < n; i++)
                {
                    if (graph[a, i] == 1 && letter[i] == ' ')
                    {
                        letter[i] = 'a';
                        nodes.Remove(i);
                        acount++;
                    }
                }
                if (nodes.Count != 0)
                {
                    int c = nodes.First();
                    nodes.RemoveFirst();
                    letter[c] = 'c';
                    ccount++;
                    for (int i = 0; i < n; i++)
                    {
                        if (graph[c, i] == 1)
                        {
                            if (letter[i] == ' ')
                            {
                                letter[i] = 'c';
                                nodes.Remove(i);
                                ccount++;
                            }
                            else if (letter[i] == ' ')
                            {
                                Console.WriteLine("No");
                                return;
                            }
                        }
                    }
                    if (nodes.Count > 0)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        if (letter[i] == 'b') continue;
                        int adj = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (graph[i, j] == 1)
                            {
                                if (letter[j] != 'b')
                                {
                                    if (letter[i] != letter[j])
                                    {
                                        Console.WriteLine("No");
                                        return;
                                    }
                                    else adj++;
                                }
                            }
                        }
                        if ((letter[i] == 'a' && adj < acount - 1) || (letter[i] == 'c' && adj < ccount - 1))
                        {
                            Console.WriteLine("No");
                            return;
                        } 
                    }
                }
            }
            Console.WriteLine("Yes");
            for (int i = 0; i < n; i++) Console.Write(letter[i]);
        }
    }
}
