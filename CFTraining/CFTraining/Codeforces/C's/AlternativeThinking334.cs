using CFTraining.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.C_s
{
    class AlternativeThinking334
    {
        public static void Run()
        {
            ConsoleScanner sc = new ConsoleScanner();
            int n = sc.NextInt();
            string str = sc.ReadLine();
            int[] altSeq = new int[n], revAltSeq = new int[n];
            char current = str[0];
            int index = 0;
            altSeq[0] = index;
            for (int i = 1; i < n; i++)
            {
                if (str[i] == current) altSeq[i] = index;
                else
                {
                    current = str[i];
                    index++;
                    altSeq[i] = index;
                }
            }
            current = str[n - 1];
            index = 0;
            revAltSeq[n - 1] = index;
            for (int i = n - 2; i >= 0; i--)
            {
                if (str[i] == current) revAltSeq[i] = index;
                else
                {
                    current = str[i];
                    index++;
                    revAltSeq[i] = index;
                }
            }

            int[] dp = new int[n];
            dp[0] = 1;
            for (int i = 1; i < n; i++)
            {
                int merged = str[i] == str[i - 1] ? dp[i - 1] : dp[i - 1] + 1;
                int newOne = str[i] == str[i - 1] ? altSeq[i - 1] + 2 : altSeq[i - 1] + 1;
                dp[i] = Math.Max(merged, newOne);
            }
            int answer = altSeq[n - 1] + 1;
            for (int i = 0; i < n - 1; i++)
            {
                answer = Math.Max(answer, dp[i] + (str[i] == str[i + 1] ? revAltSeq[i + 1] + 1 : revAltSeq[i + 1]));
            }
            answer = Math.Max(answer, dp[n - 1]);
            Console.WriteLine(answer);
        }
    }
}
