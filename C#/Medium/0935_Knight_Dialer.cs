using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_935
    {
        public Medium_935()
        {

        }
        public int KnightDialer(int n)
        {
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
                dp[i] = new int[10];

            Array.Fill(dp[0], 1);
            int MOD = (int)1e9 + 7;

            for (int i = 1; i < n; i++)
            {
                dp[i][0] = (dp[i - 1][4] + dp[i - 1][6]) % MOD;
                dp[i][1] = (dp[i - 1][8] + dp[i - 1][6]) % MOD;
                dp[i][2] = (dp[i - 1][7] + dp[i - 1][9]) % MOD;
                dp[i][3] = (dp[i - 1][8] + dp[i - 1][4]) % MOD;
                dp[i][4] = (((dp[i - 1][3] + dp[i - 1][9]) % MOD) + dp[i - 1][0]) % MOD;
                //dp[i][5] = 0
                dp[i][6] = (((dp[i - 1][7] + dp[i - 1][1]) % MOD) + dp[i - 1][0]) % MOD;
                dp[i][7] = (dp[i - 1][2] + dp[i - 1][6]) % MOD;
                dp[i][8] = (dp[i - 1][1] + dp[i - 1][3]) % MOD;
                dp[i][9] = (dp[i - 1][2] + dp[i - 1][4]) % MOD;
            }
            int solution = 0;
            for (int i = 0; i < 10; i++)
                solution = (solution + dp[n - 1][i]) % MOD;

            return solution;
        }
    }
}
