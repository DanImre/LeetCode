using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_62
    {
        public Medium_62()
        {

        }
        public int UniquePaths(int m, int n)
        {
            //Math
            long solution = 1;
            for (int i = 1; i < m; i++)
                solution = solution * (n - 1 + i) / i;

            return (int)solution;

            //DP solution:
            /*
            int[][] dp = new int[m][];
            dp[0] = new int[n];
            Array.Fill(dp[0], 1);

            for (int i = 1; i < m; i++)
            {
                dp[i] = new int[n];
                dp[i][0] = 1;
                for (int j = 1; j < n; j++)
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
            }

            return dp[m - 1][n - 1];*/
        }
    }
}
