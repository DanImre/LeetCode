using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1269
    {
        public Hard_1269()
        {

        }

        private int[][] dp;
        private int arrLen;
        private int mod = (int)1e9 + 7;
        public int NumWays(int steps, int arrLen)
        {
            this.arrLen = Math.Min(steps, arrLen);
            dp = new int[this.arrLen][];
            for (int i = 0; i < this.arrLen; i++)
            {
                dp[i] = new int[steps + 1];
                Array.Fill(dp[i], -1);
            }

            return RecursiveSolution(0, steps);
        }

        public int RecursiveSolution(int pos, int steps)
        {
            if (steps == 0)
                return pos == 0 ? 1 : 0;

            if (dp[pos][steps] != -1)
                return dp[pos][steps];

            //stay
            int solution = RecursiveSolution(pos, steps - 1);

            //left
            if (pos != 0)
                solution = (solution + RecursiveSolution(pos - 1, steps - 1)) % mod;

            //right
            if (pos < arrLen - 1)
                solution = (solution + RecursiveSolution(pos + 1, steps - 1)) % mod;

            dp[pos][steps] = solution;
            return solution;
        }
    }
}
