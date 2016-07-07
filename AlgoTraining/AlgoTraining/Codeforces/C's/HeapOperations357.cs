using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.C_s
{
    class HeapOperations357
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt();
                MinHeap<int, int> heap = new MinHeap<int, int>();
                List<string> list = new List<string>(2 * n);
                for (int i = 0; i < n; i++)
                {
                    string line = fs.ReadLine();
                    string[] tokens = line.Split();
                    string cmd = tokens[0];
                    if (cmd == "insert") {
                        int x = Convert.ToInt32(tokens[1]);
                        heap.Insert(x, x);
                    }
                    else if (cmd == "getMin") {
                        int x = Convert.ToInt32(tokens[1]);
                        if (heap.Count > 0)
                        {
                            int min = heap.GetMin().Value;
                            while (min < x)
                            {
                                heap.ExtractMin();
                                list.Add("removeMin");
                                if (heap.Count == 0) break;
                                else min = heap.GetMin().Value;
                            }
                            if (heap.Count == 0 || min > x)
                            {
                                heap.Insert(x, x);
                                list.Add("insert " + x);
                            }
                        }
                        else
                        {
                            heap.Insert(x, x);
                            list.Add("insert " + x);
                        }
                    }
                    else {
                        if (heap.Count > 0) heap.ExtractMin();
                        else list.Add("insert 1");
                    }
                    list.Add(line);
                }
                writer.WriteLine(list.Count);
                foreach (string line in list)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
