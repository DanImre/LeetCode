using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_3068
    {
        public Hard_3068()
        {
            MaximumValueSum(new int[] { 1, 2, 1 }, 3, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } });
        }
        public long MaximumValueSum(int[] nums, int k, int[][] edges)
        {
            long[][] dp = new long[nums.Length + 1][];
            for (int i = 0; i <= nums.Length; i++)
                dp[i] = new long[2];
            dp[nums.Length][0] = int.MinValue;
            dp[nums.Length][1] = 0;

            for (int index = nums.Length - 1; index >= 0; index--)
                for (int isEven = 0; isEven <= 1; isEven++)
                {
                    long performOperation = dp[index + 1][isEven ^ 1] + (nums[index] ^ k);
                    long dontPerformOperation = dp[index + 1][isEven] + nums[index];

                    dp[index][isEven] = Math.Max(performOperation, dontPerformOperation);
                }

            return dp[0][1];
        }
    }
}
