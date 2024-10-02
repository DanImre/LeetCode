using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_0091
    {
        public Medium_0091()
        {

        }

        public int NumDecodings(string s)
        {
            if (s[0] == '0')
                return 0;

            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= s.Length; i++)
            {
                int digit = s[i - 1] - '0';
                int TwoDigitNumber = int.Parse(s.Substring(i - 2, 2));

                if (digit != 0)
                    dp[i] = dp[i - 1];

                if (10 <= TwoDigitNumber && TwoDigitNumber <= 26)
                    dp[i] += dp[i - 2];
            }

            return dp[s.Length];
        }
    }
}
