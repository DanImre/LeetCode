using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2369
    {
        public Medium_2369()
        {
            ValidPartition(new int[] { 1, 1, 1, 2 }); //False
        }
        public bool?[] dp;
        public bool ValidPartition(int[] nums)
        {
            dp = new bool?[nums.Length + 1];
            dp[nums.Length] = true;

            return ValidPartitionsRecursive(nums, 0);
        }
        public bool ValidPartitionsRecursive(int[] nums, int index)
        {
            if (dp[index].HasValue)
                return dp[index].Value;

            if (index < nums.Length - 1
                && nums[index] == nums[index + 1]
                && ValidPartitionsRecursive(nums, index + 2))
            {
                dp[index] = true;
                return true;
            }

            if (index < nums.Length - 2
                && nums[index] == nums[index + 1]
                && nums[index + 1] == nums[index + 2]
                && ValidPartitionsRecursive(nums, index + 3))
            {
                dp[index] = true;
                return true;
            }

            if (index < nums.Length - 2
                && nums[index] + 1 == nums[index + 1]
                && nums[index + 1] + 1 == nums[index + 2]
                && ValidPartitionsRecursive(nums, index + 3))
            {
                dp[index] = true;
                return true;
            }

            dp[index] = false;
            return false;
        }
    }
}
