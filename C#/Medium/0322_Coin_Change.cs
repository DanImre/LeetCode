using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_322
    {
        public Medium_322()
        {

        }
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0)
                return 0;

            int[] dp = new int[amount + 1];
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;

            for (int i = 1; i < amount + 1; i++)
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] > i
                        || dp[i - coins[j]] == int.MaxValue)
                        continue;

                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }

            if (dp[amount] == int.MaxValue)
                return -1;

            return dp[amount];
        }
    }
}
