using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_377
    {
        public Medium_377()
        {

        }

        public Dictionary<int,int> dp;
        public int CombinationSum4(int[] nums, int target)
        {
            dp = new Dictionary<int, int>();

            return dpSolution(0, nums, target);
        }
        public int dpSolution(int sum, int[] nums, int target)
        {
            if (sum == target)
                return 1;

            if (dp.ContainsKey(sum))
                return dp[sum];

            int solution = 0;
            foreach (var item in nums)
                if (sum + item <= target)
                    solution += dpSolution(sum + item, nums, target);

            dp.Add(sum, solution);
            return solution;
        }
    }
}
