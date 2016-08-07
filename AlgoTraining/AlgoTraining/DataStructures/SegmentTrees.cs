using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.DataStructures
{
    public class MinSegmentTree
    {
        private int[] _original, _tree, _lazy;
        private int _size;
        public MinSegmentTree(int[] a)
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
                _tree[pos] = Math.Min(_tree[pos * 2 + 1], _tree[pos * 2 + 2]);
            }
        }
    }


    public class MaxSegmentTreeWithIndices
    {
        private int[] _original, _tree, _lazy, _inds;
        private int _size;
        public MaxSegmentTreeWithIndices(int[] a)
        {
            _size = (int)Math.Pow(2, Math.Ceiling(Math.Log(a.Length, 2))) * 2 - 1;
            _original = a.ToArray();
            _tree = Enumerable.Repeat(int.MinValue, _size).ToArray();
            _inds = Enumerable.Repeat(-1, _size).ToArray();
            _lazy = Enumerable.Repeat(0, _size).ToArray();
            Construct(0, _original.Length - 1, 0);
        }
        private void Construct(int l, int r, int pos)
        {
            if (l == r)
            {
                _tree[pos] = _original[l];
                _inds[pos] = l;
            }
            else
            {
                int mid = (l + r) / 2;
                Construct(l, mid, pos * 2 + 1);
                Construct(mid + 1, r, pos * 2 + 2);
                if (_tree[pos * 2 + 1] > _tree[pos * 2 + 2])
                {
                    _tree[pos] = _tree[pos * 2 + 1];
                    _inds[pos] = _inds[pos * 2 + 1];
                }
                else
                {
                    _tree[pos] = _tree[pos * 2 + 2];
                    _inds[pos] = _inds[pos * 2 + 2];
                }
            }
        }
        public int QueryMax(int ql, int qr, ref int index)
        {
            return QueryMax(ql, qr, 0, _original.Length - 1, 0, ref index);
        }
        public int QueryMax(ref int index)
        {
            return QueryMax(0, _original.Length - 1, 0, _original.Length - 1, 0, ref index);
        }
        private int QueryMax(int ql, int qr, int l, int r, int pos, ref int index)
        {
            if (l > r) return int.MinValue;

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
                index = _inds[pos];
                return _tree[pos];
            }
            else if (qr < l || ql > r) return int.MinValue;
            else
            {
                int mid = (l + r) / 2, i1 = -1, i2 = -1;
                int q1 = QueryMax(ql, qr, l, mid, pos * 2 + 1, ref i1);
                int q2 = QueryMax(ql, qr, mid + 1, r, pos * 2 + 2, ref i2);
                if (q1 > q2)
                {
                    index = i1;
                    return q1;
                }
                else 
                {
                    index = i2;
                    return q2;
                }
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

                if (_tree[pos * 2 + 1] > _tree[pos * 2 + 2])
                {
                    _tree[pos] = _tree[pos * 2 + 1];
                    _inds[pos] = _inds[pos * 2 + 1];
                }
                else
                {
                    _tree[pos] = _tree[pos * 2 + 2];
                    _inds[pos] = _inds[pos * 2 + 2];
                }
            }
        }
    }


    public class XorSegmentTreeFast
    {
        private int[] _original, _tree;
        private int _size;
        public XorSegmentTreeFast(int[] a)
        {
            _size = a.Length << 2;
            _original = a.ToArray();
            _tree = Enumerable.Repeat(0, _size).ToArray();
            Construct(0, _original.Length - 1, 0);
        }
        private void Construct(int l, int r, int pos)
        {
            if (l == r) _tree[pos] = _original[l];
            else
            {
                int mid = (l + r) >> 1;
                Construct(l, mid, (pos << 1) + 1);
                Construct(mid + 1, r, (pos << 1) + 2);
                _tree[pos] = _tree[(pos << 1) + 1] ^ _tree[(pos << 1) + 2];
            }
        }
        public int QueryXor(int ql, int qr)
        {
            int res = 0;
            Stack<Tuple<int, int, int>> stack = new Stack<Tuple<int, int, int>>();
            stack.Push(new Tuple<int, int, int>(0, _original.Length - 1, 0));
            while (stack.Count > 0)
            {
                var t = stack.Pop();
                int l = t.Item1, r = t.Item2, pos = t.Item3;
                int mid = (l + r) >> 1;
                if (l >= ql && mid <= qr) // total overlap
                {
                    res ^= _tree[(pos << 1) + 1];
                }
                else if (qr >= l && ql <= mid) // partial overlap
                {
                    stack.Push(new Tuple<int, int, int>(l, mid, (pos << 1) + 1));
                }
                if (mid + 1 >= ql && r <= qr) // total overlap
                {
                    res ^= _tree[(pos << 1) + 2];
                }
                else if (qr >= mid + 1 && ql <= r) // partial overlap
                {
                    stack.Push(new Tuple<int, int, int>(mid + 1, r, (pos << 1) + 2));
                }
            }
            return res;
        }
        public void Update(int index, int value)
        {
            int l = 0, r = _original.Length - 1, pos = 0;
            while (l < r)
            {
                int mid = (l + r) >> 1;
                if (index <= mid)
                {
                    r = mid;
                    pos = (pos << 1) + 1;
                }
                else
                {
                    l = mid + 1;
                    pos = (pos << 1) + 2;
                }
            }
            _tree[pos] = value;
            while (pos > 0)
            {
                pos = (pos - 1) >> 1;
                _tree[pos] = _tree[(pos << 1) + 1] ^ _tree[(pos << 1) + 2];
            }
        }
    }
}
