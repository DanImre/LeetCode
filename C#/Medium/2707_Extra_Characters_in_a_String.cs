using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2707
    {
        public Medium_2707()
        {

        }
        public int MinExtraChar(string s, string[] dictionary)
        {
            HashSet<string> hs = new HashSet<string>(dictionary);
            int[] dp = new int[s.Length + 1];

            for (int i = s.Length - 1; i >= 0; i--)
            {
                StringBuilder sb = new StringBuilder();
                dp[i] = dp[i + 1] + 1;
                for (int j = i; j < s.Length; j++)
                {
                    sb.Append(s[j]);
                    if(hs.Contains(sb.ToString()))
                        dp[i] = Math.Min(dp[i], dp[j + 1]);
                }
            }

            return dp[0];
        }
    }
}
