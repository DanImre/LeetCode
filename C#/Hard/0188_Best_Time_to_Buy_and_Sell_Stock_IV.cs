using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_188
    {
        public Hard_188()
        {
            Console.WriteLine(MaxProfit(2, new int[] { 2, 4, 1 }));
        }
        public int MaxProfit(int k, int[] prices)
        {
            int[][] dp = new int[prices.Length + 1][];
            dp[prices.Length] = new int[2 * k + 1];

            for (int i = prices.Length - 1; i >= 0; i--)
            {
                dp[i] = new int[2 * k + 1];
                for (int op = 0; op < 2 * k; op++)
                    if (op % 2 == 0) //buying
                        dp[i][op] = Math.Max(dp[i + 1][op + 1] - prices[i], dp[i + 1][op]);
                    else //selling
                        dp[i][op] = Math.Max(dp[i + 1][op + 1] + prices[i], dp[i + 1][op]);
            }

            return dp[0][0];
        }
    }
}
