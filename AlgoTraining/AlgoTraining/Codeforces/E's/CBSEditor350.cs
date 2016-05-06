using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class CBSEditor350
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt(), p = fs.NextInt();
                string str = fs.ReadLine(), cmd = fs.ReadLine();
                MyLinkedList seq = new MyLinkedList();
                Stack<Node> stack = new Stack<Node>();
                for (int i = 0; i < str.Length; i++)
                {
                    seq.Add(new Bracket 
                    { 
                        Index = i, 
                        Type = str[i] == '(' ? BracketType.Opening : BracketType.Closing
                    });
                }
                var curr = seq.First;
                for (var node = seq.First; node != seq.Last.Next; node = node.Next)
                {
                    if (node.Value.Index == p - 1) curr = node;
                    if (node.Value.Type == BracketType.Opening)
                    {
                        stack.Push(node);
                    }
                    else
                    {
                        var pair = stack.Pop();
                        node.Value.Pair = pair;
                        pair.Value.Pair = node;
                    }
                }
                for (int i = 0; i < m; i++)
                {
                    if (cmd[i] == 'L')
                    {
                        curr = curr.Previous;
                    }
                    else if (cmd[i] == 'R')
                    {
                        curr = curr.Next;
                    }
                    else
                    {
                        var start = curr;
                        var end = curr.Value.Pair;
                        if (start.Value.Type == BracketType.Closing) {
                            start = curr.Value.Pair;
                            end = curr;

                        }
                        if (start.Previous != null && end.Next != null)
                        {
                            start.Previous.Next = end.Next;
                            end.Next.Previous = start.Previous;
                            curr = end.Next;
                        }
                        else if (start.Previous == null)
                        {
                            seq.First = end.Next;
                            seq.First.Previous = null;
                            curr = seq.First;
                        }
                        else if (end.Next == null)
                        {
                            seq.Last = start.Previous;
                            seq.Last.Next = null;
                            curr = seq.Last;
                        }
                    }
                }
                for (var node = seq.First; node != seq.Last.Next; node = node.Next)
                {
                    writer.Write(node.Value.Type == BracketType.Opening ? "(" : ")");
                }
            }
        }
    }
    class Bracket
    {
        public int Index;
        public BracketType Type;
        public Node Pair;
    }
    enum BracketType {
        Opening, Closing
    }
    class Node
    {
        public Node Previous, Next;
        public Bracket Value;
    }
    class MyLinkedList
    {
        public Node First, Last;
        public MyLinkedList()
        {

        }
        public void Add(Bracket b)
        {
            Node newNode = new Node { Value = b };
            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                newNode.Previous = Last;
                Last = newNode;
            }
        }
    }
}
