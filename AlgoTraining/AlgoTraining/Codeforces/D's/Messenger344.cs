using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTraining.Codeforces.D_s
{
    class Messenger344
    {
        public static void Run()
        {
            using (FastScanner fs = new FastScanner(new BufferedStream(Console.OpenStandardInput())))
            using (StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                int n = fs.NextInt(), m = fs.NextInt();
                LinkedList<Block> t = new LinkedList<Block>(), s = new LinkedList<Block>();

                string[] line = fs.ReadLine().Split(' ');
                Block lastBlock = new Block(line[0]);
                t.AddLast(lastBlock);
                for (int i = 1; i < n; i++)
                {
                    Block block = new Block(line[i]);
                    if (!lastBlock.Merge(block)) 
                    {
                        t.AddLast(block);
                        lastBlock = block;
                    }
                }

                line = fs.ReadLine().Split(' ');
                lastBlock = new Block(line[0]);
                s.AddLast(lastBlock);
                for (int i = 1; i < m; i++)
                {
                    Block block = new Block(line[i]);
                    if (!lastBlock.Merge(block))
                    {
                        s.AddLast(block);
                        lastBlock = block;
                    }
                }
                n = t.Count;
                m = s.Count;
                long ans = 0;
                if (n >= m) 
                {
                    Block[] T = t.ToArray(), S = s.ToArray();

                    if (m >= 3)
                    {
                        Block[] merged = new Block[m - 1 + n];
                        for (int i = 0; i < m - 1 + n; i++)
                        {
                            if (i <= m - 3) merged[i] = S[i + 1];
                            else if (i == m - 2) merged[i] = new Block("1-#");
                            else merged[i] = T[i - m + 1];
                        }
                        int[] z = EvalZ(merged);
                        for (int i = m; i < m + n - 2; i++)
                        {
                            if (z[i] == m - 2 && i + z[i] < m - 1 + n)
                            {
                                if (merged[i - 1].EqualAndLonger(S[0]) && merged[i + z[i]].EqualAndLonger(S[m - 1]))
                                {
                                    ans++;
                                }
                            }
                        }
                    }
                    else if (m == 2)
                    {
                        for (int i = 0; i < n - 1; i++)
                        {
                            if (T[i].EqualAndLonger(S[0]) && T[i + 1].EqualAndLonger(S[1]))
                            {
                                ans++;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (T[i].EqualAndLonger(S[0]))
                            {
                                ans += T[i].len - S[0].len + 1;
                            }
                        }
                    }
                }
                writer.WriteLine(ans);
            }
        }

        public static int[] EvalZ(Block[] blocks)
        {
            int n = blocks.Length;
            int[] z = new int[n];
            int l = 0, r = 0;
            for (int i = 1; i < n; i++)
            {
                if (i <= r)
                {
                    z[i] = Math.Min(z[i - l], r - i + 1);
                }
                while (i + z[i] < n && blocks[z[i]].Equals(blocks[i + z[i]]))
                {
                    z[i]++;
                }
                if (i + z[i] - 1 > r)
                {
                    l = i;
                    r = i + z[i] - 1;
                }
            }
            return z;
        }
    }
    class Block
    {
        public long len;
        public char letter;
        public Block(string expr)
        {
            string[] tokens = expr.Split('-');
            len = Convert.ToInt64(tokens[0]);
            letter = Convert.ToChar(tokens[1]);
        }
        public bool Merge(Block block)
        {
            if (this.letter == block.letter)
            {
                this.len += block.len;
                return true;
            }
            return false;
        }
        public bool Equals(Block block)
        {
            return this.len == block.len && this.letter == block.letter;
        }
        public bool EqualAndLonger(Block block)
        {
            return this.len >= block.len && this.letter == block.letter;
        }
    }
}

