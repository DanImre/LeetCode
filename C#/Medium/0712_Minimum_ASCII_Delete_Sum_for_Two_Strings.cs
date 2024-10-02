using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_712
    {
        public Medium_712()
        {
            //Console.WriteLine(MinimumDeleteSum("sea","eat"));
            Console.WriteLine(MinimumDeleteSum("delete","leet"));
        }
        public int MinimumDeleteSum(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++)
                dp[i,0] = dp[i - 1, 0] + s1[i - 1];
            for (int i = 1; i <= s2.Length; i++)
                dp[0, i] = dp[0, i - 1] + s2[i - 1];

            for (int i = 1; i <= s1.Length; i++)
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Min(s1[i - 1] + dp[i - 1, j], s2[j - 1] + dp[i, j - 1]);
                }

            return dp[s1.Length, s2.Length];
        }
    }
}
