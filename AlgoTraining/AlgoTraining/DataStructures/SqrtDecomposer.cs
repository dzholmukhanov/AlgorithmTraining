using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Test
{
    public interface SqrtOperator<T>
    {
        void Eval(ref T result, T val); // check of T is null
    }
    public class SqrtSum : SqrtOperator<long>
    {
        public void Eval(ref long result, long val)
        {
            result += val;
        }
    }
    public class SqrtDecomposer<T>
    {
        private T[] Values, Buckets;
        private int BucketSize, BucketNum, Count;
        private SqrtOperator<T> Operator;
        public SqrtDecomposer(T[] a, SqrtOperator<T> o)
        {
            Values = a;
            Operator = o;
            Count = a.Length;
            BucketSize = (int)Math.Ceiling(Math.Sqrt(Count));
            BucketNum = (int)Math.Ceiling((Count * 1.0) / BucketSize);
            Buckets = new T[BucketNum];

            for (int i = 0; i < BucketNum; i++)
            {
                for (int j = 0; j < BucketSize; j++)
                {
                    if (i * BucketSize + j >= Count) break;
                    Operator.Eval(ref Buckets[i],  a[i * BucketSize + j]);
                }
            }
        }
        public void Update(int index, T val)
        {
            Values[index] = val;
            int bucket = index / BucketSize;
            Buckets[bucket] = default(T);
            for (int i = bucket * BucketSize; i < Math.Min(Count, (bucket + 1) * BucketSize); i++)
            {
                Operator.Eval(ref Buckets[bucket], Values[i]);
            }
        }
        public T Eval(int l, int r)
        {
            int lb = l / BucketSize + 1, rb = r / BucketSize - 1;
            T result = default(T);
            if (lb - 1 == rb + 1)
            {
                for (int i = l; i <= r; i++)
                {
                    Operator.Eval(ref result, Values[i]);
                }
            }
            else
            {
                for (int i = l; i < BucketSize * lb; i++)
                {
                    Operator.Eval(ref result, Values[i]);
                }
                if (lb <= rb)
                {
                    for (int i = lb; i <= rb; i++)
                    {
                        Operator.Eval(ref result, Buckets[i]);
                    }
                }
                for (int i = BucketSize * (rb + 1); i < r; i++)
                {
                    Operator.Eval(ref result, Values[i]);
                }
            }
            return result;
        }
    }
}
