using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class BabaeiAndBirthdayCake2343
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                double[] vols = new double[n];
                int[] inds = new int[n];
                MaxSegmentTree tree = new MaxSegmentTree(new double[n]);
                for (int i = 0; i < n; i++)
                {
                    inds[i] = i;
                    double r = fs.NextInt(), h = fs.NextInt();
                    vols[i] = r * r * h;
                }
                Array.Sort(vols, inds);
                List<Update> list = new List<Update>();
                for (int i = 0; i < n; i++)
                {
                    if (i > 0 && vols[i] != vols[i - 1])
                    {
                        foreach (Update u in list)
                        {
                            tree.Update(u.Index, u.Index, u.Value);
                        }
                        list.Clear();
                    }
                    int index = inds[i];
                    double value = inds[i] == 0 ? vols[i] : tree.QueryMax(0, inds[i] - 1) + vols[i];
                    list.Add(new Update { Index = index, Value = value });
                }
                foreach (Update u in list)
                {
                    tree.Update(u.Index, u.Index, u.Value);
                }
                writer.WriteLine((tree.QueryMax(0, n - 1) * Math.PI).ToString().Replace(",", "."));
            }
        }
        class Update
        {
            public int Index;
            public double Value;
        }
        class MaxSegmentTree
        {
            private double[] _original, _tree, _lazy;
            private int _size;
            public MaxSegmentTree(double[] a)
            {
                _size = (int)Math.Pow(2, Math.Ceiling(Math.Log(a.Length, 2))) * 2 - 1;
                _original = a.ToArray();
                _tree = Enumerable.Repeat(double.MinValue, _size).ToArray();
                _lazy = Enumerable.Repeat(0.0, _size).ToArray();
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
            public double QueryMax(int ql, int qr)
            {
                return QueryMax(ql, qr, 0, _original.Length - 1, 0);
            }
            private double QueryMax(int ql, int qr, int l, int r, int pos)
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

                if (l >= ql && r <= qr) return _tree[pos];
                else if (qr < l || ql > r) return double.MinValue;
                else
                {
                    int mid = (l + r) / 2;
                    return Math.Max(QueryMax(ql, qr, l, mid, pos * 2 + 1), QueryMax(ql, qr, mid + 1, r, pos * 2 + 2));
                }
            }
            public void Update(int ql, int qr, double value)
            {
                Update(ql, qr, 0, _original.Length - 1, 0, value);
            }
            private void Update(int ql, int qr, int l, int r, int pos, double value)
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
                    _tree[pos] = Math.Max(_tree[pos * 2 + 1], _tree[pos * 2 + 2]);
                }
            }
        }
    }
}
