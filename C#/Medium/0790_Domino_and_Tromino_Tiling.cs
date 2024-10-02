using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_790
    {
        public Medium_790()
        {

        }

        public int NumTilings(int n)
        {
            int MOD = (int)1e9 + 7;
            int[] dp = new int[n + 1];
            Array.Fill(dp, -1);

            int recursiveSolution(int curr)
            {
                if (curr == 0)
                    return 1;

                if (curr < 3)
                    return curr;

                if (dp[curr] == -1)
                    dp[curr] = (((2 * recursiveSolution(curr - 1)) % MOD) + recursiveSolution(curr - 3)) % MOD;

                return dp[curr];
            }

            return recursiveSolution(n);
        }

        
    }
}
