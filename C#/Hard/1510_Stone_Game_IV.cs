using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    public class _1510_Stone_Game_IV
    {
        public bool WinnerSquareGame(int n)
        {
            //return Minimax(n, true);
            return DpSolution(n);
        }

        public bool DpSolution(int n)
        {
            bool[] dp = new bool[n + 1];

            for (int i = 1; i <= n; i++)
            {
                // Possible optimization
                int sqrt = (int)Math.Sqrt(i);
                for (int j = sqrt; j > 0; j--)
                {
                    int rmd = i - j * j;

                    if (dp[rmd])
                        continue;

                    dp[i] = true;
                    break;
                }
            }

            return dp[n];
        }

        // two rows are redundant, dp[i,0] = !dp[i,1]
        public bool FirstDpSolution(int n)
        {
            // n stones | 0 - Alice 1 - Bob 
            bool[,] dp = new bool[n + 1, 2];

            for (int i = 1; i <= n; i++)
            {
                double dSqrt = Math.Sqrt(i);
                if (dSqrt % 1 == 0)
                {
                    dp[i, 0] = true;
                    continue;
                }

                bool aliceTurn = false;
                bool bobTurn = true;

                int sqrt = (int)dSqrt;

                for (int j = sqrt; j > 0; j--)
                {
                    int rmd = i - j * j;

                    aliceTurn |= dp[rmd, 1];
                    bobTurn &= dp[rmd, 0];
                }

                dp[i, 0] = aliceTurn;
                dp[i, 1] = bobTurn;
            }

            return dp[n, 0];
        }


        private Dictionary<(int, bool), bool> memo = [];
        public bool Minimax(int n, bool isAlice)
        {
            if (Math.Sqrt(n) % 1 == 0)
                return isAlice;

            if (memo.ContainsKey((n, isAlice)))
                return memo[(n, isAlice)];

            bool sol = !isAlice;
            int sqrt = (int)Math.Sqrt(n);

            if (isAlice)
            {
                for (int i = sqrt; i > 0 && !sol; i--)
                    sol |= Minimax(n - i * i, !isAlice);
            }
            else
            {
                for (int i = sqrt; i > 0 && sol; i--)
                    sol &= Minimax(n - i * i, !isAlice);
            }

            memo[(n, isAlice)] = sol;
            return sol;
        }
    }
}
