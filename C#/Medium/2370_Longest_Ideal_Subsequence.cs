using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2370
    {
        public Medium_2370()
        {

        }
        public int LongestIdealString(string s, int k)
        {
            int[] dp = new int[26];

            int solution = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int curr = s[i] - 'a';
                int best = 0;
                for (int prev = 0; prev < 26; prev++)
                    if (Math.Abs(prev - curr) <= k)
                        best = Math.Max(best, dp[prev]);

                dp[curr] = Math.Max(dp[curr], best + 1);
                solution = Math.Max(solution, dp[curr]);
            }

            return solution;
        }
    }
}
