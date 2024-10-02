using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_5
    {
        public Medium_5()
        {

        }
        public string LongestPalindrome(string s)
        {
            bool[][] dp = new bool[s.Length][];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = new bool[s.Length];
                dp[i][i] = true;
            }

            (int, int) solution = (0, 0);

            for (int i = 0; i < s.Length-1; i++)
                if (s[i] == s[i + 1])
                {
                    dp[i][i + 1] = true;
                    solution = (i, i + 1);
                }

            for (int i = 2; i < s.Length; i++)
                for (int j = 0; j <  s.Length - i; j++)
                {
                    int k = j + i;
                    if (s[j] == s[k] // Xas .. saX
                        && dp[j + 1][k - 1]) //xAs .. sAx
                    {
                        solution = (j, k);
                        dp[j][k] = true;
                    }
                }

            return s.Substring(solution.Item1, solution.Item2 - solution.Item1);
        }
    }
}
