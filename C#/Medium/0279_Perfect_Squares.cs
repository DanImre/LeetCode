using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_279
    {
        public Medium_279()
        {

        }
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            int minValue = n;
            for (int i = 1; i <= n; i++)
            {
                minValue = i;
                int squared = 1;
                for (int j = 1; squared <= i; j++)
                {
                    minValue = Math.Min(minValue, 1 + dp[i - squared]);
                    squared = (j + 1) * (j + 1);
                }
                dp[i] = minValue;
            }
            return dp[n];
        }
    }
}
