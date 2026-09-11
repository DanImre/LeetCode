using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    public class _354_Russian_Doll_Envelopes
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            envelopes.Sort((a, b) => a[0].CompareTo(b[0]) * 2 + b[1].CompareTo(a[1]));

            // LIS (Longest Increasing Subsequence)
            // DP O(n^2)
            // TLE

            //int[] dp = new int[envelopes.Length];
            //Array.Fill(dp, 1);

            //for (int i = 1; i < envelopes.Length; i++)
            //    for (int j = i - 1; j >= 0; j--)
            //    {
            //        if (envelopes[i][1] > envelopes[j][1])
            //            dp[i] = Math.Max(dp[i], dp[j] + 1);
            //    }

            //return dp.Max();

            // LIS (Longest Increasing Subsequence)
            // DP O(n (log n))
            int[] bucket = new int[envelopes.Length];
            bucket[0] = envelopes[0][1];
            int solution = 1;

            for (int i = 0; i < envelopes.Length; i++)
                if (bucket[solution - 1] < envelopes[i][1])
                {
                    bucket[solution] = envelopes[i][1];
                    solution++;
                }
                else
                {
                    int index = Array.BinarySearch(bucket, 0, solution, envelopes[i][1]);
                    if (index < 0)
                        index = ~index;

                    bucket[index] = envelopes[i][1];
                }

            return solution;
        }
    }
}
