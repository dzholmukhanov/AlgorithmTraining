using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Test
{
    class MaxSegmentTreeTest
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = 100;
                int[] a = new int[n];
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                {
                    a[i] = rand.Next();
                    writer.Write(a[i] + " ");
                }
                writer.WriteLine();
                SegmentTree tree = new SegmentTree(a);
                bool isEqual = true;
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        int aa = tree.QueryMax(i, j), bb = FindMax(a, i, j);
                        writer.WriteLine(aa + " " + bb);
                        if (aa != bb) isEqual = false;
                    }
                }
                writer.WriteLine(isEqual);
            }
        }
        public static int FindMax(int[] a, int l, int r)
        {
            int max = a[l];
            for (int i = l + 1; i <= r && i < a.Length; i++)
            {
                max = Math.Max(max, a[i]);
            }
            return max;
        }
    }

    class SegmentTree
    {
        private int[] _original, _tree, _lazy;
        private int _size;
        public SegmentTree(int[] a)
        {
            _size = (int)Math.Pow(2, Math.Ceiling(Math.Log(a.Length, 2))) * 2 - 1;
            _original = a.ToArray();
            _tree = Enumerable.Repeat(-1, _size).ToArray();
            _lazy = Enumerable.Repeat(-1, _size).ToArray();
            Construct(0, _original.Length - 1, 0);
        }
        private void Construct(int l, int r, int pos)
        {
            if (l == r) _tree[pos] = _original[l];
            else
            {
                int mid = (l + r) / 2;
                Construct(l, mid, pos * 2 + 1);
                Construct(mid + 1, r, pos * 2 + 2);
                _tree[pos] = Math.Max(_tree[pos * 2 + 1], _tree[pos * 2 + 2]);
            }
        }
        public int QueryMax(int ql, int qr)
        {
            return QueryMax(ql, qr, 0, _original.Length - 1, 0);
        }
        private int QueryMax(int ql, int qr, int l, int r, int pos)
        {
            if (l > r) return int.MaxValue;

            if (_lazy[pos] != -1)
            {
                _tree[pos] = _lazy[pos];
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = _lazy[pos];
                    _lazy[pos * 2 + 2] = _lazy[pos];
                }
                _lazy[pos] = -1;
            }

            if (l >= ql && r <= qr) return _tree[pos];
            else if (qr < l || ql > r) return -1;
            else
            {
                int mid = (l + r) / 2;
                return Math.Max(QueryMax(ql, qr, l, mid, pos * 2 + 1), QueryMax(ql, qr, mid + 1, r, pos * 2 + 2));
            }
        }
        public void Update(int ql, int qr, int value)
        {
            Update(ql, qr, 0, _original.Length - 1, 0, value);
        }
        private void Update(int ql, int qr, int l, int r, int pos, int value)
        {
            if (l > r) return;

            if (_lazy[pos] != -1)
            {
                _tree[pos] = _lazy[pos];
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = _lazy[pos];
                    _lazy[pos * 2 + 2] = _lazy[pos];
                }
                _lazy[pos] = -1;
            }

            if (l >= ql && r <= qr)
            {
                _tree[pos] = value;
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = value;
                    _lazy[pos * 2 + 2] = value;
                }
            }
            else if (qr < l || ql > r) return;
            else
            {
                int mid = (l + r) / 2;
                Update(ql, qr, l, mid, pos * 2 + 1, value);
                Update(ql, qr, mid + 1, r, pos * 2 + 2, value);
                _tree[pos] = Math.Max(_tree[pos * 2 + 1], _tree[pos * 2 + 2]);
            }
        }
    }
}
