using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_740
    {
        public int DeleteAndEarn(int[] nums)
        {
            int numsMax = nums.Max();
            int[] dic = new int[numsMax + 1];
            foreach (var item in nums)
                    dic[item]++;

            if (numsMax == 1)
                return dic[1];

            int[] dp = new int[numsMax + 1];
            dp[1] = dic[1];
            dp[2] = Math.Max(dic[1], 2 * dic[2]);

            for (int i = 3; i <= numsMax; i++)
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + i * dic[i]);

            return dp[numsMax];
        }
    }
}
