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
        private int[] Parent, Rank, Count;
        private int TotalSetCount;
        public DisjointSet()
        {
            MaxVal = (int)1e6;
            Parent = Enumerable.Repeat(-1, MaxVal).ToArray();
            Rank = new int[MaxVal];
            Count = new int[MaxVal];
            TotalSetCount = 0;
        }
        public void MakeSet(int x)
        {
            if (Parent[x] == -1)
            {
                Parent[x] = x;
                Rank[x] = 0;
                Count[x] = 1;
                TotalSetCount++;
            }
        }
        public int FindSet(int x)
        {
            if (Parent[x] == -1) return -1;
            else if (Parent[x] == x) return x;
            return Parent[x] = FindSet(Parent[x]);
        }
        public bool Union(int x, int y)
        {
            int xRoot = FindSet(x), yRoot = FindSet(y);
            if (xRoot == -1)
            {
                MakeSet(x);
                xRoot = x;
            }
            if (yRoot == -1)
            {
                MakeSet(y);
                yRoot = y;
            }
            if (xRoot == yRoot) return false;

            if (Rank[xRoot] < Rank[yRoot])
            {
                Parent[xRoot] = yRoot;
                Count[yRoot] += Count[xRoot];
            }
            else if (Rank[xRoot] > Rank[yRoot])
            {
                Parent[yRoot] = xRoot;
                Count[xRoot] += Count[yRoot];
            }
            else
            {
                Parent[xRoot] = yRoot;
                Count[yRoot] += Count[xRoot];
                Rank[yRoot]++;
            }
            TotalSetCount--;
            return true;
        }
        public int GetSetElementCount(int x)
        {
            int xRoot = FindSet(x);
            return xRoot >= 0 ? Count[xRoot] : 0;
        }
        public int GetTotalSetCount()
        {
            return TotalSetCount;
        }
    }
}
