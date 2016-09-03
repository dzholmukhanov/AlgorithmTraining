using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class TwoSets268
    {
        public class Node
        {
            public int Value;
            public Node Adiff, Bdiff;
        }
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), a = fs.NextInt(), b = fs.NextInt();
                int[] p = new int[n];
                Dictionary<int, int> pos = new Dictionary<int, int>();
                Node[] nodes = new Node[n];
                for (int i = 0; i < n; i++)
                {
                    p[i] = fs.NextInt();
                    nodes[i] = new Node { Value = p[i] };
                    pos.Add(p[i], i);
                }
                for (int i = 0; i < n; i++)
                {
                    int adiff = a - nodes[i].Value;
                    int bdiff = b - nodes[i].Value;
                    if (pos.ContainsKey(adiff))
                    {
                        nodes[i].Adiff = nodes[pos[adiff]];
                        nodes[pos[adiff]].Adiff = nodes[i];
                    }
                    if (pos.ContainsKey(bdiff) && a != b)
                    {
                        nodes[i].Bdiff = nodes[pos[bdiff]];
                        nodes[pos[bdiff]].Bdiff = nodes[i];
                    }
                }

                int[] ans = Enumerable.Repeat(-1, n).ToArray();
                for (int i = 0; i < n; i++)
			    {
                    Node current = nodes[i];
                    if (!Traverse(nodes, current, pos, ans))
                    {
                        writer.WriteLine("NO");
                        return;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    Node current = nodes[i];
                    if (current.Adiff == current || current.Bdiff == current)
                    {
                        if (current.Adiff == current && current.Bdiff == null) ans[i] = 0;
                        else if (current.Adiff == current && current.Bdiff != null) current.Adiff = null;
                        else if (current.Bdiff == current && current.Adiff == null) ans[i] = 1;
                        else if (current.Bdiff == current && current.Adiff != null) current.Bdiff = null;
                    }
                    Traverse(nodes, current, pos, ans);
                }
                writer.WriteLine("YES");
                for (int i = 0; i < n; i++)
                {
                    writer.Write(ans[i] + " ");
                }
            }
        }
        public static bool Traverse(Node[] nodes, Node current, Dictionary<int, int> pos, int[] ans)
        {
            while (current != null && ans[pos[current.Value]] == -1 && (current.Adiff == null || current.Bdiff == null))
            {
                if (current.Adiff == null && current.Bdiff == null)
                {
                    return false;
                }
                else if (current.Adiff != null)
                {
                    ans[pos[current.Value]] = 0;
                    ans[pos[current.Adiff.Value]] = 0;
                    if (current.Adiff.Bdiff != null) current.Adiff.Bdiff.Bdiff = null;
                    current = current.Adiff.Bdiff;
                }
                else if (current.Bdiff != null)
                {
                    ans[pos[current.Value]] = 1;
                    ans[pos[current.Bdiff.Value]] = 1;
                    if (current.Bdiff.Adiff != null) current.Bdiff.Adiff.Adiff = null;
                    current = current.Bdiff.Adiff;
                }
            }
            return true;
        }
    }
}
