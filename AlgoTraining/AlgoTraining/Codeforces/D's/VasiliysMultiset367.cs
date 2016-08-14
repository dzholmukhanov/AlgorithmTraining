using AlgoTraining.DataStructures;
using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class VasiliysMultiset367
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int q = fs.NextInt();
                Dictionary<int, int> count = new Dictionary<int, int>();
                count.Add(0, int.MaxValue);
                BinaryTrie trie = new BinaryTrie('0', '1');
                trie.Add(DecToPaddedBin(0));
                while (q-- > 0)
                {
                    string[] toks = fs.ReadLine().Split();
                    int x = Convert.ToInt32(toks[1]);
                    if (toks[0] == "?")
                    {
                        string path = DecToPaddedBin(x ^ int.MaxValue);
                        var current = trie.GetRoot();
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < path.Length; i++)
                        {
                            if (path[i] == '0' && current.Left != null || path[i] == '1' && current.Right == null)
                            {
                                current = current.Left;
                                sb.Append('0');
                            }
                            else if (path[i] == '1' && current.Right != null || path[i] == '0' && current.Left == null)
                            {
                                current = current.Right;
                                sb.Append('1');
                            }
                        }
                        int ans = PaddedBinToDec(sb.ToString());
                        writer.WriteLine(ans ^ x);
                    }
                    else
                    {
                        if (toks[0] == "+")
                        {
                            if (!count.ContainsKey(x)) count.Add(x, 1);
                            else count[x]++;
                            if (count[x] == 1) trie.Add(DecToPaddedBin(x));
                        }
                        else if (toks[0] == "-")
                        { 
                            count[x]--;
                            if (count[x] == 0) trie.Remove(DecToPaddedBin(x));
                        }
                    }
                }
            }
        }


        private static string DecToPaddedBin(int x)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 31; i++)
            {
                sb.Append(x & 1);
                x >>= 1;
            }
            return new string(sb.ToString().Reverse().ToArray());
        }
        private static int PaddedBinToDec(string bin)
        {
            int x = 0, k = 0;
            for (int i = bin.Length - 1; i >= 0; i--, k++)
            {
                if (bin[i] == '1') x += (int)Math.Pow(2, k);
            }
            return x;
        }
    }
}