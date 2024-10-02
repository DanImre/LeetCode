using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_516
    {
        public Medium_516()
        {

        }
        public int LongestPalindromeSubseq(string s)
        {
            string s2 = string.Join("", s.Reverse());
            int[,] dp = new int[s.Length + 1, s2.Length + 1];
            for (int i = 1; i <= s.Length; i++)
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s[i - 1] == s2[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }

            return dp[s.Length, s2.Length];
        }
    }
}
