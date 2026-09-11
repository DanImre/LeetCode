namespace Hard
{
    public class _115_Distinct_Subsequences
    {
        public int NumDistinct(string s, string t)
        {
            int[][] dp = new int[s.Length + 1][];
            for (int i = 0; i <= s.Length; i++)
            {
                dp[i] = new int[t.Length + 1];
                dp[i][^1] = 1;
            }

            for (int i = t.Length - 1; i >= 0; i--)
            {
                int runningCount = 0;
                for (int j = s.Length - 1; j >= 0; j--)
                {
                    if (t[i] == s[j])
                        runningCount += dp[j + 1][i + 1];

                    dp[j][i] = runningCount;
                }
            }

            return dp[0][0];
        }
    }
}
