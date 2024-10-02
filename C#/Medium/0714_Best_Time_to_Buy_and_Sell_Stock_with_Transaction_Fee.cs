using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_714
    {
        public Medium_714()
        {

        }
        public int MaxProfit(int[] prices, int fee)
        {
            int[,] dp = new int[prices.Length + 1, 2]; // 0 buy // 1 sell

            for (int i = prices.Length - 1; i >= 0; i--)
            {
                dp[i, 0] = Math.Max(dp[i + 1, 1] - prices[i], dp[i + 1, 0]);
                dp[i, 1] = Math.Max(dp[i + 1, 0] + prices[i] - fee, dp[i + 1, 1]);
            }

            return dp[0, 0];
        }
    }
}
