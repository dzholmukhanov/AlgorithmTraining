using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.E_s
{
    class NewYearTreeECR6
    {
        private static int n, m, _index;
        private static LinkedList<int>[] _adjList;
        private static Dictionary<int, int> _vertexToColor;
        private static Dictionary<int, Tuple<int, int>> _vertexToInterval;
        private static long[] _dfsTraverse;

        public static void Run()
        {
            string[] line = Console.ReadLine().Split();
            n = Convert.ToInt32(line[0]);
            m = Convert.ToInt32(line[1]);
            _vertexToColor = new Dictionary<int, int>();
            _vertexToInterval = new Dictionary<int, Tuple<int, int>>();
            _adjList = new LinkedList<int>[n];
            _dfsTraverse = new long[n];
            _index = 0;

            line = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                _vertexToColor.Add(i, Convert.ToInt32(line[i]) - 1);
                _adjList[i] = new LinkedList<int>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                line = Console.ReadLine().Split();
                int u = Convert.ToInt32(line[0]) - 1,
                    v = Convert.ToInt32(line[1]) - 1;
                _adjList[u].AddLast(v);
                _adjList[v].AddLast(u);
            }

            bool[] visited = new bool[n];
            DFS(0, visited);
            SegmentTree tree = new SegmentTree(_dfsTraverse);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                line = Console.ReadLine().Split();
                int t = Convert.ToInt32(line[0]);
                if (t == 1)
                {
                    int v = Convert.ToInt32(line[1]) - 1,
                        k = Convert.ToInt32(line[2]) - 1;
                    Tuple<int, int> temp = _vertexToInterval[v];
                    tree.Update(temp.Item1, temp.Item2, 1L << k);
                }
                else
                {
                    int v = Convert.ToInt32(line[1]) - 1;
                    Tuple<int, int> temp = _vertexToInterval[v];
                    long res = tree.QueryCount(temp.Item1, temp.Item2);
                    sb.Append(CountOnes(Convert.ToString(res, 2)) + "\n");
                }
            }
            Console.WriteLine(sb);
        }

        public static void DFS(int u, bool[] visited)
        {
            int l = _index;
            visited[u] = true;
            _dfsTraverse[_index++] = 1L << _vertexToColor[u];
            foreach (int v in _adjList[u])
            {
                if (!visited[v])
                {
                    DFS(v, visited);
                }
            }
            _vertexToInterval.Add(u, new Tuple<int, int>(l, _index - 1));
        }

        public static int CountOnes(string bin)
        {
            int count = 0;
            foreach (char c in bin)
            {
                if (c == '1') count++;
            }
            return count;
        }
    }
    class SegmentTree
    {
        private long[] _tree, _original, _lazy;
        private int _size;
        public SegmentTree(long[] a)
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
                _tree[pos] = _tree[pos * 2 + 1] | _tree[pos * 2 + 2];
            }
        }
        public long QueryCount(int ql, int qr)
        {
            return QueryCount(ql, qr, 0, _original.Length - 1, 0);
        }
        private long QueryCount(int ql, int qr, int l, int r, int pos)
        {
            if (l > r) return 0L;

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
            else if (qr < l || ql > r) return 0L;
            else
            {
                int mid = (l + r) / 2;
                return QueryCount(ql, qr, l, mid, pos * 2 + 1) | QueryCount(ql, qr, mid + 1, r, pos * 2 + 2);
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
                _tree[pos] = _tree[pos * 2 + 1] | _tree[pos * 2 + 2];
            }
        }
    }
}
