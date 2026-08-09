namespace Medium
{
    public class _1140_Stone_Game_II
    {
        public int StoneGameII(int[] piles)
        {
            if (piles.Length <= 2)
                return piles.Sum();

            int[,] dp = new int[piles.Length + 1, piles.Length + 1];

            int[] suffixSum = new int[piles.Length + 1];
            for (int i = piles.Length - 1; i >= 0; i--)
                suffixSum[i] = suffixSum[i + 1] + piles[i];

            for (int i = piles.Length - 1; i >= 0; i--)
                for (int m = piles.Length - 1; m >= 1; m--)
                    for (int x = 1; x <= 2 * m && i + x <= piles.Length; x++)
                    {
                        int newM = Math.Max(m, x);
                        dp[i, m] = Math.Max(
                            dp[i, m],
                            suffixSum[i] - dp[i + x, newM]
                        );
                    }

            return dp[0, 1];
        }

        public int StoneGameII_Recursive(int[] piles)
        {
            int[] suffixSum = new int[piles.Length + 1];
            for (int i = piles.Length - 1; i >= 0; i--)
                suffixSum[i] = suffixSum[i + 1] + piles[i];

            Dictionary<(int i, int m), int> memo = [];
            int recursiveSolution(int index, int m)
            {
                if (index + 2 * m >= piles.Length)
                    return suffixSum[index];

                if (memo.ContainsKey((index, m)))
                    return memo[(index, m)];

                int sol = 0;
                for (int x = 1; x <= m * 2 && index + x <= piles.Length; x++)
                {
                    int newM = Math.Max(x, m);
                    sol = Math.Max(
                        sol,
                        suffixSum[index] - recursiveSolution(index + x, newM)
                    );
                }

                memo[(index, m)] = sol;
                return sol;
            }

            return recursiveSolution(0, 1);
        }
    }
}
