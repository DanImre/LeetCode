using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_300
    {
        public Medium_300()
        {

        }
        public int LengthOfLIS(int[] nums)
        {
            int max = 1;

            int[] dp = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int tempMax = 0;
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[i] < nums[j])
                        tempMax = Math.Max(tempMax, dp[j]);

                dp[i] = tempMax + 1;
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
    }
}
