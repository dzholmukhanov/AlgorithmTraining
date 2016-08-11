using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class Thor366
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), q = fs.NextInt();
                LinkedList<int>[] apps = new LinkedList<int>[n];
                SumSegmentTree seg = new SumSegmentTree(new int[q]);
                for (int i = 0; i < n; i++)
			    {
			        apps[i] = new LinkedList<int>();
			    }
                int last = 0, j = 0;
                for (int i = 0; i < q; i++)
                {
                    int t = fs.NextInt(), x = fs.NextInt();
                    if (t == 1)
                    {
                        x--;
                        apps[x].AddLast(j);
                        seg.Update(j, j, 1);
                        j++;
                    }
                    else if (t == 2)
                    {
                        x--;
                        foreach (int notif in apps[x])
                        {
                            seg.Update(notif, notif, 0);
                        }
                        apps[x].Clear();
                    }
                    else
                    {
                        if (x > last)
                        {
                            last = x;
                            seg.Update(0, x - 1, 0);
                        }
                    }
                    writer.WriteLine(seg.QuerySum(0, q - 1));
                    writer.Flush();
                }
            }
        }
        public class SumSegmentTree
        {
            private int[] _original, _tree, _lazy;
            private int _size;
            public SumSegmentTree(int[] a)
            {
                _size = a.Length << 2;
                _original = a.ToArray();
                _tree = Enumerable.Repeat(0, _size).ToArray();
                _lazy = Enumerable.Repeat(0, _size).ToArray();
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
                    _tree[pos] = _tree[(pos << 1) + 1] + _tree[(pos << 1) + 2];
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
                        _lazy[(pos << 1) + 1] = _lazy[pos];
                        _lazy[(pos << 1) + 2] = _lazy[pos];
                    }
                    _lazy[pos] = -1;
                }

                if (l >= ql && r <= qr) return _tree[pos];
                else if (qr < l || ql > r) return 0;
                else
                {
                    int mid = (l + r) >> 1;
                    return QuerySum(ql, qr, l, mid, (pos << 1) + 1) + QuerySum(ql, qr, mid + 1, r, (pos << 1) + 2);
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
                        _lazy[(pos << 1) + 1] = _lazy[pos];
                        _lazy[(pos << 1) + 2] = _lazy[pos];
                    }
                    _lazy[pos] = -1;
                }

                if (l >= ql && r <= qr)
                {
                    _tree[pos] = value;
                    if (l != r)
                    {
                        _lazy[(pos << 1) + 1] = value;
                        _lazy[(pos << 1) + 2] = value;
                    }
                }
                else if (qr < l || ql > r) return;
                else
                {
                    int mid = (l + r) >> 1;
                    Update(ql, qr, l, mid, (pos << 1) + 1, value);
                    Update(ql, qr, mid + 1, r, (pos << 1) + 2, value);
                    _tree[pos] = _tree[(pos << 1) + 1] + _tree[(pos << 1) + 2];
                }
            }
        }
    }
}
