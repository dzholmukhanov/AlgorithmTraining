using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.Croc2016
{
    class ProcessingQueriesB
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), b = fs.NextInt();
                Query[] queries = new Query[n];
                long[] finishingTimes = new long[n];

                for (int i = 0; i < n; i++)
                {
                    queries[i] = new Query { Id = i, Time = fs.NextInt(), Duration = fs.NextInt() };
                }
                Queue<Query> queryQueue = new Queue<Query>();
                long freeTime = queries[0].Time;
                for (int i = 0; i < n; i++)
                {
                    if (freeTime <= queries[i].Time)
                    {
                        if (queryQueue.Count > 0)
                        {
                            Query query = queryQueue.Dequeue();
                            freeTime = freeTime + query.Duration;
                            finishingTimes[query.Id] = freeTime;
                            queryQueue.Enqueue(queries[i]);
                        }
                        else
                        {
                            freeTime = queries[i].Time + queries[i].Duration;
                            finishingTimes[queries[i].Id] = freeTime;
                        }
                    }
                    else if (freeTime > queries[i].Time)
                    {
                        if (queryQueue.Count < b)
                        {
                            queryQueue.Enqueue(queries[i]);
                        }
                        else
                        {
                            finishingTimes[i] = -1;
                        }
                    }
                }
                while (queryQueue.Count > 0)
                {
                    Query query = queryQueue.Dequeue();
                    freeTime = freeTime + query.Duration;
                    finishingTimes[query.Id] = freeTime;
                }
                for (int i = 0; i < n; i++)
                {
                    writer.Write(finishingTimes[i] + " ");
                }
            }
        }
    }
    class Query
    {
        public int Id, Time, Duration;
    }
}
