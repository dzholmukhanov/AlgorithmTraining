using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.DataStructures
{
    public class DisjointSet
    {
        private int MaxVal;
        private int[] Parent, Rank;
        private int Count;
        public DisjointSet()
        {
            MaxVal = (int)1e7;
            Parent = new int[MaxVal];
            Rank = new int[MaxVal];
            Count = 0;
        }
        public void MakeSet(int x)
        {
            Parent[x] = x;
            Rank[x] = 0;
            Count++;
        }
        public int FindSet(int x)
        {
            if (Parent[x] == x) return x;
            return Parent[x] = FindSet(Parent[x]);
        }
        public bool Union(int x, int y)
        {
            int xRoot = FindSet(x), yRoot = FindSet(y);
            if (xRoot == yRoot) return false;

            if (Rank[xRoot] < Rank[yRoot])
            {
                Parent[xRoot] = yRoot;
            }
            else if (Rank[xRoot] > Rank[yRoot])
            {
                Parent[yRoot] = xRoot;
            }
            else
            {
                Parent[xRoot] = yRoot;
                Rank[yRoot]++;
            }
            Count--;
            return true;
        }
        public int GetCount()
        {
            return Count;
        }
    }
}
