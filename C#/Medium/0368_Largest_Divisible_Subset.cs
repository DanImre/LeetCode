using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_368
    {
        public Medium_368()
        {

        }
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            Array.Sort(nums);

            int[] dp = new int[nums.Length];
            int[] prev = new int[nums.Length];

            int max = 0;
            int maxi = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
                prev[i] = -1;

                for (int j = i - 1; j >= 0; j--)
                    if (nums[i] % nums[j] == 0 && dp[j] >= dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }

                if (max >= dp[i])
                    continue;

                max = dp[i];
                maxi = i;
            }

            List<int> solution = new List<int>();

            while (maxi != -1)
            {
                solution.Add(nums[maxi]);
                maxi = prev[maxi];
            }

            return solution;
        }
    }
}
