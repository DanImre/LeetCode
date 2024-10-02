using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1155
    {
        public Medium_1155()
        {

        }

        public int NumRollsToTarget(int n, int k, int target)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[target + 1];
                Array.Fill(dp[i], -1);
            }

            int mod = (int)(1e9 + 7);

            int recursiveSolution(int n, int k, int target)
            {
                if (n == 0 && target == 0)
                    return 1;

                if (n == 0 || target <= 0)
                    return 0;

                if (dp[n][target] != -1)
                    return dp[n][target];

                int solution = 0;
                for (int i = 1; i <= k; i++)
                    solution = (solution + recursiveSolution(n - 1, k, target - i)) % mod;

                dp[n][target] = solution;
                return solution;
            }

            return recursiveSolution(n, k, target);
        }
    }
}
