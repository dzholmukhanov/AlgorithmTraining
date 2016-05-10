using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.DataStructures
{
    // NOTE: Allows 1million elements at max
    public class MinHeap<TKey, TValue>
        where TValue : IComparable<TValue>
    {
        public class KeyValuePair
        {
            private TKey _key;
            private TValue _value;

            public KeyValuePair(TKey key, TValue value)
            {
                _key = key;
                _value = value;
            }

            public TKey Key
            {
                get
                {
                    return _key;
                }
            }

            public TValue Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
        }

        private KeyValuePair[] _heap;
        private int _count = 0;
        private Dictionary<TKey, int> _heapIndex;
        private static readonly int BufferSize = 1000000;

        public MinHeap()
        {
            _heap = new KeyValuePair[BufferSize];
            _heapIndex = new Dictionary<TKey, int>(BufferSize);
        }

        public MinHeap(int capacity)
        {
            _heap = new KeyValuePair[capacity];
            _heapIndex = new Dictionary<TKey, int>(capacity);
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Insert(TKey key, TValue value)
        {
            var kvp = new KeyValuePair(key, value);
            _heapIndex[key] = _count;
            _heap[_count++] = kvp;
            BubbleUp(_count - 1);
        }

        public void Delete(TKey key)
        {
            int nodeIndex = _heapIndex[key];
            var kvp = _heap[--_count];
            _heap[nodeIndex] = kvp;
            _heapIndex[kvp.Key] = nodeIndex;
            _heapIndex.Remove(key);
            int parentIndex = GetParentIndex(nodeIndex);
            bool bubbleUp = false;
            if (parentIndex > 0)
            {
                var parentNode = _heap[parentIndex];
                if (kvp.Value.CompareTo(parentNode.Value) < 0)
                {
                    Swap(nodeIndex, parentIndex);
                    _heapIndex[key] = parentIndex;
                    _heapIndex[parentNode.Key] = nodeIndex;
                    BubbleUp(parentIndex);
                    bubbleUp = true;
                }
            }
            if (!bubbleUp)
            {
                if (_count > (nodeIndex + 1))
                {
                    BubbleDown(nodeIndex);
                }
            }
        }

        public KeyValuePair Find(TKey key)
        {
            if (_heapIndex.ContainsKey(key))
                return _heap[_heapIndex[key]];
            return null;
        }

        public void Update(TKey key, TValue value)
        {
            var nodeIndex = _heapIndex[key];
            _heap[nodeIndex].Value = value;

            int parentIndex = GetParentIndex(nodeIndex);
            bool bubbleUp = false;
            if (parentIndex >= 0)
            {
                var parentNode = _heap[parentIndex];
                if (parentNode.Value.CompareTo(value) > 0)
                {
                    Swap(nodeIndex, parentIndex);
                    _heapIndex[key] = parentIndex;
                    _heapIndex[parentNode.Key] = nodeIndex;
                    BubbleUp(parentIndex);
                    bubbleUp = true;
                }
            }
            if (!bubbleUp)
            {
                int minIndex = GetMinChildIndex(nodeIndex);
                if (minIndex > 0)
                {
                    var minNode = _heap[minIndex];
                    if (value.CompareTo(minNode.Value) > 0)
                    {
                        Swap(nodeIndex, minIndex);
                        _heapIndex[key] = minIndex;
                        _heapIndex[minNode.Key] = nodeIndex;
                        BubbleDown(minIndex);
                    }
                }
            }
        }

        public KeyValuePair ExtractMin()
        {
            KeyValuePair min = _heap[0];
            _count--;
            if (_count > 0)
            {
                var kvp = _heap[_count];
                _heap[0] = kvp;
                TKey key = _heap[0].Key;
                _heapIndex[key] = 0;
                _heapIndex.Remove(min.Key);
                if (_count > 1)
                {
                    BubbleDown(0);
                }
            }
            return min;
        }

        private void BubbleUp(int nodeIndex)
        {
            if (nodeIndex != 0)
            {
                int parentIndex = GetParentIndex(nodeIndex);
                var node = _heap[nodeIndex];
                var parentNode = _heap[parentIndex];
                if (parentNode.Value.CompareTo(node.Value) > 0)
                {
                    Swap(nodeIndex, parentIndex);
                    _heapIndex[node.Key] = parentIndex;
                    _heapIndex[parentNode.Key] = nodeIndex;
                    BubbleUp(parentIndex);
                }
            }
        }

        private void BubbleDown(int nodeIndex)
        {
            var node = _heap[nodeIndex];
            int minIndex = GetMinChildIndex(nodeIndex);
            if (minIndex > 0)
            {
                var minNode = _heap[minIndex];
                if (node.Value.CompareTo(minNode.Value) > 0)
                {
                    Swap(minIndex, nodeIndex);
                    _heapIndex[node.Key] = minIndex;
                    _heapIndex[minNode.Key] = nodeIndex;
                    BubbleDown(minIndex);
                }
            }
        }

        private void Swap(int node1, int node2)
        {
            var tmpNode = _heap[node1];
            _heap[node1] = _heap[node2];
            _heap[node2] = tmpNode;
        }

        private int GetParentIndex(int index)
        {
            return (index + 1) / 2 - 1;
        }

        private int GetChildStartIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetChildEndIndex(int index)
        {
            return index * 2 + 2;
        }

        private int GetMinChildIndex(int index)
        {
            int startIndex = GetChildStartIndex(index);
            if (startIndex >= _count)
                return -1;
            int endIndex = GetChildEndIndex(index);
            if (endIndex >= _count)
                return startIndex;
            return (_heap[startIndex].Value.CompareTo(_heap[endIndex].Value) < 0)
                    ? startIndex : endIndex;
        }
    }
}
