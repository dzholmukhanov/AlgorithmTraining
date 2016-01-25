using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.DataStructures
{
    /*
     *      Finds the minimum value between an interval [L..R]
     *      Uses lazy propagation
     * 
     */
    class SegmentTree
    {
        private int[] _original, _tree, _lazy;
        private int _size;
        public SegmentTree(int[] a)
        {
            _size = (int)Math.Pow(2, Math.Ceiling(Math.Log(a.Length, 2))) * 2 - 1;
            _original = a.ToArray();
            _tree = Enumerable.Repeat(int.MaxValue, _size).ToArray();
            _lazy = Enumerable.Repeat(0, _size).ToArray();
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
                _tree[pos] = Math.Min(_tree[pos * 2 + 1], _tree[pos * 2 + 2]);
            }
        }
        public int QueryMin(int ql, int qr)
        {
            return QueryMin(ql, qr, 0, _original.Length - 1, 0);
        }
        private int QueryMin(int ql, int qr, int l, int r, int pos)
        {
            if (l > r) return int.MaxValue;

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
            else if (qr < l || ql > r) return int.MaxValue;
            else
            {
                int mid = (l + r) / 2;
                return Math.Min(QueryMin(ql, qr, l, mid, pos * 2 + 1), QueryMin(ql, qr, mid + 1, r, pos * 2 + 2));
            }
        }
        public void Update(int ql, int qr, int value)
        {
            Update(ql, qr, 0, _original.Length - 1, 0, value);
        }
        private void Update(int ql, int qr, int l, int r, int pos, int value)
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
                _tree[pos] = Math.Min(_tree[pos * 2 + 1], _tree[pos * 2 + 1]);
            }
        }
    }
}
