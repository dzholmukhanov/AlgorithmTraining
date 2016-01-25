using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFTraining.C_s
{
    class ReplaceToMakeRegularBracketSequenceECR4
    {
        public static void Run()
        {
            string str = Console.ReadLine();
            if (str.Length % 2 == 0 && isValid(str))
            {
                Stack<Node> nodeStack = new Stack<Node>();
                Node root = new Node { opening = '(', closing = ')' };
                nodeStack.Push(root);
                int ans = 0;
                foreach (char c in str)
                {
                    if (isOpening(c))
                    {
                        Node child = new Node { opening = c };
                        nodeStack.Push(child);
                    }
                    else
                    {
                        Node node = nodeStack.Pop();
                        node.closing = c;
                        if (!areOfSameKind(node.opening, node.closing)) ans++;
                    }
                }
                Console.WriteLine(ans);
            }
            else Console.WriteLine("Impossible");
        }
        public static bool isValid(string str)
        {
            int opening = 0, closing = 0;
            foreach (char c in str)
            {
                if (isOpening(c))
                {
                    opening++;
                }
                else if (isClosing(c))
                {
                    closing++;
                    if (closing > opening) return false;
                }
                else return false;
            }
            return opening == closing;
        }
        public static bool isOpening(char c)
        {
            return c == '<' || c == '[' || c == '(' || c == '{';
        }
        public static bool isClosing(char c)
        {
            return c == '>' || c == ']' || c == ')' || c == '}';
        }
        public static bool areOfSameKind(char a, char b)
        {
            return  ((a == '<' || a == '>') && (b == '<' || b == '>')) ||
                    ((a == '(' || a == ')') && (b == '(' || b == ')')) ||
                    ((a == '{' || a == '}') && (b == '{' || b == '}')) ||
                    ((a == '[' || a == ']') && (b == '[' || b == ']'));
        }
    }
    class Node
    {
        public char opening {get; set;}
        public char closing {get; set;}
    }
}
