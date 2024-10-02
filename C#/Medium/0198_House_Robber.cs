using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_198
    {
        public Medium_198()
        {

        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            int[] dp = new int[nums.Length];
            dp[nums.Length - 1] = nums[nums.Length - 1];
            dp[nums.Length - 2] = Math.Max(nums[nums.Length - 1], nums[nums.Length - 2]);

            for (int i = nums.Length - 3; i >= 0; i--)
                dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);

            return dp[0];
        }
    }
}
