using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class NestedSegmentsECR10
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                Segment[] segms = new Segment[n];
                int[] ans = new int[n];
                for (int i = 0; i < n; i++)
                {
                    segms[i] = new Segment { Id = i, Left = fs.NextInt(), Right = fs.NextInt() };
                }
                segms = segms.OrderBy(s => s.Left).ToArray();
                Segment[] t = segms.OrderBy(s => s.Right).ToArray();
                int[] ind = new int[n];
                for (int i = 0; i < n; i++)
                {
                    ind[i] = findItem(t, 0, n - 1, segms[i].Right);
                }
                SegmentTree tree = new SegmentTree(new int[n]);
                for (int i = n - 1; i >= 0; i--)
                {
                    ans[segms[i].Id] = tree.QuerySum(0, ind[i] - 1);
                    tree.Update(ind[i], ind[i], 1);
                }
                for (int i = 0; i < n; i++)
                {
                    writer.WriteLine(ans[i]);
                }
            }
        }

        private static int findItem(Segment[] s, int l, int r, int i)
        {
            if (l > r) return -1;
            int mid = (r + l) / 2;
            if (s[mid].Right < i) return findItem(s, mid + 1, r, i);
            else if (s[mid].Right > i) return findItem(s, 0, mid - 1, i);
            else return mid;
        }
    }
    class Segment
    {
        public int Id, Left, Right;
    }

    class SegmentTree
    {
        private int[] _original, _tree, _lazy;
        private int _size;
        public SegmentTree(int[] a)
        {
            _size = (int)Math.Pow(2, Math.Ceiling(Math.Log(a.Length, 2))) * 2 - 1;
            _original = a.ToArray();
            _tree = Enumerable.Repeat(0, _size).ToArray();
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
                _tree[pos] = _tree[pos * 2 + 1] + _tree[pos * 2 + 2];
            }
        }
        public int QuerySum(int ql, int qr)
        {
            return QuerySum(ql, qr, 0, _original.Length - 1, 0);
        }
        private int QuerySum(int ql, int qr, int l, int r, int pos)
        {
            if (l > r) return 0;

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
            else if (qr < l || ql > r) return 0;
            else
            {
                int mid = (l + r) / 2;
                return QuerySum(ql, qr, l, mid, pos * 2 + 1) + QuerySum(ql, qr, mid + 1, r, pos * 2 + 2);
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
                _tree[pos] = _tree[pos * 2 + 1] + _tree[pos * 2 + 2];
            }
        }
    }
}