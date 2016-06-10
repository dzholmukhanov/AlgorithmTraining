using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.E_s
{
    class TrainsAndStatistic353
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] a = new int[n];
                for (int i = 0; i < n - 1; i++)
                {
                    a[i] = fs.NextInt() - 1;
                }
                a[n - 1] = n - 1;
                long[] dp = new long[n];
                MaxSegmentTree tree = new MaxSegmentTree(a);
                long sum = 1;
                dp[n - 2] = 1;
                for (int i = n - 3; i >= 0; i--)
                {
                    int m = tree.QueryMax(i + 1, a[i]);
                    dp[i] = dp[m] - a[i] + m + n - i - 1;
                    sum += dp[i];
                }
                writer.WriteLine(sum);
            }
        }
    }

    class MaxSegmentTree
    {
        class Cell : IComparable<Cell>
        {
            public int Index, Value;

            public int CompareTo(Cell other)
            {
                return Value.CompareTo(other.Value);
            }
        }
        private int[] _original, _lazy;
        private Cell[] _tree;
        private int _size;
        public MaxSegmentTree(int[] a)
        {
            _size = (int)Math.Pow(2, Math.Ceiling(Math.Log(a.Length, 2))) * 2 - 1;
            _original = a.ToArray();
            _tree = new Cell[_size];
            _lazy = Enumerable.Repeat(-1, _size).ToArray();
            Construct(0, _original.Length - 1, 0);
        }
        private void Construct(int l, int r, int pos)
        {
            if (l == r)
            {
                _tree[pos] = new Cell { Index = l, Value = _original[l] };
            }
            else
            {
                int mid = (l + r) / 2, lChild = pos * 2 + 1, rChild = pos * 2 + 2;
                Construct(l, mid, lChild);
                Construct(mid + 1, r, rChild);
                if (_tree[lChild].CompareTo(_tree[rChild]) == 1) _tree[pos] = _tree[lChild];
                else _tree[pos] = _tree[rChild];
            }
        }
        public int QueryMax(int ql, int qr)
        {
            return QueryMax(ql, qr, 0, _original.Length - 1, 0).Index;
        }
        private Cell QueryMax(int ql, int qr, int l, int r, int pos)
        {
            if (l > r) return new Cell { Index = -1, Value = -1 };

            if (_lazy[pos] != -1)
            {
                _tree[pos].Value = _lazy[pos];
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = _lazy[pos];
                    _lazy[pos * 2 + 2] = _lazy[pos];
                }
                _lazy[pos] = -1;
            }

            if (l >= ql && r <= qr) return _tree[pos];
            else if (qr < l || ql > r) return new Cell { Index = -1, Value = -1 };
            else
            {
                int mid = (l + r) / 2;
                Cell left = QueryMax(ql, qr, l, mid, pos * 2 + 1), right = QueryMax(ql, qr, mid + 1, r, pos * 2 + 2);
                if (left.CompareTo(right) == 1) return left;
                else return right;
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
                _tree[pos].Value = _lazy[pos];
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = _lazy[pos];
                    _lazy[pos * 2 + 2] = _lazy[pos];
                }
                _lazy[pos] = -1;
            }

            if (l >= ql && r <= qr)
            {
                _tree[pos].Value = value;
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = value;
                    _lazy[pos * 2 + 2] = value;
                }
            }
            else if (qr < l || ql > r) return;
            else
            {
                int mid = (l + r) / 2, lChild = pos * 2 + 1, rChild = pos * 2 + 2;
                Update(ql, qr, l, mid, lChild, value);
                Update(ql, qr, mid + 1, r, rChild, value);
                if (_tree[lChild].CompareTo(_tree[rChild]) == 1) _tree[pos] = _tree[lChild];
                else _tree[pos] = _tree[rChild];
            }
        }
    }
}
