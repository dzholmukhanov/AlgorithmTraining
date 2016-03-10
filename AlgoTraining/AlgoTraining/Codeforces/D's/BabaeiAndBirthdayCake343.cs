using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class BabaeiAndBirthdayCake343
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                int[] indices = new int[n];
                long[] a = new long[n], b = new long[n];
                for (int i = 0; i < n; i++)
                {
                    int r = fs.NextInt(), h = fs.NextInt();
                    a[i] = (long)r * r * h;
                    indices[i] = i;
                }
                Array.Copy(a, b, n);
                Array.Sort(b);
                for (int i = 0; i < n; i++)
                {
                    indices[i] = findValue(b, 0, n - 1, a[i]);
                }
                MaxSegmentTree tree = new MaxSegmentTree(new long[n]);
                for (int i = 0; i < n; i++)
                {
                    int index = indices[i];
                    long value = tree.QueryMax(0, indices[i] - 1) + a[i];
                    tree.Update(indices[i], indices[i], value);
                }
                writer.WriteLine(tree.QueryMax(0, n - 1) * Math.PI);
            }
        }
        public static int findValue(long[] a, int l, int r, long val)
        {
            if (l > r) return -1;
            int m = (l + r) / 2;
            if (a[m] < val) return findValue(a, m + 1, r, val);
            else if (a[m] > val) return findValue(a, l, m - 1, val);
            else return m;
        } 
    }
    class MaxSegmentTree
    {
        private long[] _original, _tree, _lazy;
        private int _size;
        public MaxSegmentTree(long[] a)
        {
            _size = (int)Math.Pow(2, Math.Ceiling(Math.Log(a.Length, 2))) * 2 - 1;
            _original = a.ToArray();
            _tree = Enumerable.Repeat(0L, _size).ToArray();
            _lazy = Enumerable.Repeat(0L, _size).ToArray();
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
        public long QueryMax(int ql, int qr)
        {
            return QueryMax(ql, qr, 0, _original.Length - 1, 0);
        }
        private long QueryMax(int ql, int qr, int l, int r, int pos)
        {
            if (l > r) return 0;

            if (_lazy[pos] != 0)
            {
                _tree[pos] = _lazy[pos];
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = _lazy[pos];
                    _lazy[pos * 2 + 2] = _lazy[pos];
                }
                _lazy[pos] = 0;
            }

            if (l >= ql && r <= qr) return _tree[pos];
            else if (qr < l || ql > r) return 0;
            else
            {
                int mid = (l + r) / 2;
                return Math.Max(QueryMax(ql, qr, l, mid, pos * 2 + 1), QueryMax(ql, qr, mid + 1, r, pos * 2 + 2));
            }
        }
        public void Update(int ql, int qr, long value)
        {
            Update(ql, qr, 0, _original.Length - 1, 0, value);
        }
        private void Update(int ql, int qr, int l, int r, int pos, long value)
        {
            if (l > r) return;

            if (_lazy[pos] != 0)
            {
                _tree[pos] = _lazy[pos];
                if (l != r)
                {
                    _lazy[pos * 2 + 1] = _lazy[pos];
                    _lazy[pos * 2 + 2] = _lazy[pos];
                }
                _lazy[pos] = 0;
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
                _tree[pos] = Math.Max(_tree[pos * 2 + 1], _tree[pos * 2 + 1]);
            }
        }
    }
}
