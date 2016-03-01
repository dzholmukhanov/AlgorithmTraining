using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Test
{
    public interface SqrtOperator<T>
    {
        void Eval(ref T result, T val);
    }
    public class SqrtSum : SqrtOperator<long>
    {
        public void Eval(ref long result, long val)
        {
            result += val;
        }
    }
    public class SqrtBoundedSum : SqrtOperator<long>
    {
        private long MaxVal;
        public SqrtBoundedSum(long maxVal)
        {
            MaxVal = maxVal;
        }
        public void Eval(ref long result, long val)
        {
            result += Math.Min(MaxVal, val);
        }
    }
    public class SqrtDecomposer<T>
    {
        private T[] Values, Buckets;
        private int BucketSize, BucketNum, Count;
        private SqrtOperator<T> ValueCombiner, BucketCombiner;
        public SqrtDecomposer(T[] a, SqrtOperator<T> valueCombiner, SqrtOperator<T> bucketCombiner)
        {
            Values = a;
            ValueCombiner = valueCombiner;
            BucketCombiner = bucketCombiner;
            Count = a.Length;
            BucketSize = (int)Math.Ceiling(Math.Sqrt(Count));
            BucketNum = (int)Math.Ceiling((Count * 1.0) / BucketSize);
            Buckets = new T[BucketNum];

            for (int i = 0; i < BucketNum; i++)
            {
                for (int j = 0; j < BucketSize; j++)
                {
                    if (i * BucketSize + j >= Count) break;
                    ValueCombiner.Eval(ref Buckets[i], a[i * BucketSize + j]);
                }
            }
        }
        public T Get(int index)
        {
            return Values[index];
        }
        public void Update(int index, T val)
        {
            Values[index] = val;
            int bucket = index / BucketSize;
            Buckets[bucket] = default(T);
            for (int i = bucket * BucketSize; i < Math.Min(Count, (bucket + 1) * BucketSize); i++)
            {
                ValueCombiner.Eval(ref Buckets[bucket], Values[i]);
            }
        }
        public T Eval(int l, int r)
        {
            if (l > r) return default(T);

            int lb = l / BucketSize + 1, rb = r / BucketSize - 1;
            T result = default(T);
            if (lb - 1 == rb + 1)
            {
                for (int i = l; i <= r; i++)
                {
                    ValueCombiner.Eval(ref result, Values[i]);
                }
            }
            else
            {
                for (int i = l; i < BucketSize * lb; i++)
                {
                    ValueCombiner.Eval(ref result, Values[i]);
                }
                if (lb <= rb)
                {
                    for (int i = lb; i <= rb; i++)
                    {
                        BucketCombiner.Eval(ref result, Buckets[i]);
                    }
                }
                for (int i = BucketSize * (rb + 1); i <= r; i++)
                {
                    ValueCombiner.Eval(ref result, Values[i]);
                }
            }
            return result;
        }
    }
}
