﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_576
    {
        public Medium_576()
        {

        }

        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            int MOD = (int)1e9 + 7;
            int[,] dp = new int[m, n];

            dp[startRow, startColumn] = 1;
            int count = 0;

            for (int moves = 1; moves <= maxMove; moves++)
            {
                int[,] temp = new int[m,n];

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (i == m - 1) count = (count + dp[i, j]) % MOD;
                        if (j == n - 1) count = (count + dp[i, j]) % MOD;
                        if (i == 0) count = (count + dp[i, j]) % MOD;
                        if (j == 0) count = (count + dp[i, j]) % MOD;
                        temp[i, j] = ((((i > 0 ? dp[i - 1, j] : 0) + (i < m - 1 ? dp[i + 1, j] : 0)) % MOD) +
                                ((j > 0 ? dp[i, j - 1] : 0) + (j < n - 1 ? dp[i, j + 1] : 0)) % MOD) % MOD;
                    }
                dp = temp;
            }

            return count;
        }
    }
}
