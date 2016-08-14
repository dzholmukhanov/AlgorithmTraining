using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.DataStructures
{
    public class BinaryTrie
    {
        public class Node
        {
            public Node Left, Right, Parent;
            public int Level;
            public Node(int level, Node parent)
            {
                Level = level;
                Parent = parent;
            }
        }
        private Node Root;
        private char LeftSymbol, RightSymbol;
        public BinaryTrie(char leftSymbol, char rightSymbol)
        {
            Root = new Node(0, null);
            LeftSymbol = leftSymbol;
            RightSymbol = rightSymbol;
        }
        public void Remove(string path)
        {
            if (String.IsNullOrEmpty(path)) return;
            Node current = Root;
            for (int i = 0; i < path.Length - 1; i++)
            {
                if (path[i] == LeftSymbol) current = current.Left;
                else if (path[i] == RightSymbol) current = current.Right;
                if (current == null) return;
            }
            if (path.Last() == LeftSymbol && current.Left != null)
            {
                current.Left.Parent = null;
                current.Left = null;
            }
            else if (path.Last() == RightSymbol && current.Right != null)
            {
                current.Right.Parent = null;
                current.Right = null;
            }
            while (current.Level != 0 && current.Left == null && current.Right == null)
            {
                current.Level = -1;
                current = current.Parent;
                if (current.Left != null && current.Left.Level == -1)
                {
                    current.Left.Parent = null;
                    current.Left = null;
                }
                else if (current.Right != null && current.Right.Level == -1)
                {
                    current.Right.Parent = null;
                    current.Right = null;
                }
            }
        }

        public void Add(string path)
        {
            if (String.IsNullOrEmpty(path)) return;
            Node current = Root;
            for (int i = 0; i < path.Length - 1; i++)
            {
                if (path[i] == LeftSymbol)
                {
                    if (current.Left == null) current.Left = new Node(current.Level + 1, current);
                    current = current.Left;
                }
                else if (path[i] == RightSymbol)
                {
                    if (current.Right == null) current.Right = new Node(current.Level + 1, current);
                    current = current.Right;
                }
            }
            if (path.Last() == LeftSymbol && current.Left == null)
            {
                current.Left = new Node(current.Level + 1, current);
            }
            else if (path.Last() == RightSymbol && current.Right == null)
            {
                current.Right = new Node(current.Level + 1, current);
            }
        }
        public Node GetRoot()
        {
            return Root;
        }
    }
}
