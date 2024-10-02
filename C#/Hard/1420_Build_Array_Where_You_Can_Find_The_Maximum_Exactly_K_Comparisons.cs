using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1420
    {
        public Hard_1420()
        {
            Console.WriteLine(NumOfArrays(2,3,1));
        }
        private int[][][] dp;
        private int n;
        private int m;
        private int mod = (int)(1e9 + 7);

        public int NumOfArrays(int n, int m, int k)
        {
            this.n = n;
            this.m = m;

            dp = new int[n][][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[m + 1][];
                for (int j = 0; j <= m; j++)
                {
                    dp[i][j] = new int[k + 1];
                    Array.Fill(dp[i][j], -1);
                }
            }

            return recursiveSolution(0, 0, k);
        }
        public int recursiveSolution(int currIndex, int lastMax, int k)
        {
            if (n == currIndex)
                return k == 0 ? 1 : 0;
            if (k < 0)
                return 0;

            if (dp[currIndex][lastMax][k] != -1)
                return dp[currIndex][lastMax][k];

            int solution = 0;
            //two possiblities
            //1. giving smaller or equal numbers than max
            for (int i = 1; i <= lastMax; i++)
                solution = (solution + recursiveSolution(currIndex + 1, lastMax, k)) % mod;

            //2. giving a new max number
            for (int i = lastMax + 1; i <= m; i++)
                solution = (solution + recursiveSolution(currIndex + 1, i, k - 1)) % mod;

            dp[currIndex][lastMax][k] = solution;
            return solution;
        }
    }
}
