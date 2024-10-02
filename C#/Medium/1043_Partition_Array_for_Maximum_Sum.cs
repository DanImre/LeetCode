using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1043
    {
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            int[] dp = new int[arr.Length + 1];
            for (int i = 0; i <= arr.Length; i++)
            {
                int max = 0;
                for (int j = 1; j <= k && i >= j; j++)
                {
                    max = Math.Max(max, arr[i - j]);
                    dp[i] = Math.Max(dp[i], dp[i - j] + max * j);
                }
            }

            return dp[arr.Length];
        }
    }
}
